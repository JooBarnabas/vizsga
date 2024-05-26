
namespace RealEstate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Ad> realestates = Ad.LoadFromCsv("realestates.csv");

            Console.WriteLine( Math.Round(realestates.Where(x => x.floors == 0).Average(x => x.area), 2));

            var closest = realestates.Where(x => x.freeOfCharge).OrderBy(x => x.DistanceTo(47.4164220114023, 19.066342425796986)).First();

            Console.WriteLine("2. Mesevár óvodához légvonalban legközelebbi tehermentes ingatlan adatai: ");
            Console.WriteLine($"\tEladó neve     : {closest.seller.name}");
            Console.WriteLine($"\tEladó telefonja: {closest.seller.phone}");
            Console.WriteLine($"\tAlapterület    : {closest.area}");
            Console.WriteLine($"\tSzobák száma   :  {closest.rooms}");
        }
    }
}