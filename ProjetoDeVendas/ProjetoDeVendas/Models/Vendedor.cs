using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeVendas.Models
{
    class Vendedor
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public double TaxaDeComissao { get; set; }


        public override string ToString()
        {
            return "\nNome: " + Nome + "\nCPF: " + Cpf + "\nTaxa de Comissão: " + TaxaDeComissao;
        }

    }
}
