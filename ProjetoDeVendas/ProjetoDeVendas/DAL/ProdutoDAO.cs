using ProjetoDeVendas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeVendas.DAL
{
    class ProdutoDAO
    {

        private static List<Produto> produtos = new List<Produto>();
        
        public static bool SalvarProduto(Produto produto)
        {
            if (BuscarProdutoPeloNome(produto) == null)
            {
                produtos.Add(produto);
                return true;
            } return false;
        } 

        public static Produto BuscarProdutoPeloNome(Produto produto)
        {
            if (produtos.Count > 0)
            {
                //ELSE DENTRO DO FOREACH DA O RETURN E NÃO TERMINA A LISTA*
                foreach (Produto produtoCadastrado in produtos)
                {
                    if (produtoCadastrado.Nome.Equals(produto.Nome))
                    {
                        return produtoCadastrado;
                    }

                }
            } return null;
        }

        public static List<Produto> ListagemDeProdutos()
        {
            return produtos;
        }
    }
}
