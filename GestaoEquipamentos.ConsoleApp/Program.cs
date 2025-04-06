namespace GestaoDeEquipamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TelaEquipamento telaEquipamento = new TelaEquipamento();
            TelaChamado telaChamado = new TelaChamado(telaEquipamento);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Gestão de Equipamentos e Chamados");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Digite 1 para gerenciar equipamentos");
                Console.WriteLine("Digite 2 para gerenciar chamados");
                Console.WriteLine("Digite S para sair");
                Console.WriteLine("--------------------------------------------");

                Console.Write("Opção: ");
                string opcaoPrincipal = Console.ReadLine();

                if (opcaoPrincipal.Equals("s", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                if (opcaoPrincipal == "1")
                {
                    GerenciarEquipamentos(telaEquipamento);
                }
                else if (opcaoPrincipal == "2")
                {
                    GerenciarChamados(telaChamado);
                }
            }
        }

        private static void GerenciarEquipamentos(TelaEquipamento telaEquipamento)
        {
            string opcaoEquipamento;
            do
            {
                opcaoEquipamento = telaEquipamento.ApresentarMenu();

                switch (opcaoEquipamento)
                {
                    case "1":
                        telaEquipamento.CadastrarEquipamento();
                        break;

                    case "2":
                        telaEquipamento.EditarEquipamento();
                        break;

                    case "3":
                        telaEquipamento.ExcluirEquipamento();
                        break;

                    case "4":
                        telaEquipamento.VisualizarEquipamentos(true);
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Pressione enter para continuar...");
                Console.ReadLine();

            } while (opcaoEquipamento != "5");
        }

        private static void GerenciarChamados(TelaChamado telaChamado)
        {
            string opcaoChamado;
            do
            {
                opcaoChamado = telaChamado.ApresentarMenu();

                switch (opcaoChamado)
                {
                    case "1":
                        telaChamado.CadastrarChamado();
                        break;

                    case "2":
                        telaChamado.EditarChamado();
                        break;

                    case "3":
                        telaChamado.ExcluirChamado();
                        break;

                    case "4":
                        telaChamado.VisualizarChamados(true);
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Pressione enter para continuar...");
                Console.ReadLine();

            } while (opcaoChamado != "5");
        }
    }
}