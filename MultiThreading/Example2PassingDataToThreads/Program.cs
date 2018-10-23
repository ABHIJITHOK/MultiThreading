using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Example2PassingDataToThreads
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Server objServer = new Server("Abhy", 10);
            Thread ServerMethodThread = new Thread(new ThreadStart(objServer.ServerMethod));
            ServerMethodThread.Start();
            Console.WriteLine($"Main thread with Thread Id: {Thread.CurrentThread.ManagedThreadId} is doing something.");
            ServerMethodThread.Join();
            Console.WriteLine($"Main thread with Thread Id: {Thread.CurrentThread.ManagedThreadId} is done.");
        }
    }
}
