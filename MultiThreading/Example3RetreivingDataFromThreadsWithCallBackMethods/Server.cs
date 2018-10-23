using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static Example3RetreivingDataFromThreadsWithCallBackMethods.Program;

namespace Example3RetreivingDataFromThreadsWithCallBackMethods
{
    public class Server
    {
        private string parameter1;
        private int parameter2;
        public ExampleCallBack callback;

        public Server(string text, int number, ExampleCallBack callBackDelegate)
        {
            parameter1 = text;
            parameter2 = number;
            callback = callBackDelegate;
        }

        public void ServerMethod()
        {
            Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId} : Execution of Server.ServerMethod() started.");
            Console.WriteLine($"Value of text parameter1 = {parameter1} ;  Value of int parameter2 = {parameter2}");
            Thread.Sleep(3000);
            if(callback!=null)
            {
                callback(1);
            }
            Console.WriteLine($"Thread Id: {Thread.CurrentThread.ManagedThreadId} : Execution of Server.ServerMethod() done.");
        }
    }
}
