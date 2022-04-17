using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
/*
Data: 16/04/2022
Nome: Guilherme da Silva Navarro
Baseado no Curso Guia do Programador
*/

namespace gestor_de_estoque
{
    internal class Program
    {
        static List<IEstoque> produtos = new List<IEstoque>();
        enum Menu { Listar = 1, Adicionar, Remover, Editar, Entrada, Saida, Sair }
        enum MenuProduto { Fisico = 1, Ebook, Curso}
        static void Main(string[] args)
        {
            Carregar();
            bool escolheuSair = false;
            while (escolheuSair == false)
            {
                Console.WriteLine("+----------------------------+");
                Console.WriteLine("|     Sistema de Estoque     |");
                Console.WriteLine("+----------------------------+");
                Console.WriteLine("1 - Listar Produtos\n2 - Cadastrar Produto\n3 - Remover Produto\n4 - Editar Produto\n5 - Registrar Entrada\n6 - Registrar Saída\n7 - SAIR");
                string opStr = Console.ReadLine();
                int opInt = int.Parse(opStr);

                if (opInt > 0 && opInt < 7)
                {
                    Menu escolha = (Menu)opInt;
                    switch (escolha)
                    {
                        case Menu.Listar:
                            Listagem();
                            break;
                        case Menu.Adicionar:
                            Cadastro();
                            break;
                        case Menu.Remover:
                            Remover();
                            break;
                        case Menu.Editar:
                            EditarProduto();
                            break;
                        case Menu.Entrada:
                            Entrada();
                            break;
                        case Menu.Saida:
                            Saida();
                            break;                            
                        case Menu.Sair:
                            escolheuSair = true;
                            break;
                    }
                }
                else
                {
                    escolheuSair = true;
                }
                Console.Clear();
            }
        }

        static void Listagem()
        {
            Console.WriteLine("Lista de Produtos");
            int i = 0;
            foreach(IEstoque produto in produtos)
            {
                Console.WriteLine("ID: " + i);
                produto.Exibir();
                i++;
            }
            Console.ReadLine();
        }

        static void Remover()
        {
            Listagem();
            Console.WriteLine("Digite o ID do elemento que você deseja remover:");
            int id = int.Parse(Console.ReadLine());
            if(id >= 0 && id < produtos.Count)
            {
                produtos.RemoveAt(id);
                Salvar();
            }
        }

        static void Entrada()
        {
            Listagem();
            Console.WriteLine("Digite o ID do elemento que você quer dar entrada:");
            int id = int.Parse(Console.ReadLine());
            if(id >=0 && id < produtos.Count)
            {
                produtos[id].AdicionarEntrada();
                Salvar();
            }
        }

        static void Saida()
        {
            Listagem();
            Console.WriteLine("Digite o ID do elemento que você quer dar baixa:");
            int id = int.Parse(Console.ReadLine());
            if (id >= 0 && id < produtos.Count)
            {
                produtos[id].AdicionarSaida();
                Salvar();
            }
        }
        static void Cadastro()
        {
            Console.WriteLine("Cadastro de Produtos");
            Console.WriteLine("1 - Produto Físico\n2 - E-Book\n3 - Curso ");
            string optStr = Console.ReadLine();
            int escolhaInt = int.Parse(optStr);

            MenuProduto escolhaP = (MenuProduto)escolhaInt;

            switch (escolhaP)
            {
                case MenuProduto.Fisico:
                    CadastrarPFisico();
                    break;
                case MenuProduto.Ebook:
                    CadastrarEbook();
                    break;
                case MenuProduto.Curso:
                    CadastrarCurso();
                    break;
            }
        }

        static void CadastrarPFisico()
        {
            Console.WriteLine("Cadastrando Produto Físico");
            Console.WriteLine("Digite o nome do produto:");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o preço do produto: R$");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Digite o valor do frete: R$");
            float frete = float.Parse(Console.ReadLine());

            ProdutoFisico pf = new ProdutoFisico(nome, preco, frete);
            produtos.Add(pf);
            Salvar();
        }

        static void CadastrarEbook()
        {
            Console.WriteLine("Cadastrando E-Book");
            Console.WriteLine("Digite o nome do E-Book:");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o preço do E-Book: R$");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Digite o nome do autor:");
            string autor = Console.ReadLine();

            Ebook eb = new Ebook(nome, preco, autor);
            produtos.Add(eb);
            Salvar();
        }

        static void CadastrarCurso()
        {
            Console.WriteLine("Cadastrando Curso");
            Console.WriteLine("Digite o nome do Curso:");
            string nome = Console.ReadLine();
            Console.WriteLine("Digite o preço do Curso: R$");
            float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Digite o nome do autor:");
            string autor = Console.ReadLine();

            Curso cs = new Curso(nome, preco, autor);
            produtos.Add(cs);
            Salvar();
        }

        static void Salvar()
        {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            encoder.Serialize(stream, produtos);
            stream.Close(); 
        }

        static void Carregar()
        {
            FileStream stream = new FileStream("produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            try
            {
                produtos = (List<IEstoque>)encoder.Deserialize(stream);

                if(produtos == null)
                {
                    produtos = new List<IEstoque>();
                }
            }
            catch(Exception e)
            {
                produtos = new List<IEstoque>();
            }

            stream.Close();
        }

        static void EditarProduto()
        {
            Listagem();
            Console.WriteLine("Editar informações do produto");
            Console.WriteLine("Digite o ID do produto que você deseja editar:");
            int prodId = int.Parse(Console.ReadLine());

            produtos[prodId].EditarProduto();
            Salvar();
        }
    }
}
