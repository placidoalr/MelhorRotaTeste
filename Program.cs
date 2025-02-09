using MelhorRotaTeste.Models;
using MelhorRotaTeste.Services;

public class Program
{
    static void Main()
    {
        string filePath = "routes.txt";
        var routeService = new RouteService(filePath);
        var travelService = new TravelService(routeService);

        while (true)
        {
            Console.WriteLine("Digite a ação desejada: 1 para registrar nova rota, 2 para consultar melhor rota, 0 para sair:");
            try
            {

                int action = int.Parse(Console.ReadLine());
                if (action == 0)
                {
                    break;
                }
                else if (action == 1)
                {
                    Console.WriteLine("Digite a rota no formato Origem,Destino,Valor (ex: GRU,BRC,10):");
                    var input = Console.ReadLine();
                    var parts = input.Split(',');
                    var route = new RouteModel(parts[0], parts[1], int.Parse(parts[2]));
                    routeService.AddRoute(route);
                }
                else if (action == 2)
                {
                    Console.WriteLine("Digite a rota no formato Origem-Destino (ex: GRU-CDG):");
                    var input = Console.ReadLine();
                    var parts = input.Split('-');
                    string origin = parts[0];
                    string destination = parts[1];

                    var result = travelService.FindBestRoute(origin, destination);

                    Console.WriteLine(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("A opção digitada não atende aos requisitos, tente novamente.");

            }

        }
    }
}
