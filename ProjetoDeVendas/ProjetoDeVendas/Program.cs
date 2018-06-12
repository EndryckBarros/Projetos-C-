using ProjetoDeVendas.DAL;
using ProjetoDeVendas.Models;
using ProjetoDeVendas.Vews.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//PROJETO EM C# REFERENTE A UM PROGRAMA DE VENDAS
namespace ProjetoDeVendas
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcao;
            double totalItem = 0;
            double totalVenda = 0;
            double totalGeral = 0;

            Dados.Inicializar();
            Produto p = new Produto();
            Cliente c = new Cliente();
            Vendedor v = new Vendedor();
            Venda venda = new Venda();
            ItemDeVenda i = new ItemDeVenda();
            Endereco e = new Endereco();
            List<Vendedor> vendedores = new List<Vendedor>();

            //MANTEM O PROGRAMA ATIVO ATÉ QUE SEJA SELECIONADA A OPÇÃO DE SAIDA
            do
            {
                //APRESENTAÇÃO DO MENU PRINCIPAL
                Console.Clear();
                Console.WriteLine("--------------- # MENU PRINCIPAL # ---------------");
                Console.WriteLine(" 1 - Cadastrar Cliente");
                Console.WriteLine(" 2 - Cadastrar Vendedor");
                Console.WriteLine(" 3 - Cadastrar Produtos");
                Console.WriteLine(" 4 - Listar Clientes");
                Console.WriteLine(" 5 - Listar Vendedores");
                Console.WriteLine(" 6 - Listar Produtos");
                Console.WriteLine(" 7 - Registrar Venda");
                Console.WriteLine(" 8 - Listar Vendas Por CPF");
                Console.WriteLine(" 9 - Listar Todas as Vendas");
                Console.WriteLine("10 - Cadastrar Endereço");
                Console.WriteLine("11 - Listar Vendas Por Endereço");

                Console.WriteLine(" 0 - Sair");
                Console.WriteLine("\nSelecione uma opção");

                opcao = Convert.ToInt32(Console.ReadLine());

                //EXECUTA A AÇÃO DA OPÇÃO SELECIONADA
                switch (opcao)
                {

                    case 1:
                        //INICIA A INSTANCIA NOVAMENTE PARA NÃO DUPLICAR VARIAVEL 
                        c = new Cliente();
                        Console.Clear();
                        Console.WriteLine("------------ CADASTRO DE CLIENTE ------------");

                        Console.WriteLine("\nDigite o nome do cliente:");
                        c.Nome = Console.ReadLine();
                        Console.WriteLine("\nDigite o CPF do cliente:");
                        c.Cpf = Console.ReadLine();

                        //SALVANDO CLIENTE NA LISTA
                        if (ClienteDAO.SalvarCliente(c))
                        {
                            Console.WriteLine("\nCliente Cadastrado com Sucesso!");
                            //Console.WriteLine("\nCliente: " + c);
                        }
                        else
                        {
                            Console.WriteLine("\nNão foi possível salvar o cliente");
                            //Console.WriteLine("\nCliente: " + c);
                        }



                        break;

                    case 2:

                        v = new Vendedor();
                        Console.Clear();
                        Console.WriteLine("------------ CADASTRO DE VENDEDOR ------------");

                        Console.WriteLine("\nDigite o nome do vendedor:");
                        v.Nome = Console.ReadLine();
                        Console.WriteLine("\nDigite o CPF do vendedor");
                        v.Cpf = Console.ReadLine();
                        Console.WriteLine("\nInforme a taxa de comissão do vendedor:");
                        v.TaxaDeComissao = Convert.ToDouble(Console.ReadLine());

                        //SALVANDO VENDEDOR NA LISTA
                        if (VendedorDAO.SalvarVendedor(v))
                        {
                            Console.WriteLine("\nVendedor Cadastrado com Sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("\nNão foi possível Cadastrar o Vendedor");
                        }

                        break;

                    case 3:
                        //INICIA A INSTANCIA NOVAMENTE PARA NÃO DUPLICAR VARIAVEL 
                        p = new Produto();

                        Console.Clear();
                        Console.WriteLine("------------ CADASTRO DE PRODUTO ------------");

                        Console.WriteLine("\nDigite o Nome do Produto:");
                        p.Nome = Console.ReadLine();
                        Console.WriteLine("\nDigite o Preço do Produto:");
                        p.Preco = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("\nInforme o Markup do Produto:");
                        p.Markup = Convert.ToDouble(Console.ReadLine());

                        if (ProdutoDAO.SalvarProduto(p))
                        {
                            Console.WriteLine("\nProduto Cadastrado com Sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("\nNão foi possível Cadastrar o Produto");
                        }

                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("------------ LISTAGEM DE CLIENTES ------------");

                        //CHAMA O METODO QUE RETORNA A LISTA COM OS CLIENTES DENTRO DO FOREACH
                        foreach (Cliente clienteCadastrado in ClienteDAO.ListagemDeCliente())
                        {
                            Console.WriteLine("Cliente: " + clienteCadastrado);
                        }

                        break;

                    case 5:

                        Console.Clear();
                        Console.WriteLine("------------ LISTAGEM DE VENDEDORES ------------");

                        foreach (Vendedor vendedorCadastrado in VendedorDAO.ListagemDeVendedores())
                        {
                            Console.WriteLine("Vendedor: " + vendedorCadastrado);
                        }

                        break;

                    case 6:

                        Console.Clear();
                        Console.WriteLine("------------ LISTAGEM DE PRODUTOS ------------");

                        foreach (Produto produtoCadastrado in ProdutoDAO.ListagemDeProdutos())
                        {
                            Console.WriteLine("Produto: " + produtoCadastrado);
                        }

                        break;

                    case 7:
                        c = new Cliente();
                        v = new Vendedor();
                        p = new Produto();
                        venda = new Venda();
                        i = new ItemDeVenda();
                        e = new Endereco();
                        

                        Console.Clear();
                        Console.WriteLine("------------ REGISTRO DE VENDA ------------");

                        Console.WriteLine("\nInforme o CPF do cliente:");
                            c.Cpf = Console.ReadLine();
                        Cliente auxCliente = ClienteDAO.BuscarClientePorCPF(c);
                        if (auxCliente != null)
                        {
                            venda.Cliente = auxCliente;
                            Console.WriteLine("\nInforme o CPF do Vendedor:");
                            v.Cpf = Console.ReadLine();
                            Vendedor auxVendedor = VendedorDAO.BuscarVendedorPorCPF(v);
                            if (auxVendedor != null)
                            {
                                venda.Vendedor = auxVendedor;


                                Console.WriteLine("\nIforme o CEP da Venda:");
                                        e.CEP = Console.ReadLine();
                                Endereco auxEndereco = EnderecoDAO.BuscarEnderecoPorCEP(e);
                               
                                if (auxEndereco != null)
                                {
                                    venda.EnderecoDaVenda = auxEndereco;

                                    bool aux = true;
                                    do
                                    {
                                        i = new ItemDeVenda();
                                        p = new Produto();

                                        Console.WriteLine("\nDigite o Nome do Produto:");
                                        p.Nome = Console.ReadLine();

                                        Produto auxProduto = ProdutoDAO.BuscarProdutoPeloNome(p);

                                        if (auxProduto != null)
                                        {
                                            //ALIMENTA A CLASSE ITEMDEVENDA
                                            i.Produto = auxProduto;
                                            i.PrecoUnitario = auxProduto.Markup * auxProduto.Preco;
                                            venda.itens.Add(i) ;

                                            Console.WriteLine("\nDigite a Quantidade do Produto:");
                                            i.Quantidade = Convert.ToInt32(Console.ReadLine());

                                            
                                            Console.WriteLine("\nDeseja Adicionar um novo produto?");
                                            Console.WriteLine("\n\t1 - SIM");
                                            Console.WriteLine("\t2 - NÃO");
                                            int op = Convert.ToInt32(Console.ReadLine());

                                            switch (op)
                                            {
                                                case 1:
                                                    aux = true;
                                                    break;
                                                case 2:
                                                    aux = false;
                                                    break;
                                                default:
                                                    Console.WriteLine("\nOpção Invalida!");
                                                    aux = false;
                                                    break;
                                            }
                                        }


                                        else
                                        {
                                            Console.WriteLine("\nNome do Produto inválido!");
                                        }

                                    } while (aux);
                                }
                                else
                                {
                                    Console.WriteLine("\nNumero do CEP inválido!");
                                }
                                    //FINAL DA VENDA
                                    
                                    venda.Data = DateTime.Now;
                                    VendaDAO.SalvarVenda(venda);
                                    Console.WriteLine("\nRegistro de Venda Salvo com sucesso!:");
                            }
                            else
                            {
                                Console.WriteLine("\nNumero de CPF inválido!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nNumero de CPF inválido!");
                        }

                        break;

                    case 8:
                        totalItem = 0;
                        totalVenda = 0;
                        totalGeral = 0;
                        c = new Cliente();

                        Console.Clear();
                        Console.WriteLine("------------ LISTAGEM DE VENDAS ------------");

                        Console.WriteLine("\nInforme o CPF do cliente registrado na venda:");
                        c.Cpf = Console.ReadLine();

                        foreach (Venda vendaCadastrada in VendaDAO.BuscarVendaPorCliente(c))
                        {
                            totalVenda = 0;
                            Console.WriteLine("Cliente: " + vendaCadastrada.Cliente.Nome);
                            Console.WriteLine("Vendedor: " + vendaCadastrada.Vendedor.Nome);
                            Console.WriteLine("Data da venda: " + vendaCadastrada.Data);
                            Console.WriteLine("Endereço: " + vendaCadastrada.EnderecoDaVenda.Rua);

                            foreach (ItemDeVenda itemVendaCadastrado in vendaCadastrada.itens)
                            {
                                totalItem = itemVendaCadastrado.PrecoUnitario * itemVendaCadastrado.Quantidade;
                                Console.WriteLine("\n\tProduto: " + itemVendaCadastrado.Produto.Nome);
                                Console.WriteLine("\tPreço unitário: " + itemVendaCadastrado.PrecoUnitario.ToString("C2"));
                                Console.WriteLine("\tQuantidade: " + itemVendaCadastrado.Quantidade);
                                Console.WriteLine("\tTotal do item: " + totalItem.ToString("C2"));
                                totalVenda += totalItem;
                            }
                            Console.WriteLine("\n\tTotal da venda: " + totalVenda.ToString("C2"));
                            totalGeral += totalVenda;
                        }
                        Console.WriteLine("\nTotal geral: " + totalGeral.ToString("C2"));

                        break;

                    case 9:
                        totalItem = 0;
                        totalVenda = 0;
                        totalGeral = 0;

                        Console.Clear();
                        Console.WriteLine("------------ LISTAGEM DE VENDAS ------------");
                       
                        foreach (Venda vendaCadastrada1 in VendaDAO.RetornarLista())
                        {
                            totalVenda = 0;
                            Console.WriteLine("Cliente: " + vendaCadastrada1.Cliente.Nome);
                            Console.WriteLine("Vendedor: " + vendaCadastrada1.Vendedor.Nome);
                            Console.WriteLine("Data da venda: " + vendaCadastrada1.Data);
                            Console.WriteLine("Endereço: " + vendaCadastrada1.EnderecoDaVenda.Rua);
                            foreach (ItemDeVenda itemVendaCadastrado in vendaCadastrada1.itens)
                            {
                                totalItem = itemVendaCadastrado.PrecoUnitario * itemVendaCadastrado.Quantidade;
                                Console.WriteLine("\n\tProduto: " + itemVendaCadastrado.Produto.Nome);
                                Console.WriteLine("\tPreço unitário: " + itemVendaCadastrado.PrecoUnitario.ToString("C2"));
                                Console.WriteLine("\tQuantidade: " + itemVendaCadastrado.Quantidade);
                                Console.WriteLine("\tTotal do item: " + totalItem.ToString("C2"));
                                totalVenda += totalItem;
                            }
                            Console.WriteLine("\n\tTotal da venda: " + totalVenda.ToString("C2"));
                            totalGeral += totalVenda;
                        }
                        Console.WriteLine("\nTotal geral: " + totalGeral.ToString("C2"));

                        break;

                    case 10:
                        e = new Endereco();

                        Console.Clear();
                        Console.WriteLine("------------ CADASTRO DE ENDEREÇO ------------");

                        Console.WriteLine("\nDigite o CEP do endereço:");
                            e.CEP = Console.ReadLine();
                        Console.WriteLine("\nDigite o Nome da Rua:");
                            e.Rua = Console.ReadLine();

                        if (EnderecoDAO.SalvarEndereco(e))
                        {
                            Console.WriteLine("\nEndereço Cadastrado com Sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("\nNão foi possível Cadastrar o Endereço, CEP Inválido!");
                        }


                        break;

                    case 11:
                        totalItem = 0;
                        totalVenda = 0;
                        totalGeral = 0;
                        e = new Endereco();

                        Console.Clear();
                        Console.WriteLine("------------ LISTAGEM DE VENDAS ------------");

                        Console.WriteLine("\nDigite o CEP para busca: ");
                        e.CEP = Console.ReadLine();

                        foreach (Venda vendaCadastrada in VendaDAO.BuscarVendaPorEndereco(e))
                        {
                            totalVenda = 0;
                            Console.WriteLine("Cliente: " + vendaCadastrada.Cliente.Nome);
                            Console.WriteLine("Vendedor: " + vendaCadastrada.Vendedor.Nome);
                            Console.WriteLine("Data da venda: " + vendaCadastrada.Data);
                            foreach (ItemDeVenda itemVendaCadastrado in vendaCadastrada.itens)
                            {
                                totalItem = itemVendaCadastrado.PrecoUnitario * itemVendaCadastrado.Quantidade;
                                Console.WriteLine("\n\tProduto: " + itemVendaCadastrado.Produto.Nome);
                                Console.WriteLine("\tPreço unitário: " + itemVendaCadastrado.PrecoUnitario.ToString("C2"));
                                Console.WriteLine("\tQuantidade: " + itemVendaCadastrado.Quantidade);
                                Console.WriteLine("\tTotal do item: " + totalItem.ToString("C2"));
                                totalVenda += totalItem;
                            }
                            Console.WriteLine("\n\tTotal da venda: " + totalVenda.ToString("C2"));
                            totalGeral += totalVenda;
                        }
                        Console.WriteLine("\nTotal geral: " + totalGeral.ToString("C2"));

                        break;

                    //OPÇÃO DE SAIDA DO PROGRAMA
                    case 0:
                        Console.Clear();
                        Console.WriteLine("Encerrando ... ");
                        break;

                    //NENHUMA OPÇÃO DO MENU SELECIONADA
                    default:
                        Console.WriteLine("Opção Inválida!");
                        break;
                }

                Console.WriteLine("\n Precione qualquer tecla para continuar");
                Console.ReadKey();

            } while (opcao != 0);
        }
    }
}
