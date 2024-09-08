namespace DesafioProjetoHospedagem.Models
{
    public class Suite
    {
        public Suite() { }

        public Suite(string tipoSuite, int capacidade, decimal valorDiaria)
        {
            TipoSuite = tipoSuite;
            Capacidade = capacidade;
            ValorDiaria = valorDiaria;
        }

        public string TipoSuite { get; set; }
        public int Capacidade { get; set; }
        public decimal ValorDiaria { get; set; }

        public void ImprimeDadosSuite()
        {
            Console.WriteLine("Suite: " + TipoSuite);
            Console.WriteLine("Capacidade: " + Capacidade);
            Console.WriteLine("Valor Diária: " + ValorDiaria);
            Console.WriteLine("-----------------------------");
        }
    }
}