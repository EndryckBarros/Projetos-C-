using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadastroLivros.Models
{
    public class LivroDTO
    {
        public int IdLivro { get; set; }
        public string Titulo { get; set; }
        public string NomeAutor { get; set; }
    }
}