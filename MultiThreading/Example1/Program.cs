using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Example1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Server objServer = new Server();

            //Create Thread
            Thread InstanceCaller = new Thread(new ThreadStart(objServer.InstanceMethod));
            InstanceCaller.Start();

            Thread StaticCaller = new Thread(new ThreadStart(Server.StaticMethod));
            StaticCaller.Start();

            InstanceCaller.Join();
            StaticCaller.Join();
        }
    }
}
