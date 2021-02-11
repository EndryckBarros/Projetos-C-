using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CadastroLivros.Models
{
    public class LivroDetalheDTO
    {
        public int IdLivro { get; set; }
        public string Titulo { get; set; }
        public int Ano { get; set; }
        public double Preco { get; set; }
        public string NomeAutor { get; set; }
        public string Genero { get; set; }
    }
}