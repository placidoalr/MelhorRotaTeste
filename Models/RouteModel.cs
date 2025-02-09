namespace MelhorRotaTeste.Models
{
    public class RouteModel
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public int Cost { get; set; }

        public RouteModel(string origin, string destination, int cost)
        {
            Origin = origin;
            Destination = destination;
            Cost = cost;
        }
    }
}
