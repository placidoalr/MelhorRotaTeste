
namespace MelhorRotaTeste.Services
{
    public class TravelService
    {
        private readonly RouteService _routeService;

        public TravelService(RouteService routeService)
        {
            _routeService = routeService;
        }

        public string FindBestRoute(string origin, string destination)
        {
            var routes = _routeService.GetRoutes();
            var vertices = routes.SelectMany(r => new[] { r.Origin, r.Destination }).Distinct().ToList();
            var edges = routes.Select(r => new { r.Origin, r.Destination, r.Cost }).ToList();

            var distances = vertices.ToDictionary(v => v, v => int.MaxValue);
            var predecessors = new Dictionary<string, string>();

            distances[origin] = 0;

            for (int i = 1; i < vertices.Count; i++)
            {
                foreach (var edge in edges)
                {
                    if (distances[edge.Origin] != int.MaxValue && distances[edge.Origin] + edge.Cost < distances[edge.Destination])
                    {
                        distances[edge.Destination] = distances[edge.Origin] + edge.Cost;
                        predecessors[edge.Destination] = edge.Origin;
                    }
                }
            }

            foreach (var edge in edges)
            {
                if (distances[edge.Origin] != int.MaxValue && distances[edge.Origin] + edge.Cost < distances[edge.Destination])
                {
                    throw new System.Exception("O grafo contém um ciclo de peso negativo.");
                }
            }

            var path = new Stack<string>();
            var current = destination;

            while (predecessors.ContainsKey(current))
            {
                path.Push(current);
                current = predecessors[current];
            }
            try
            {
            if (distances[destination] == int.MaxValue || distances[destination] == 0)
            {
                return $"Não há rota disponível de {origin} para {destination}";
            }
            }
            catch (Exception ex) {
                return $"Não há rota disponível de {origin} para {destination}";
            }

            path.Push(origin);

            return $"{string.Join(" - ", path)} ao custo de ${distances[destination]}";
        }
    }
}