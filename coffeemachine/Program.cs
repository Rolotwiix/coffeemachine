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
            string money = "";

           while(cmd != "quit")
            {
                Console.WriteLine("Tape the order :");
                cmd = Console.ReadLine();
                Console.WriteLine("Insert money :");
                money = Console.ReadLine();
                machine.Work(cmd, double.Parse(money.Replace(".", ",")));
            }

           
        }
    }
}
