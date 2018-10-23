using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Example2PassingDataToThreads
{
    public class Server
    {
        private string parameter1;
        private int parameter2;
        public Server(string text, int value)
        {
            parameter1 = text;
            parameter2 = value;
        }

        public void ServerMethod()
        {
            Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId} : Execution of Server.ServerMethod() started.");
            Console.WriteLine($"Value of text parameter1 = {parameter1} ;  Value of int parameter2 = {parameter2}");
            Thread.Sleep(3000);
            Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId} : Execution of Server.ServerMethod() done.");
        }
    }
}
