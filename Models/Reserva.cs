namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes()
        {
            Hospedes = new List<Pessoa>();
            if (Suite.Capacidade >= ObterQuantidadeHospedes())
            {
                for (int i=0; i< Suite.Capacidade; i++)
                {
                    Console.WriteLine("Cadastrar Hóspede");
                    Console.WriteLine("Registrar nome 'fim' a qualquer momento para concluir cadastros.");
                    Pessoa hospede = new Pessoa();
                    
                    Console.WriteLine("Nome: ");
                    hospede.Nome = Console.ReadLine();
                    Console.WriteLine("Sobrenome: ");
                    hospede.Sobrenome = Console.ReadLine();

                    if(hospede.Nome == "fim" || hospede.Sobrenome == "fim")
                    {
                        i = Suite.Capacidade;
                        Console.WriteLine("Cadastro finalizado");
                    }
                    else
                    {
                        Hospedes.Add(hospede);
                    }
                }
            }
            else
            {
                Hospedes = null;
                throw new Exception("Capacidade máxima de hóspedes não permitida.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
            CadastrarHospedes();
        }

        public int ObterQuantidadeHospedes()
        {
            int quantidadeHospedes = 0;
            if(Hospedes != null)
            {
                quantidadeHospedes = Hospedes.Count > 0 ? Hospedes.Count : 0;
            }
            return quantidadeHospedes;
        }

        public void ImprimirReserva()
        {
            Console.WriteLine("Suite: " + Suite.TipoSuite);
            Console.WriteLine("Hóspedes: " + ObterQuantidadeHospedes());
            Console.WriteLine("Dia reservados: " + DiasReservados);
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = DiasReservados >= 10 ? DiasReservados * Suite.ValorDiaria * 9/10 : DiasReservados * Suite.ValorDiaria;

            return valor;
        }

        public void ListarHospedes()
        {
            if(Hospedes != null)
            {
                for(int i = 0; i < Hospedes.Count; i++)
                {
                    Console.WriteLine(Hospedes[i].ImprimirPessoa());
                }
            }
            else
            {
                throw new Exception("Nenhuma pessoa nesta reserva.");
            }
        }
    }
}