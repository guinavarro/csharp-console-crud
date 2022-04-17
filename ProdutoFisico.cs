using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestor_de_estoque
{
    [System.Serializable]
    internal class ProdutoFisico : Produto, IEstoque
    {
        enum Edit {nome = 1, preco, frete, estoque}

        public float frete;
        private int estoque;
        
        public ProdutoFisico(string nome, float preco, float frete)
        {
            this.nome = nome;
            this.preco = preco;
            this.frete = frete;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionar entrada no estoque do produto {nome}");
            Console.WriteLine("Digite a quantidade que você quer dar entrada: ");
            int entrada = int.Parse(Console.ReadLine());
            estoque += entrada;
            Console.WriteLine("Entrada registrada!");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar saída no estoque do produto {nome}");
            Console.WriteLine("Digite a quantidade que você quer dar baixa: ");
            int entrada = int.Parse(Console.ReadLine());
            estoque -= entrada;
            Console.WriteLine("Saída registrada!");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine("+-----------------------");
            Console.WriteLine($"|Produto: {nome}");
            Console.WriteLine($"|Preço: R${preco}");
            Console.WriteLine($"|Frete: R${frete}");
            Console.WriteLine($"|Em estoque: {estoque}");
            Console.WriteLine("+-----------------------");
        }

        public void EditarProduto()
        {
            Console.WriteLine($"Editando o produto {nome}");
            Console.WriteLine("O que você deseja editar no produto?");
            Console.WriteLine("1 - Nome\n2 - Preco\n3 - Frete\n4 - Estoque");

            int opt = int. Parse(Console.ReadLine());
            Edit escolha = (Edit)opt;

            switch (escolha)
            {
                case Edit.nome:
                    editarNome();
                    break;
                case Edit.preco:
                    editarPreco();
                    break;
                case Edit.frete:
                    editarFrete();
                    break;
                case Edit.estoque:
                    editarEstoque();
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

            void editarPreco()
            {
                Console.WriteLine($"Digite o novo preço para o produto: {nome}");
                float novoPreco = float.Parse(Console.ReadLine());
                preco = novoPreco;
                Console.WriteLine("Novo preço cadastrado com sucesso!");
                Console.ReadLine();
            }

            void editarFrete()
            {
                Console.WriteLine($"Digite o novo frete para o produto: {nome}");
                float novoFrete = float.Parse(Console.ReadLine());
                frete = novoFrete;
                Console.WriteLine("Novo frete cadastrado com sucesso!");
                Console.ReadLine();
            }

            void editarEstoque()
            {
                Console.WriteLine($"Digite a novo estoque para o produto: {nome}");
                int novaEstoque = int.Parse(Console.ReadLine());
                estoque = novaEstoque;
                Console.WriteLine("Novo estoque cadastrado com sucesso!");
                Console.ReadLine();
            }
        }
    }
}
