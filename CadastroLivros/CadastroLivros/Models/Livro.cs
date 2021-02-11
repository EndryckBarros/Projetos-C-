using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CadastroLivros.Models
{
    [Table("Livro")]
    public class Livro
    {
        [Key]
        public int IdLivro { get; set; }
        [Required]
        public string  Titulo { get; set; }
        public int     Ano { get; set; }
        public double Preco { get; set; }
        public string  Genero { get; set; }

        // Foreign Key
        public int IdAutor { get; set; }
        // Navigation property
        [ForeignKey("IdAutor")]
        public Autor Autor { get; set; }
    }
}