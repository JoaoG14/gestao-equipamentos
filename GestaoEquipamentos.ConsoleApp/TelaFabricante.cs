namespace GestaoDeEquipamentos.ConsoleApp
{
    public class TelaFabricante
    {
        public Fabricante[] fabricantes = new Fabricante[100];
        public int contadorFabricantes = 0;
        private TelaEquipamento telaEquipamento;

        public TelaFabricante(TelaEquipamento telaEquipamento)
        {
            this.telaEquipamento = telaEquipamento;
        }

        public string ApresentarMenu()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Gestão de Fabricantes");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("Escolha a operação desejada:");
            Console.WriteLine("1 - Cadastro de Fabricante");
            Console.WriteLine("2 - Edição de Fabricante");
            Console.WriteLine("3 - Exclusão de Fabricante");
            Console.WriteLine("4 - Visualização de Fabricantes");
            Console.WriteLine("5 - Voltar ao menu principal");
            Console.WriteLine("--------------------------------------------");

            Console.Write("Digite um opção válida: ");
            string opcaoEscolhida = Console.ReadLine();

            return opcaoEscolhida;
        }

        public void CadastrarFabricante()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Gestão de Fabricantes");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("Cadastrando Fabricante...");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine();

            Console.Write("Digite o nome do fabricante: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o email do fabricante: ");
            string email = Console.ReadLine();

            Console.Write("Digite o telefone do fabricante: ");
            string telefone = Console.ReadLine();

            Fabricante novoFabricante = new Fabricante(nome, email, telefone);
            novoFabricante.Id = GeradorIds.GerarIdFabricante();

            fabricantes[contadorFabricantes++] = novoFabricante;

            Console.WriteLine();
            Console.WriteLine("Fabricante cadastrado com sucesso!");
        }

        public void EditarFabricante()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Gestão de Fabricantes");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("Editando Fabricante...");
            Console.WriteLine("--------------------------------------------");

            VisualizarFabricantes(false);

            Console.Write("Digite o ID do fabricante que deseja editar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Digite o nome do fabricante: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o email do fabricante: ");
            string email = Console.ReadLine();

            Console.Write("Digite o telefone do fabricante: ");
            string telefone = Console.ReadLine();

            bool conseguiuEditar = false;

            for (int i = 0; i < fabricantes.Length; i++)
            {
                if (fabricantes[i] == null) continue;

                else if (fabricantes[i].Id == idSelecionado)
                {
                    fabricantes[i].Nome = nome;
                    fabricantes[i].Email = email;
                    fabricantes[i].Telefone = telefone;
                    
                    conseguiuEditar = true;
                }
            }

            if (!conseguiuEditar)
            {
                Console.WriteLine("Houve um erro durante a edição do fabricante...");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("O fabricante foi editado com sucesso!");
        }

        public void ExcluirFabricante()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Gestão de Fabricantes");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("Excluindo Fabricante...");
            Console.WriteLine("--------------------------------------------");

            VisualizarFabricantes(false);

            Console.Write("Digite o ID do fabricante que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = false;

            for (int i = 0; i < fabricantes.Length; i++)
            {
                if (fabricantes[i] == null) continue;

                else if (fabricantes[i].Id == idSelecionado)
                {
                    fabricantes[i] = null;
                    conseguiuExcluir = true;
                }
            }

            if (!conseguiuExcluir)
            {
                Console.WriteLine("Houve um erro durante a exclusão do fabricante...");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("O fabricante foi excluído com sucesso!");
        }

        public void VisualizarFabricantes(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                Console.Clear();
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Gestão de Fabricantes");
                Console.WriteLine("--------------------------------------------");

                Console.WriteLine("Visualizando Fabricantes...");
                Console.WriteLine("--------------------------------------------");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -20} | {2, -30} | {3, -15} | {4, -10}",
                "Id", "Nome", "Email", "Telefone", "Equipamentos"
            );

            for (int i = 0; i < fabricantes.Length; i++)
            {
                Fabricante f = fabricantes[i];

                if (f == null) continue;

                int qtdEquipamentos = ContarEquipamentosPorFabricante(f.Nome);

                Console.WriteLine(
                    "{0, -10} | {1, -20} | {2, -30} | {3, -15} | {4, -10}",
                    f.Id, f.Nome, f.Email, f.Telefone, qtdEquipamentos
                );
            }

            Console.WriteLine();
        }

        public Fabricante ObterFabricantePorNome(string nomeFabricante)
        {
            for (int i = 0; i < fabricantes.Length; i++)
            {
                if (fabricantes[i] != null && fabricantes[i].Nome == nomeFabricante)
                {
                    return fabricantes[i];
                }
            }

            return null;
        }

        private int ContarEquipamentosPorFabricante(string nomeFabricante)
        {
            int quantidade = 0;

            for (int i = 0; i < telaEquipamento.equipamentos.Length; i++)
            {
                if (telaEquipamento.equipamentos[i] != null && 
                    telaEquipamento.equipamentos[i].Fabricante == nomeFabricante)
                {
                    quantidade++;
                }
            }

            return quantidade;
        }
    }
} 