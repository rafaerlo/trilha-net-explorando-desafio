using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;
string option = "2";
List<Suite> suites = new List<Suite>();
List<Reserva> reservas = new List<Reserva>();

while (option != "0")
{
    Console.WriteLine("Sistema de Hospedagem");
    Console.WriteLine("Selecione uma opção:");
    Console.WriteLine("1 - Cadastrar Suite");

    if (suites.Count > 0)
    {
        Console.WriteLine("2 - Listar Suites");
        Console.WriteLine("3 - Fazer reserva");
        Console.WriteLine("4 - Listar reservas");
        Console.WriteLine("5 - Consultar reserva");
    }

    Console.WriteLine("0 - Encerrar");
    option = Console.ReadLine();

    switch (option)
    {
        case "1": Console.WriteLine("Cadastrar Suite"); CadastrarSuite(); break;
        case "2": Console.WriteLine("Listar Suites"); ListarSuites(); break;
        case "3": Console.WriteLine("Fazer reserva"); FazerReserva(); break;
        case "4": Console.WriteLine("Listar reserva"); ListarReservas(); break;
        case "5": Console.WriteLine("Consultar reserva"); ConsultarReserva(); break;
        case "0": Console.WriteLine("Encerrar"); break;
        default: Console.WriteLine("-"); break;
    }
}

void CadastrarSuite()
{
    Suite suite = new Suite();
    Console.WriteLine("Tipo da Suite:");
    suite.TipoSuite = Console.ReadLine();
    Console.WriteLine("Capacidade:");
    suite.Capacidade = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Valor da Diária:");
    suite.ValorDiaria = Convert.ToDecimal(Console.ReadLine());

    suites.Add(suite);
    Console.WriteLine("Suite cadastrada");
}

void ListarSuites()
{
    for(int i = 0; i < suites.Count; i++)
    {
        Console.WriteLine("Código: " + i);
        suites[i].ImprimeDadosSuite();
    }
}

void FazerReserva()
{
    Console.WriteLine("Informe código da suite: ");
    int index = Convert.ToInt32(Console.ReadLine());
    Suite suite = suites.Count > index ? suites[index] : null ;

    if(suite != null)
    {
        Reserva reserva = new Reserva();
        reserva.CadastrarSuite(suite);
        Console.WriteLine("Quantos dias quer reservar?");
        reserva.DiasReservados = Convert.ToInt32(Console.ReadLine());
        reservas.Add(reserva);
    }
    else
    {
        Console.WriteLine("Suite não localizada");
    }
}

void ListarReservas()
{
    Console.WriteLine("Listar Reservas");

    if(reservas.Count > 0)
    {
        for(int i=0; i < reservas.Count; i++)
        {
            reservas[i].ImprimirReserva();
            Console.WriteLine("");
        }
        Console.WriteLine("--------------------");
    }
}

void ConsultarReserva()
{
    Console.WriteLine("Consular Reserva");
    Console.WriteLine("Qual o código da Reserva?");
    int index = Convert.ToInt32(Console.ReadLine());

    if(reservas != null)
    {
        Console.WriteLine("Localizada");
        reservas[index].ImprimirReserva();
        Console.WriteLine("Valor total: " + reservas[index].CalcularValorDiaria());
        
    }
    else
    {
        throw new Exception("Nenhuma reserva disponível.");
    }
}