using System.Security.Cryptography;
using System.Threading.Channels;

namespace Linq_alapok
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Job { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> persons = new List<Person>();
            persons.Add(new Person() { Id = 1, Name = "Béla", Age = 25, City = "Győr", Job = "Programmer" });
            persons.Add(new Person() { Id = 2, Name = "Józsi", Age = 26, City = "Budapest", Job = "Manager" });
            persons.Add(new Person() { Id = 3, Name = "Szabolcs", Age = 28, City = "Budapest", Job = "Programmer" });
            persons.Add(new Person() { Id = 4, Name = "Dávid", Age = 26, City = "Győr", Job = "Developer" });

            // A lINQ kif. két szintaktika:
            // - lekérdező kifejezés (Query expression)
            // - metódus bővítés (Extension method)

            Console.WriteLine("Összes rekord:");
            // IEnumerable<Person> eredmeny1 = from p in persons select p;
            IEnumerable<Person> eredmeny1 = persons.Select(p => p);
            foreach (var p in eredmeny1)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine("-------------------------");
            Console.WriteLine("Adott mezők:");
            // var eredmeny2 = from p in persons select p.Name;
            var eredmeny2 = persons.Select(p => p.Name);
            foreach (var p in eredmeny2)
            {
                Console.WriteLine(p);
            }

            Console.WriteLine("-------------------------");
            Console.WriteLine("Új objektum:");
            // var eredmeny3 = from p in persons select new { Nev = p.Name, Kor = p.Age };
            var eredmeny3 = persons.Select(p => new { Nev = p.Name, Kor = p.Age });
            foreach (var p in eredmeny3)
            {
                Console.WriteLine(p.Nev + " " + p.Kor);
            }

            Console.WriteLine("-------------------------");
            Console.WriteLine("Szűrés:");
            //var eredmeny4 = from p in persons where p.City == "Győr" select p;
            var eredmeny4 = persons.Where(p => p.City == "Győr");
            foreach (var p in eredmeny4)
            {
                Console.WriteLine(p.Name + " " + p.City);
            }

            Console.WriteLine("-------------------------");
            persons.Where(p => p.City == "Győr").ToList().ForEach(p => Console.WriteLine(p.Name));

            Console.WriteLine("-------------------------");
            Console.WriteLine("Ismétlődés:");
            (from p in persons select p.City).Distinct().ToList().ForEach(p => Console.WriteLine(p));

            persons.Select(p => p.City).Distinct().ToList().ForEach(p => Console.WriteLine(p));

            Console.WriteLine("-------------------------");
            Console.WriteLine("rendezés:");
            // var eredmeny5 = from p in persons orderby p.Name select p;
            // var eredmeny5 = from p in persons orderby p.Name descending select p; // fordított sorrend
            // var eredmeny5 = persons.OrderBy(p => p.Name);
            // var eredmeny5 = persons.OrderByDescending(p => p.Name);

            // var eredmeny5 = from p in persons orderby p.City, p.Name select p;
            var eredmeny5 = persons.OrderBy(p => p.City).ThenBy(p => p.Name).Select(p => p);

            foreach (var p in eredmeny5)
            {
                Console.WriteLine(p.Name);
            }

            Console.WriteLine("-------------------------");
            Console.WriteLine("Statisztika:");
            int[] tomb = new int[] { 1, 2, 3, 4, 5 };
            Console.WriteLine(tomb.Count());
            Console.WriteLine(tomb.Min());
            Console.WriteLine(tomb.Max());
            Console.WriteLine(tomb.Average());
            Console.WriteLine(tomb.Sum());

            Console.WriteLine("-------------------------");
            Console.WriteLine((from p in persons select p.Age).Sum());


            List<double> numbers = new List<double>() { 2.0, 2.1, 2.2, 2.3 };
            // First()/Last()
            Console.WriteLine("-------------------------");
            Console.WriteLine(numbers.First());
            Console.WriteLine(numbers.Last());

            Console.WriteLine("-------------------------");

            // First(feltétel)/Last(feltétel) Nincs egyezés, akkor hibaüzenet!
            Console.WriteLine(numbers.First(x => x > 2.2));
            Console.WriteLine(numbers.Last(x => x < 2.2));

            Console.WriteLine(numbers.FirstOrDefault(x => x > 2.2));

            if (numbers.FirstOrDefault(x => x > 4) == null)
            {
                Console.WriteLine("nincs egyezés");
            }

            Console.WriteLine("-------------------------");
            Console.WriteLine("tejles egyezés");
            // Console.WriteLine(numbers.Single(x => x == 3));
            Console.WriteLine(numbers.SingleOrDefault(x => x == 3));

            Console.WriteLine("-------------------------");
            Console.WriteLine("elemek átlépése");
            // Skip() / Take()
            List<string> animals = new List<string>() { "malac", "ló", "kecske", "csirke", "házi nyúl" };

            var eredmeny6 = animals.Take(4);
            eredmeny6.ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine("-------------------------");
            animals.Skip(2).ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine("-------------------------");
            animals.Skip(2).Take(2).ToList().ForEach(x => Console.WriteLine(x));
            
            Console.WriteLine("-------------------------");
            List<int> numbers2 = new List<int>() { 1, 2, 4, 8, 4, 2, 1 };
            numbers2.TakeWhile(x => x < 5).ToList().ForEach(x => Console.WriteLine(x));

            // sorrend módosítók
            Console.WriteLine("-------------------------");
            animals.Reverse();
            animals.ToList().ForEach(x => Console.WriteLine(x));

            List<string> animalsRev = Enumerable.Reverse(animals).ToList();

            animalsRev.ForEach(x => Console.WriteLine(x));
        }
    }
}