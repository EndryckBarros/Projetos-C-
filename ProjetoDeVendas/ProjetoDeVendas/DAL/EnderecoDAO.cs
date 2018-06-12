using ProjetoDeVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeVendas.DAL
{
    class EnderecoDAO
    {

        private static List<Endereco> enderecos = new List<Endereco>();

        public static bool SalvarEndereco(Endereco endereco)
        {
            if(BuscarEnderecoPorCEP(endereco) == null)
            {
                enderecos.Add(endereco);
                return true;
            }else
            {
                return false;
            }
        }

        public static Endereco BuscarEnderecoPorCEP(Endereco endereco)
        {
            if(enderecos.Count > 0)
            {
                foreach(Endereco enderecoCadastrado in enderecos)
                {
                    if (enderecoCadastrado.CEP.Equals(endereco.CEP))
                    {
                        return enderecoCadastrado;
                    }
                }
            } return null;
        }
    }
}
