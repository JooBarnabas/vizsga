namespace ConsoleAPP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Ad> advs = Ad.LoadFromCsv("realestates.csv");

            Console.WriteLine("1. Földszinti ingatlanok átlagos alapterülete: " + 
                    $"{advs.Where(x => x.Floors==0).Average(x => x.Area):F2} m2"
                );

            var closest = advs.Where(x => x.FreeOfCharge).OrderBy(x => x.DistanceTo(47.4164220114023, 19.066342425796986)).First();

            Console.WriteLine("2. Mesevár óvodához légvonalban legközelebbi tehermentes ingatlan adatai: ");
            Console.WriteLine($"\tEladó neve     : {closest.Seller.Name}");
            Console.WriteLine($"\tEladó telefonja: {closest.Seller.Phone}");
            Console.WriteLine($"\tAlapterület    : {closest.Area}");
            Console.WriteLine($"\tSzobák száma   :  {closest.Rooms}");
        }
    }
}
