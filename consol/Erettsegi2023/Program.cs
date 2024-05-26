namespace Erettsegi2023
{
    public class Program
    {
        static List<Repcsi> RepcsiList = new List<Repcsi>();
        static void Main(string[] args)
        {
            foreach (var item in File.ReadAllLines("utasszallitok.txt").Skip(1))
            {
                RepcsiList.Add(new Repcsi(item));
            }

            Console.WriteLine(RepcsiList.Count());

            Console.WriteLine(RepcsiList.Where(x => x.típus.StartsWith("Boeing")).Count());
            //foreach (var item in RepcsiList)
            //{
            //    Console.WriteLine(item.max);
            //}

            Console.WriteLine(RepcsiList.OrderBy(x => x.max));

            Console.ReadLine();
        }
    }
}