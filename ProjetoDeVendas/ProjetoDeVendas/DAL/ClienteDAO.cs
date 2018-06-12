using ProjetoDeVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeVendas.Vews.Dal
{
    class ClienteDAO
    {
        //LISTA STATIC PARA SER ACESSADA PELO METODO
        private static List<Cliente> clientes = new List<Cliente>();

        //METODO QUE ADICIONA O CLIENTE A LISTA DE CLIENTES
        public static bool SalvarCliente(Cliente cliente)
        {
            Cliente aux = BuscarClientePorCPF(cliente);
            if (aux == null)
            {
                clientes.Add(cliente);
                return true;
                
            }
            else
            {
                return false;
            }

        }

        public static Cliente BuscarClientePorCPF(Cliente cliente)
        {
            if (clientes.Count > 0)
            {
                //ELSE DENTRO DO FOREACH DA O RETURN E NÃO TERMINA A LISTA*
                foreach (Cliente clienteCadastrado in clientes)
                {
                    if (clienteCadastrado.Cpf.Equals(cliente.Cpf))
                    {
                        return clienteCadastrado;
                    }

                }
            } return null;
        }

        //public static Cliente BuscarClientePorCPF(string cpf)
        //{
        //ELSE DENTRO DO FOREACH DA O RETURN E NÃO TERMINA A LISTA*
        //  foreach (Cliente clienteCadastrado in clientes)
        //{
        //  if (clienteCadastrado.Cpf.Equals(cpf)){
        //    return clienteCadastrado;
        //}
        // } return null;
        //}

        //RETORNA A LISTA COM OS CLIENTES SALVOS
        public static List<Cliente> ListagemDeCliente()
        {

            return clientes;
        }

    }
}
