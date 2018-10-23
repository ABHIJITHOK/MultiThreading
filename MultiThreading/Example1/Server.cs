using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Example1
{
    public class Server
    {
        public void InstanceMethod()
        {
            Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId} : Execution of Server.InstanceMethod() started.");
            Thread.Sleep(3000);
            Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId} : Execution of Server.InstanceMethod() done.");
        }

        public static void StaticMethod()
        {
            Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId} : Execution of Server.StaticMethod() started.");
            Thread.Sleep(5000);
            Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId} : Execution of Server.StaticMethod() done.");
        }
    }
}
