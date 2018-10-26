using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Messaging;
using System.Collections.Concurrent;

namespace Example5UsingConcurrentQueues
{
    public class Program
    {
        public static ConcurrentQueue<string> myQueue = new ConcurrentQueue<string>();

        public static void Main(string[] args)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            
            Thread t1 = new Thread(() =>
                {
                    if(Console.ReadKey(true).KeyChar.ToString().ToUpperInvariant()=="C")
                    {
                        cts.Cancel();
                    }
                }
            );
            t1.Start();

            Thread t2 = new Thread(new ParameterizedThreadStart(Operation1));
            t2.Start(cts.Token);

            Thread t3 = new Thread(new ParameterizedThreadStart(Operation2));
            t3.Start(cts.Token);

            t2.Join();
            t3.Join();
        }

        public static void Operation1(Object obj)
        {
            CancellationToken ct = (CancellationToken)obj;
            while(!ct.IsCancellationRequested)
            {
                Console.Write($"\nThread Id {System.Threading.Thread.CurrentThread.ManagedThreadId} performing {System.Reflection.MethodBase.GetCurrentMethod().Name}");
                myQueue.Enqueue($"Abhy");
                myQueue.Enqueue($"Sangs");
                myQueue.Enqueue($"Unni");
                Console.Write($"\nEnqueued elements:");
                foreach (var element in myQueue)
                {
                    Console.Write($"\t{element}");
                }
                Thread.Sleep(1000);
            }
            Console.Write($"\nThread Id {System.Threading.Thread.CurrentThread.ManagedThreadId} cancellation requested.");
        }

        public static void Operation2(Object obj)
        {
            string item = string.Empty;
            CancellationToken ct = (CancellationToken)obj;
            while(!ct.IsCancellationRequested)
            {
                Console.Write($"\nThread Id {System.Threading.Thread.CurrentThread.ManagedThreadId} performing {System.Reflection.MethodBase.GetCurrentMethod().Name}");
                var isExists = myQueue.TryDequeue(out item);
                if (isExists)
                {
                    Console.Write($"\nDequeued item: {item}");
                }
                else
                {
                    Console.Write("\nQueue is empty.");
                }
                Thread.Sleep(10);
            }
            Console.Write($"\nThread Id {System.Threading.Thread.CurrentThread.ManagedThreadId} cancellation requested.");
        }
    }
}
