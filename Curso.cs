using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestor_de_estoque
{
    [System.Serializable]
    internal class Curso : Produto, IEstoque
    {
        enum Edit { nome = 1, autor, preco, vaga }

        public string autor;
        private int vagas;

        public Curso(string nome, float preco, string autor)
        {
            this.nome = nome;
            this.preco = preco;
            this.autor = autor;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionar vagas no curso {nome}");
            Console.WriteLine("Digite a quantidade de vagas que você quer dar entrada: ");
            int entrada = int.Parse(Console.ReadLine());
            vagas += entrada;
            Console.WriteLine("Entrada registrada!");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Consumir vagas do curso {nome}");
            Console.WriteLine("Digite a quantidade que você quer consumir: ");
            int entrada = int.Parse(Console.ReadLine());
            vagas -= entrada;
            Console.WriteLine("Saída registrada!");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine("+------------------------");
            Console.WriteLine($"|Curso: {nome}");
            Console.WriteLine($"|Autor: {autor}");
            Console.WriteLine($"|Preço: R${preco}");
            Console.WriteLine($"|Vagas Restantes:{vagas}");
            Console.WriteLine("+------------------------");
        }

        public void EditarProduto()
        {
            Console.WriteLine($"Editando o curso {nome}");
            Console.WriteLine("O que você deseja editar no produto?");
            Console.WriteLine("1 - Nome\n2 - Autor\n3 - Preco\n4 - Vagas");

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
                case Edit.vaga:
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
                Console.WriteLine($"Digite a nova quantidade de vagas para o produto: {nome}");
                int novaVaga = int.Parse(Console.ReadLine());
                vagas = novaVaga;
                Console.WriteLine("Nova vaga cadastrado com sucesso!");
                Console.ReadLine();
            }
        }
    }
}
