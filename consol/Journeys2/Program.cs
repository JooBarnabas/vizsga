namespace Journeys2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<JourneyModel> journeys = JourneyModel.LoadFromCsv("journeys.csv");

            Console.WriteLine("6. feladat:");
            journeys.Where(x => x.vehicle.type == "repülőgép").OrderBy(x => x.departure).Take(1).ToList().ForEach(x => Console.WriteLine($"\t{x.country} - legkorábbi ({x.departure})"));
            journeys.Where(x => x.vehicle.type == "repülőgép").OrderBy(x => x.departure).Skip(1).ToList().ForEach(x => Console.WriteLine($"\t{x.country}"));

            Console.WriteLine("7. feladat:");

            Dictionary<string, int> journeyCount = new Dictionary<string, int>();
            Dictionary<string, int> capacityCount = new Dictionary<string, int>();

            foreach (var item in journeys)
            {
                if (!journeyCount.ContainsKey(item.vehicle.type))
                {
                    journeyCount.Add(item.vehicle.type, 1);
                    capacityCount.Add(item.vehicle.type, item.capacity);
                }
                else
                {
                    journeyCount[item.vehicle.type]++;
                    capacityCount[item.vehicle.type] += item.capacity;
                }
            }

            foreach (var item in journeyCount)
            {
                if (capacityCount[item.Key] != 0)
                {
                    Console.WriteLine($"\t{item.Key} : {item.Value} utazás, férőhely összesen {capacityCount[item.Key]} fő");
                }
                else
                {
                    Console.WriteLine($"\t{item.Key} : {item.Value} utazás, önállószervezés");
                }
            }
        }
    }
}