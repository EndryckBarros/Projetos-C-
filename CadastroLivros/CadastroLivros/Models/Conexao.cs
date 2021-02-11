
using System.Configuration;
using System.Data.Entity;

namespace CadastroLivros.Models
{
    public class Conexao : DbContext
    {
        public Conexao() : base(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString) //String de Conexão com o banco --- Web Config
        {

        }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Livro> Livros { get; set; }
    }
}

//go
//create table Autor(
//    IdAutor integer identity(1,1),
//	Nome nvarchar(50)    not null,
//	primary key(IdAutor))

//go
//create table Livro(
//    IdLivro integer identity(1,1),
//	Titulo nvarchar(50)    not null,
//	Preco float not null,
//	Ano integer not null,
//	Genero nvarchar(50)    not null,
//	IdAutor integer not null,
//	primary key(IdLivro),
//	foreign key(IdAutor) references Autor(IdAutor))