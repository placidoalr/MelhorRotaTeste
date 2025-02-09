using MelhorRotaTeste.Models;
using Microsoft.AspNetCore.Routing;
namespace MelhorRotaTeste.Services
{
    public class RouteService
    {
        private readonly string _filePath;

        public RouteService(string filePath)
        {
            _filePath = filePath;
        }

        public RouteService(List<RouteModel> routes, string filePath)
        {
            _filePath = filePath;
            using (var writer = new StreamWriter(_filePath, true))
            {
                foreach (var route in routes)
                {
                    writer.WriteLine($"{route.Origin},{route.Destination},{route.Cost}");
                }
            }
        }

        public List<RouteModel> GetRoutes()
        {
            var routes = new List<RouteModel>();
            foreach (var line in File.ReadLines(_filePath))
            {
                var parts = line.Split(',');
                routes.Add(new RouteModel(parts[0], parts[1], int.Parse(parts[2])));
            }
            return routes;
        }

        public void AddRoute(RouteModel route)
        {
            using (var writer = new StreamWriter(_filePath, true))
            {
                writer.WriteLine($"{route.Origin},{route.Destination},{route.Cost}");
            }
        }
    }
}