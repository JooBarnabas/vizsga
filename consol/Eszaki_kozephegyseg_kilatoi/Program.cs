namespace Eszaki_kozephegyseg_kilatoi
{
    internal class Program
    {
        static List<ViewpointModel> viewpoints = ViewpointModel.loadViewpoints("viewpoints.csv");
        static List<LocationModel> locations = LocationModel.loadLocations("locations.csv");
        static void Main(string[] args)
        {
            Console.WriteLine("6. feladat:");
            viewpoints.OrderByDescending(x => x.height).Take(1).ToList().ForEach(x => Console.WriteLine($"" +
            $"\tMegnevezés: {x.viewpointName}\n\tHegy neve: {x.mountain}\n\tMagasság: {x.height}\n\tHegység neve: {locations[x.locationId - 1].location}"));


        }
    }
}