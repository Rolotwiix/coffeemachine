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
        private double _money;
        private string _message;
        private readonly string[] _orderType = new string[] { "T", "H", "C" };
        private readonly double[] _orderPrice = new double[] { 0.4, 0.5, 0.6 };
        private readonly string[] _type = new string[] { "tea", "chocolate", "coffee" };
        
        public void Work(string command)
        {
            var res = command.Split(':');

            ResetMachine();
            if (CheckMoney(res[0]) == true)
            {
                PrepareCommand(res);
                PrintMessage();
            }
        }
        
        private void PrepareCommand(string[] command)
        {
            if (command[0] == "M")
                _message = command[1];
            else
            {
                _drink._typeOfDrink = _type[Array.IndexOf(_orderType, command[0])];
                _drink._sugarnumber = !string.IsNullOrEmpty(command[1]) ? int.Parse(command[1]) : 0;
                if (!string.IsNullOrEmpty(command[2]) && Int32.Parse(command[2]) == 0)
                    _drink._stick = true;
            }
        }

        private bool CheckMoney(string type)
        {
            int typePosition = Array.IndexOf(_orderType, type);
            if (_orderPrice[typePosition] < _money)
            {
                Console.WriteLine($"please insert {_orderPrice[typePosition] - _money}$");
                return false;
            }
            return true;
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
            _money = 0;
        }
    }
}
