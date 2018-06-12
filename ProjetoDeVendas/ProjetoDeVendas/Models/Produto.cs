using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeVendas.Models
{
    class Produto
    {

        public string Nome { get; set; }
        public double Preco { get; set; }
        public double Markup { get; set; }


        public override string ToString()
        {
            return "\nNome: " + Nome + "\nPreço: " + Preco + "\nMarkup:" + Markup;
        }
    }
}
