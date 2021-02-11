using CadastroLivros.Models;
using System.Net;
using System.Web.Mvc;

namespace CadastroLivros.Controllers
{
    public class HomeController : Controller
    {
        private Conexao db = new Conexao();

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Livro livro = db.Livros.Find(id);
            ViewBag.Autores = db.Autores;

            if (livro == null)
            {
                return HttpNotFound();
            }
            return View(livro);
        }
    }
}
