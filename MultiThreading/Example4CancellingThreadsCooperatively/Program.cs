using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Example4CancellingThreadsCooperatively
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            Console.WriteLine("Press 'C' to terminate the application.");

            Thread t1 = new Thread(() =>
                {
                    if (Console.ReadKey(true).KeyChar.ToString().ToUpperInvariant() == "C")
                    {
                        cts.Cancel();
                    }
                }
            );

            Thread t2 = new Thread(new ParameterizedThreadStart(Server.ServerMethod));
            t1.Start();
            t2.Start(cts.Token);

            Console.WriteLine($"Main thread with Thread Id: {Thread.CurrentThread.ManagedThreadId} is doing something.");
            t2.Join();
            cts.Dispose();
            Console.WriteLine($"Main thread with Thread Id: {Thread.CurrentThread.ManagedThreadId} is done.");
        }
    }
}
