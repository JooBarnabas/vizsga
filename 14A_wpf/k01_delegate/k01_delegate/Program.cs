namespace k01_delegate
{
    internal class Program
    {
        /*
         - A delegate az egy függvény meghatározó referencia típusú adattípus
         - Szintaxis: [hozzáférési módosító] delagete [visszatérési típus] [Delegate név] ([paraméterek])
         */

        public delegate void MyDelegate(string str);

        // Generic delegate
        public delegate T add<T>(T param1, T param2);
        // T -> általános típus

        static void Main(string[] args)
        {
            // használat
            /*
            MyDelegate del = ClassA.MethodA;
            del("hello");
            del = ClassB.MethodB;
            del("hello");

            del = (string msg) =>  Console.WriteLine("Lamda kifejezés - "+msg);
            del("hello");
            */

            // Multicast delegate
            /*
            MyDelegate delA = ClassA.MethodA;
            MyDelegate delB = ClassB.MethodB;

            MyDelegate delM = delA + delB;

            delM("hello");

            MyDelegate delC = (string msg) => Console.WriteLine("Message C: " + msg);

            delM += delC;

            delM("hello");
            */

            add<int> sum = Sum;
            Console.WriteLine(sum(2,3));
            add<string> concat = Concat;
            Console.WriteLine(concat("hello","Béla"));

        }

        static int Sum(int num1,  int num2)
        {
            return num1 + num2;
        }

        static string Concat(string str1, string str2)
        {
            return str1 + str2;
        }
    }

    class ClassA
    {
        public static void MethodA(string message)
        {
            Console.WriteLine("Message A:"+message);
        }
    }
    class ClassB
    {
        public static void MethodB(string message)
        {
            Console.WriteLine("Message B:" + message);
        }
    }
}