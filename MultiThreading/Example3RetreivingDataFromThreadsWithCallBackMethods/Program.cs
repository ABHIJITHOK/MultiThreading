using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Example3RetreivingDataFromThreadsWithCallBackMethods
{
    public class Program
    {
        //Delegate that defines the signature of the call back method
        public delegate void ExampleCallBack(int lineCount);

        public static void Main(string[] args)
        {
            Server objServer = new Server("Abhy", 10, ResultCallBack);
            Thread ServerMethodThread = new Thread(new ThreadStart(objServer.ServerMethod));
            ServerMethodThread.Start();
            Console.WriteLine($"Main thread with Thread Id: {Thread.CurrentThread.ManagedThreadId} is doing something.");
            ServerMethodThread.Join();
            Console.WriteLine($"Main thread with Thread Id: {Thread.CurrentThread.ManagedThreadId} is done.");
        }

        public static void ResultCallBack(int lineCount)
        {
            Console.WriteLine($"Inside ResultCallBack method: linecount: {lineCount}.");
        }
    }
}
