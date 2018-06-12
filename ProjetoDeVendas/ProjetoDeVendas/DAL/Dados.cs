using ProjetoDeVendas.Models;
using ProjetoDeVendas.Vews.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoDeVendas.DAL
{
    class Dados
    {

        public static void Inicializar()
        {
            List<Cliente> clientes = new List<Cliente>
            {
                new Cliente()
                {
                    Nome = "Diogo",
                    Cpf = "1"
                },
                new Cliente()
                {
                    Nome = "José",
                    Cpf = "2"
                },
                new Cliente()
                {
                    Nome = "Maria",
                    Cpf = "3"
                },
            };
            List<Vendedor> vendedores = new List<Vendedor>
            {
                new Vendedor()
                {
                    Nome = "Felipe",
                    Cpf = "4"
                },
                new Vendedor()
                {
                    Nome = "Augusto",
                    Cpf = "5"
                },
                new Vendedor()
                {
                    Nome = "Rafaela",
                    Cpf = "6"
                },
            };
            List<Produto> produtos = new List<Produto>
            {
                new Produto()
                {
                    Nome = "Arroz",
                    Markup = 2,
                    Preco = 2
                },
                new Produto()
                {
                    Nome = "Feijão",
                    Markup = 3,
                    Preco = 3
                },
                new Produto()
                {
                    Nome = "Macarrão",
                    Markup = 4,
                    Preco = 4
                },
            };

            List<Endereco> enderecos = new List<Endereco>
            {
                new Endereco()
                {
                    CEP = "1234",
                    Rua = "João José"
                },
                new Endereco()
                {
                    CEP = "4321",
                    Rua = "Limão de Farias"
                },
               
            };


            clientes.ForEach(x => ClienteDAO.SalvarCliente(x));
            vendedores.ForEach(x => VendedorDAO.SalvarVendedor(x));
            produtos.ForEach(x => ProdutoDAO.SalvarProduto(x));
            enderecos.ForEach(x => EnderecoDAO.SalvarEndereco(x));
        }
    }
}
