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

            do
            {
                ExibirMenu();
                Console.Write("ESCOLHA UM DIGITO: ");
                menu = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (menu)
                {
                    case 1:
                        CadastrarProdutos(produtos, precos, qtdProdutos);
                        Console.Clear();
                        ; break;
                    case 2:
                        ConsultarProdutos(produtos, precos, qtdProdutos);
                        break;

                    // COMPRA
                    case 3:
                        ComprarProdutos(produtos, precos, qtdProdutos);
                        ; break;

                    // FINALIZAR COMPRA
                    case 4:
                        Console.WriteLine($"TOTAL DA COMPRA: {carrinho}");
                        ; break;
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

        public static void CadastrarProdutos(List<string> produtos, List<decimal> precos, List<int> qtdProdutos)
        {
            Console.Write("PRODUTO: ");
            produtos.Add(Console.ReadLine().ToLower());
            Console.Write("PREÇO: ");
            precos.Add(decimal.Parse(Console.ReadLine()));
            Console.Write("QUANTIDADE EM ESTOQUE: ");
            qtdProdutos.Add(int.Parse(Console.ReadLine()));
        }

        public static void ConsultarProdutos(List<string> produtos, List<decimal> precos, List<int> qtdProdutos)
        {
            bool validar = false;
            while (!validar)
            { }

            Console.Write("DIGITE O PRODUTO: ");
            string? buscar = Console.ReadLine().ToLower();
            if (string.TryParse(Console.ReadLine().ToLower(), out string? buscar))
            {
                validar = true;
            }
            else
            {
                validar = false;
            }


            int tamanho = produtos.Count; // tamanho da lista

            if (buscar == "todos")
            {
                for (int i = 0; i < tamanho; i++)
                {
                    Console.WriteLine($"PRODUTO: {produtos[i]} | PREÇO: {precos[i]}|QUANTIDADE EM ESTOQUE: {qtdProdutos[i]}");
                }
                Console.WriteLine("");
            }
            else
            {
                for (int i = 0; i < tamanho; i++)
                {
                    if (buscar == produtos[i])
                    {
                        Console.WriteLine($"PRODUTO: {produtos[i]} | PREÇO: {precos[i]} | QUANTIDADE EM ESTOQUE: {qtdProdutos[i]}");
                        Console.WriteLine("DESEJA CONSULTAR OUTRO PRODUTO?");
                        Console.Write("(S)SIM (N)NÃO => ");
                        string? escolha = Console.ReadLine().ToLower();
                        if (escolha == "s")
                        {
                            Console.Clear();
                            ConsultarProdutos(produtos, precos, qtdProdutos);
                        }
                        else if (escolha == "n")
                        {
                            Console.Clear();
                            ExibirMenu();
                        }
                        else
                        {
                            Console.WriteLine("OPÇÃO INVÁLIDA!!!");
                            Console.ReadKey();
                            Console.Clear();
                            i = -1;
                            continue;
                        }
                    }
                }
            }
            if (buscar != null && buscar != "todos")
            {
                Console.WriteLine("PRODUTO NÃO CADASTRADO!!!");
                ConsultarProdutos(produtos, precos, qtdProdutos);
            }
        }

        public static void ComprarProdutos(List<string> produtos, List<decimal> precos, List<int> qtdProdutos)
        {
            foreach (var produto in produtos)
            {
                Console.WriteLine($"PRODUTO: {produto}| PREÇO: {precos[count]}");
            }
            string? compra = null;

            while (compra == null)
            {
                Console.Write("ADD PRODUTO NO CARRINHO: ");
                compra = Console.ReadLine();

                int count = 0;
                foreach (var produto in produtos)
                {
                    if (compra != produto)
                    {
                        count++;
                        continue;
                    }
                    else if (qtdProdutos[count] == 0)
                    {
                        Console.WriteLine($"!!! PRODUTO: {produto} ESGOTADO !!!");
                        Console.Write("ADD MAIS PRODUTOS NO CARRINHO: (S)SIM (N)NÃO");
                        compra = Console.ReadLine();
                        if (compra == "S")
                            compra = null;
                        else if (compra == "N")
                            compra = "N";
                        break;
                    }
                    else if (compra == produto && qtdProdutos[count] > 0)
                    {
                        carrinho = carrinho + precos[count];
                        qtdProdutos[count] = qtdProdutos[count] - 1;
                        Console.Write("ADD MAIS PRODUTOS NO CARRINHO: (S)SIM (N)NÃO");
                        compra = Console.ReadLine();
                        if (compra == "S")
                            compra = null;
                        else if (compra == "N")
                            compra = "N";
                        break;
                    }
                    else
                        count++;
                }
            }
        }
    }
}
