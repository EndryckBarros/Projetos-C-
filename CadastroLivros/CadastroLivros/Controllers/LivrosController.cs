using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using CadastroLivros.Models;

namespace CadastroLivros.Controllers
{
    public class LivrosController : ApiController
    {
        private Conexao db = new Conexao();

        // GET: api/Livros
        public IQueryable<LivroDTO> GetLivros()
        {
            var livros = from b in db.Livros
                        select new LivroDTO()
                        {
                            IdLivro = b.IdLivro,
                            Titulo = b.Titulo,
                            NomeAutor = b.Autor.Nome // ----- Filtra detalhes do livro para apresentação
                        };

            return livros.OrderBy(b => b.Titulo);
        }

        // GET: api/Livros/5
        [ResponseType(typeof(LivroDetalheDTO))]
        public async Task<IHttpActionResult> GetLivro(int id)
        {
            try
            {
                var livro = await db.Livros.Include(b => b.Autor).Select(b =>
                  new LivroDetalheDTO()
                  {
                      IdLivro = b.IdLivro,
                      Titulo = b.Titulo,
                      Ano = b.Ano,
                      Preco = b.Preco,
                      NomeAutor = b.Autor.Nome,
                      Genero = b.Genero
                  }).SingleOrDefaultAsync(b => b.IdLivro == id);

                if (livro == null)
                {
                    return NotFound();
                }
                return Ok(livro);
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // PUT: api/Livros/5
        [ResponseType(typeof(void))]
        [HttpPut]
        public async Task<IHttpActionResult> PutLivro(int id, Livro livro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != livro.IdLivro)
            {
                return BadRequest();
            }

            db.Entry(livro).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LivroExistsToId(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Livros
        [ResponseType(typeof(Livro))]
        
        public async Task<IHttpActionResult> PostLivro(Livro livro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!LivroExists(livro.Titulo))
            {
                db.Livros.Add(livro);
            }

            await db.SaveChangesAsync();

            // Carrega Nome do Autor
            db.Entry(livro).Reference(x => x.Autor).Load();

            var dto = new LivroDTO()
            {
                IdLivro = livro.IdLivro,
                Titulo = livro.Titulo,
                NomeAutor = livro.Autor.Nome
            };

            return CreatedAtRoute("DefaultApi", new { id = livro.IdLivro }, dto);
        }

        // DELETE: api/Livros/5 Formato Esperado URI
        [ResponseType(typeof(Livro))]
        [HttpDelete] // < -------------------------------------
        public async Task<IHttpActionResult> DeleteLivro(int id)
        {
            Livro livro = await db.Livros.FindAsync(id);
            if (livro == null)
            {
                return NotFound();
            }

            db.Livros.Remove(livro);
            await db.SaveChangesAsync();

            return Ok(livro);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LivroExists(string nome) // ----- Livros com mesmo nome não podem ser cadastrados
        {
            return db.Livros.Count(e => e.Titulo == nome) > 0;
        }

        private bool LivroExistsToId(int id) // ----- Livros com o mesmo ID não podem ser cadastrados então sofrem UPDATE (PUT)
        {
            return db.Livros.Count(e => e.IdLivro == id) > 0;
        }
    }
}