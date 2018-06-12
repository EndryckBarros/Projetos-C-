using ProjetoDeVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeVendas.DAL
{
    class VendedorDAO
    {

        private static List<Vendedor> vendedores = new List<Vendedor>();

        public static bool SalvarVendedor(Vendedor vendedor)
        {
            if(BuscarVendedorPorCPF(vendedor) == null)
            {

                vendedores.Add(vendedor);
                return true;
            } return false;
        }

        public static Vendedor BuscarVendedorPorCPF(Vendedor vendedor)
        {
            if(vendedores.Count > 0)
            {
                foreach(Vendedor vendedorCadastrado in vendedores)
                {
                    if (vendedorCadastrado.Cpf.Equals(vendedor.Cpf))
                    {
                        return vendedorCadastrado;
                    }
                }
            } return null;
        }

        public static List<Vendedor> ListagemDeVendedores()
        {
            return vendedores;
        }

    }
}
