namespace GestaoDeEquipamentos.ConsoleApp
{
    public class Chamado
    {
        public int Id;
        public string Titulo;
        public string Descricao;
        public Equipamento Equipamento;
        public DateTime DataAbertura;

        public Chamado(string titulo, string descricao, Equipamento equipamento, DateTime dataAbertura)
        {
            Titulo = titulo;
            Descricao = descricao;
            Equipamento = equipamento;
            DataAbertura = dataAbertura;
        }

        public int ObterQuantidadeDias()
        {
            TimeSpan diasEmAberto = DateTime.Now - DataAbertura;
            
            return diasEmAberto.Days;
        }
    }
} 