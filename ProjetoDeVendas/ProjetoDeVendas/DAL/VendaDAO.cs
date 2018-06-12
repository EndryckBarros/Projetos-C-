using ProjetoDeVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeVendas.DAL
{
    class VendaDAO
    {
        private static List<Venda> vendas = new List<Venda>();

        public static void SalvarVenda(Venda venda)
        {
            vendas.Add(venda);
        }

        public static List<Venda> RetornarLista()
        {
            return vendas;
        }

        public static List<Venda> BuscarVendaPorCliente(Cliente cliente)
        {
            List<Venda> vendasAux = new List<Venda>();
            foreach (Venda vendaCadastrada in vendas)
            {
                if (vendaCadastrada.Cliente.Cpf.Equals(cliente.Cpf))
                {
                    vendasAux.Add(vendaCadastrada);
                }
            }
            return vendasAux;
        }

        public static List<Venda> BuscarVendaPorEndereco(Endereco endereco)
        {
            List<Venda> vendasAux = new List<Venda>();
            foreach (Venda vendaCadastrada in vendas)
            {
                if (vendaCadastrada.EnderecoDaVenda.CEP.Equals(endereco.CEP))
                {
                    vendasAux.Add(vendaCadastrada);
                }
            }
            return vendasAux;

        }
    }
}
