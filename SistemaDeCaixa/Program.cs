namespace SistemaDeCaixa
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int menu = 0;
            decimal carrinho = 0;

            List<string> produtos = new();
            List<decimal> precos = new();
            List<int> qtdProdutos = new();
            List<int> codigos = new();

            do
            {
                ExibirMenu();
                Console.Write("ESCOLHA UM DIGITO: ");
                menu = int.Parse(Console.ReadLine());
          
                Console.Clear();
                switch (menu)
                {
                    case 1:
                        CadastrarProdutos(codigos, produtos, precos, qtdProdutos);
                        Console.Clear();
                        ; break;
                    case 2:
                        ConsultarProdutos(produtos, precos, qtdProdutos);
                        break;

                    // COMPRA
                    case 3:
                        carrinho = ComprarProdutos(carrinho, codigos, produtos, precos, qtdProdutos);
                        ; break;

                    // FINALIZAR COMPRA
                    case 4:
                        Console.WriteLine($"TOTAL DA COMPRA: {carrinho}");
                        break;
                    case 5:
                        break;
                    default:
                        Console.WriteLine("VALOR INVALIDO !!!");
                        break;
                }
            } while (menu < 5);
        }

        public static void ExibirMenu()
        {
            Console.WriteLine();
            Console.WriteLine("------- MENU -------");
            Console.WriteLine("1.CADASTRAR PRODUTOS");
            Console.WriteLine("2.CONSULTA PRODUTOS");
            Console.WriteLine("3.COMPRAR PRODUTOS");
            Console.WriteLine("4.FINALIZAR COMPRA");
            Console.WriteLine("5.SAIR");
            Console.WriteLine("--------------------");
            Console.WriteLine();
        }

        public static void CadastrarProdutos(List<int> codigos, List<string> produtos, List<decimal> precos, List<int> qtdProdutos)
        {
            Console.Write("CODIGO DO PRODUTO: ");
            codigos.Add(int.Parse(Console.ReadLine()));
            Console.Write("PRODUTO: ");
            produtos.Add(Console.ReadLine().ToLower());
            Console.Write("PREÇO: ");
            precos.Add(decimal.Parse(Console.ReadLine()));
            Console.Write("QUANTIDADE EM ESTOQUE: ");
            qtdProdutos.Add(int.Parse(Console.ReadLine()));
        }

        public static void ConsultarProdutos(List<string> produtos, List<decimal> precos, List<int> qtdProdutos)
        {
            Console.Write("DIGITE O PRODUTO: ");
            string? buscar = Console.ReadLine().ToLower();

            int tamanho = produtos.Count; // tamanho da lista

            if (buscar == "todos")
            {
                for (int i = 0; i < tamanho; i++)
                {
                    Console.WriteLine($"PRODUTO: {produtos[i]} | PREÇO: {precos[i]}|QUANTIDADE EM ESTOQUE: {qtdProdutos[i]}");
                }
                Console.WriteLine("");
            }
            else if (buscar != null)
            {
                for (int i = 0; i < tamanho; i++)
                {
                    if (buscar == produtos[i])
                    {
                        Console.WriteLine($"PRODUTO: {produtos[i]} | PREÇO: {precos[i]} | QUANTIDADE EM ESTOQUE: {qtdProdutos[i]}");
                        Console.WriteLine("DESEJA CONSULTAR OUTRO PRODUTO?");
                        Console.Write("(S)SIM (N)NÃO => ");
                        char? escolha = char.Parse(Console.ReadLine().ToLower());
                        if (escolha == 's')
                        {
                            Console.Clear();
                            ConsultarProdutos(produtos, precos, qtdProdutos);
                        }
                        else if (escolha == 'n')
                        {
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("OPÇÃO INVÁLIDA!!!");
                            Console.ReadKey();
                            Console.Clear();
                        }
                    }
                    else
                    {
                        Console.WriteLine("PRODUTO NÃO CADASTRADO!!!");
                        ConsultarProdutos(produtos, precos, qtdProdutos);
                    }

                }
            }
        }

        public static decimal ComprarProdutos(decimal carrinho, List<int> codigos, List<string> produtos, List<decimal> precos, List<int> qtdProdutos)
        {
            for (int i = 0; i < produtos.Count; i++)
            {
                Console.WriteLine($"CODIGO: {codigos[i]} | PRODUTO: {produtos[i]} | PREÇO: {precos[i]}");
            }
            
            char compra = 's';
            while (compra == 's')
            {
                Console.Write("ADD PRODUTO NO CARRINHO (DIGITE O CODIGO): ");
                int id = int.Parse(Console.ReadLine());

                for (int i = 0; i < produtos.Count; i++)
                {
                    if (id != codigos[i])
                    {
                        continue;
                    }
                    else if (qtdProdutos[i] == 0)
                    {
                        Console.WriteLine($"!!! PRODUTO: {produtos[i]} ESGOTADO !!!");
                        Console.Write("ADD MAIS PRODUTOS NO CARRINHO: (S)SIM (N)NÃO");
                        compra = char.Parse(Console.ReadLine().ToLower());
                        if (compra == 's')
                            ComprarProdutos(carrinho, codigos, produtos, precos, qtdProdutos);
                        else if (compra == 'n')
                            return carrinho;
                    }
                    else if (id == codigos[i] && qtdProdutos[i] > 0)
                    {
                        carrinho = carrinho + precos[i];
                        qtdProdutos[i] = qtdProdutos[i] - 1;
                        Console.Write("ADD MAIS PRODUTOS NO CARRINHO: (S)SIM (N)NÃO");
                        compra = char.Parse(Console.ReadLine().ToLower());
                        if (compra == 's')
                            ComprarProdutos(carrinho, codigos, produtos, precos, qtdProdutos);
                        else if (compra == 'n')
                            return carrinho;
                    }
                }             
            }
            return carrinho;
        }
    }
}
