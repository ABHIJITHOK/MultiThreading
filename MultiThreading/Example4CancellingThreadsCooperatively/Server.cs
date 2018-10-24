using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Example4CancellingThreadsCooperatively
{
    public class Server
    {
        public static void ServerMethod(object obj)
        {
            CancellationToken ct = (CancellationToken)obj;
            Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId} : Execution of Server.ServerMethod() started.");
            while(!ct.IsCancellationRequested)
            {
                //Thread.SpinWait(50000);
                Console.WriteLine("Abhy");
                Thread.Sleep(500);
            }

            Console.WriteLine($"Worker thread has been cancelled. Press any key to exit.");
            Console.ReadKey(true);
        }
    }
}
