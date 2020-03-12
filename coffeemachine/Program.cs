using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coffeemachine
{
    class Program
    {
        static void Main(string[] args)
        {
           CoffeeMachine machine = new CoffeeMachine();
            string cmd = "";

           while(cmd != "quit")
            {
                cmd = Console.ReadLine();
                machine.Work(cmd);
            }

           
        }
    }
}
