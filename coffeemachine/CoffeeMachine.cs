using coffeemachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coffeemachine
{
    class CoffeeMachine
    {
        private Drink _drink;
        private string _message;
        private readonly string[] _orderType = new string[] { "T", "H", "C" };
        private readonly string[] _type = new string[] { "tea", "chocolate", "coffee" };
        
        public void Work(string command)
        {
            ResetMachine();
            PrepareCommand(command);
            PrintMessage();
        }
        
        private void PrepareCommand(string command)
        {
            var res = command.Split(':');

            if (res[0] == "M")
                _message = res[1];
            else
            {
                _drink._typeOfDrink = _type[Array.IndexOf(_orderType, res[0])];
                _drink._sugarnumber = !string.IsNullOrEmpty(res[1]) ? int.Parse(res[1]) : 0;
                if (!string.IsNullOrEmpty(res[2]) && Int32.Parse(res[2]) == 0)
                    _drink._stick = true;
            }
        }

        private void PrintMessage()
        {
            if (_message == null)
            {
                var stick = _drink._stick == true ? "a" : "no";
                Console.WriteLine($"Drink maker makes 1 {_drink._typeOfDrink} with {_drink._sugarnumber} sugar and {stick} stick");
            }
            else
                Console.WriteLine(_message);
        }
        private void ResetMachine()
        {
            _drink = new Drink();
            _message = null;
        }
    }
}
