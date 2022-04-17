using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestor_de_estoque
{
    [System.Serializable]
    internal class Ebook : Produto, IEstoque
    {
        enum Edit { nome = 1, autor, preco, venda }

        public string autor;
        private int vendas;

        public Ebook(string nome, float preco, string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine("Não é possivel dar entrada no estoque de um E-Book, pois é um produto digital!");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar vendas no E-Book {nome}");
            Console.WriteLine("Digite a quantidade de vendas que você quer dar entrada: ");
            int entrada = int.Parse(Console.ReadLine());
            vendas += entrada;
            Console.WriteLine("Entrada registrada!");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine("+-----------------------");
            Console.WriteLine($"|E-Book: {nome}");
            Console.WriteLine($"|Autor: {autor}");
            Console.WriteLine($"|Preço: R${preco}");
            Console.WriteLine($"|Vendas: {vendas}");
            Console.WriteLine("+-----------------------");
        }

        public void EditarProduto()
        {
            Console.WriteLine($"Editando o e-book {nome}");
            Console.WriteLine("O que você deseja editar no produto?");
            Console.WriteLine("1 - Nome\n2 - Autor\n3 - Preco\n4 - Vendas");

            int opt = int.Parse(Console.ReadLine());
            Edit escolha = (Edit)opt;

            switch (escolha)
            {
                case Edit.nome:
                    editarNome();
                    break;
                case Edit.autor:
                    editarAutor();
                    break;
                case Edit.preco:
                    editarPreco();
                    break;
                case Edit.venda:
                    editarVenda();
                    break;
            }

            void editarNome()
            {
                Console.WriteLine($"Digite o novo nome para o produto: {nome}");
                string novoNome = Console.ReadLine();
                nome = novoNome;
                Console.WriteLine("Novo nome cadastrado com sucesso!");
                Console.ReadLine();
            }

            void editarAutor()
            {
                Console.WriteLine($"Digite o novo nome do autor para o e-book: {nome}");
                string novoAutor = Console.ReadLine();
                autor = novoAutor;
                Console.WriteLine("Novo nome de autor cadastrado com sucesso!");
                Console.ReadLine();
            }

            void editarPreco()
            {
                Console.WriteLine($"Digite o novo preço para o produto: {nome}");
                float novoPreco = float.Parse(Console.ReadLine());
                preco = novoPreco;
                Console.WriteLine("Novo preço cadastrado com sucesso!");
                Console.ReadLine();
            }

            void editarVenda()
            {
                Console.WriteLine($"Digite a nova venda para o produto: {nome}");
                int novaVenda = int.Parse(Console.ReadLine());
                vendas = novaVenda;
                Console.WriteLine("Nova venda cadastrado com sucesso!");
                Console.ReadLine();
            }
        }
    }
}
