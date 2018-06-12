using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeVendas.Models
{
    class Venda
    {
        //PROP TAB TAB -> AUTO COMPLETAR

        public Cliente Cliente { get; set; }
        public Vendedor Vendedor { get; set; }
        public DateTime Data { get; set; }
        public Endereco EnderecoDaVenda { get; set; }

        public List<ItemDeVenda> itens = new List<ItemDeVenda>();

        //OBJETO DENTRO DE OBJETO - ESTANCIA OS OBJETOS DENTRO DO CONTRUTOR PORQ TODOS COMEÇAM EM NULO
        public Venda()
        {
            Cliente = new Cliente();
            Vendedor = new Vendedor();
            EnderecoDaVenda = new Endereco();
            itens = new List<ItemDeVenda>();

        }

        }

    }


