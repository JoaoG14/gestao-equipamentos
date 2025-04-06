namespace GestaoDeEquipamentos.ConsoleApp
{
    public class TelaChamado
    {
        public Chamado[] chamados = new Chamado[100];
        public int contadorChamados = 0;
        private TelaEquipamento telaEquipamento;

        public TelaChamado(TelaEquipamento telaEquipamento)
        {
            this.telaEquipamento = telaEquipamento;
        }

        public string ApresentarMenu()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Gestão de Chamados");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("Escolha a operação desejada:");
            Console.WriteLine("1 - Cadastro de Chamado");
            Console.WriteLine("2 - Edição de Chamado");
            Console.WriteLine("3 - Exclusão de Chamado");
            Console.WriteLine("4 - Visualização de Chamados");
            Console.WriteLine("5 - Voltar ao menu principal");
            Console.WriteLine("--------------------------------------------");

            Console.Write("Digite um opção válida: ");
            string opcaoEscolhida = Console.ReadLine();

            return opcaoEscolhida;
        }

        public void CadastrarChamado()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Gestão de Chamados");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("Cadastrando Chamado...");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine();

            Console.Write("Digite o título do chamado: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite a descrição do chamado: ");
            string descricao = Console.ReadLine();

            Console.WriteLine();
            telaEquipamento.VisualizarEquipamentos(false);
            Console.WriteLine();

            Console.Write("Digite o ID do equipamento para este chamado: ");
            int idEquipamento = Convert.ToInt32(Console.ReadLine());

            Equipamento equipamentoSelecionado = null;

            for (int i = 0; i < telaEquipamento.equipamentos.Length; i++)
            {
                if (telaEquipamento.equipamentos[i] != null && telaEquipamento.equipamentos[i].Id == idEquipamento)
                {
                    equipamentoSelecionado = telaEquipamento.equipamentos[i];
                    break;
                }
            }

            if (equipamentoSelecionado == null)
            {
                Console.WriteLine("Equipamento não encontrado!");
                return;
            }

            DateTime dataAbertura = DateTime.Now;

            Chamado novoChamado = new Chamado(titulo, descricao, equipamentoSelecionado, dataAbertura);
            novoChamado.Id = GeradorIds.GerarIdChamado();

            chamados[contadorChamados++] = novoChamado;

            Console.WriteLine();
            Console.WriteLine("Chamado cadastrado com sucesso!");
        }

        public void EditarChamado()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Gestão de Chamados");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("Editando Chamado...");
            Console.WriteLine("--------------------------------------------");

            VisualizarChamados(false);

            Console.Write("Digite o ID do chamado que deseja selecionar: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();

            Console.Write("Digite o título do chamado: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite a descrição do chamado: ");
            string descricao = Console.ReadLine();

            Console.WriteLine();
            telaEquipamento.VisualizarEquipamentos(false);
            Console.WriteLine();

            Console.Write("Digite o ID do equipamento para este chamado: ");
            int idEquipamento = Convert.ToInt32(Console.ReadLine());

            Equipamento equipamentoSelecionado = null;

            for (int i = 0; i < telaEquipamento.equipamentos.Length; i++)
            {
                if (telaEquipamento.equipamentos[i] != null && telaEquipamento.equipamentos[i].Id == idEquipamento)
                {
                    equipamentoSelecionado = telaEquipamento.equipamentos[i];
                    break;
                }
            }

            if (equipamentoSelecionado == null)
            {
                Console.WriteLine("Equipamento não encontrado!");
                return;
            }

            bool conseguiuEditar = false;

            for (int i = 0; i < chamados.Length; i++)
            {
                if (chamados[i] == null) continue;

                else if (chamados[i].Id == idSelecionado)
                {
                    chamados[i].Titulo = titulo;
                    chamados[i].Descricao = descricao;
                    chamados[i].Equipamento = equipamentoSelecionado;
                    
                    conseguiuEditar = true;
                }
            }

            if (!conseguiuEditar)
            {
                Console.WriteLine("Houve um erro durante a edição do chamado...");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("O chamado foi editado com sucesso!");
        }

        public void ExcluirChamado()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Gestão de Chamados");
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("Excluindo Chamado...");
            Console.WriteLine("--------------------------------------------");

            VisualizarChamados(false);

            Console.Write("Digite o ID do chamado que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = false;

            for (int i = 0; i < chamados.Length; i++)
            {
                if (chamados[i] == null) continue;

                else if (chamados[i].Id == idSelecionado)
                {
                    chamados[i] = null;
                    conseguiuExcluir = true;
                }
            }

            if (!conseguiuExcluir)
            {
                Console.WriteLine("Houve um erro durante a exclusão do chamado...");
                return;
            }

            Console.WriteLine();
            Console.WriteLine("O chamado foi excluído com sucesso!");
        }

        public void VisualizarChamados(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                Console.Clear();
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Gestão de Chamados");
                Console.WriteLine("--------------------------------------------");

                Console.WriteLine("Visualizando Chamados...");
                Console.WriteLine("--------------------------------------------");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -30} | {2, -20} | {3, -20} | {4, -15}",
                "Id", "Título", "Equipamento", "Data de Abertura", "Dias em Aberto"
            );

            for (int i = 0; i < chamados.Length; i++)
            {
                Chamado c = chamados[i];

                if (c == null) continue;

                Console.WriteLine(
                    "{0, -10} | {1, -30} | {2, -20} | {3, -20} | {4, -15}",
                    c.Id, c.Titulo, c.Equipamento.Nome, c.DataAbertura.ToShortDateString(), c.ObterQuantidadeDias()
                );
            }

            Console.WriteLine();
        }
    }
} 