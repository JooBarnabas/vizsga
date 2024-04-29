namespace k02_event
{
    internal class Program
    {
        static void Main(string[] args)
        {
            processBusinessLogic bl = new processBusinessLogic();
            bl.ProcessCompleted += Bl_ProcessCompleted;
            bl.startPocess(0);
            // ....
        }

        private static void Bl_ProcessCompleted(object? sender, bool isSuccesful)
        {
            Console.WriteLine("Process "+ (isSuccesful ? "completed successfully":"faild"));
        }
    }

    public class processBusinessLogic
    {
        // esemény deklarálása a beépített EventHandler delagate-tel történik.
        public event EventHandler<bool> ProcessCompleted;

        protected virtual void onProcessCompleted(bool isSuccesful)
        {
            ProcessCompleted?.Invoke(this, isSuccesful);
        }

        public void startPocess(int num)
        {
            try { 
                Console.WriteLine("Process started");
                int a = 10;
                Console.WriteLine(a/num);
                onProcessCompleted(true);
            
            } catch (Exception ex) {
                onProcessCompleted(false);
            }
        }
    }
}