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
        private readonly string[] _orderType = new string[] { "T", "H", "C", "O" };
        private readonly double[] _orderPrice = new double[] { 0.4, 0.5, 0.6, 0.6 };
        private readonly string[] _type = new string[] { "tea", "chocolate", "coffee", "orange juice" };
        
        public void Work(string command, double money)
        {
            var res = command.Split(':');

            ResetMachine();
            if (CheckMoney(res[0], money) == true)
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
                _drink._typeOfDrink = _type[Array.IndexOf(_orderType, command[0][0].ToString())];
                if (_drink._typeOfDrink == "orange juice")
                    _drink._cold = true;
                _drink._sugarnumber = !string.IsNullOrEmpty(command[1]) ? int.Parse(command[1]) : 0;
                if (!string.IsNullOrEmpty(command[2]) && Int32.Parse(command[2]) == 0)
                    _drink._stick = true;
                _drink._extra = command[0].Length > 1 ? command[0][1] == 'h' ? true : false : false;
            }
        }

        private bool CheckMoney(string type, double money)
        {
            int typePosition = Array.IndexOf(_orderType, type[0].ToString());
            if (money < _orderPrice[typePosition])
            {
                Console.WriteLine($"please insert {_orderPrice[typePosition] - money}$");
                return false;
            }
            return true;
        }

        private void PrintMessage()
        {
            if (_message == null)
            {
                if (_drink._cold == true)
                    Console.WriteLine($"Drink maker will make one {_drink._typeOfDrink}");
               else
                {
                    var stick = _drink._stick == true ? "a" : "no";
                    var extra = _drink._extra == true ? " extra hot " : "";
                    Console.WriteLine($"Drink maker makes 1 {extra} {_drink._typeOfDrink} with {_drink._sugarnumber} sugar and {stick} stick");
                }
            }
            else
                Console.WriteLine(_message);
        }
        private void ResetMachine()
        {
            _drink = new Drink();
            _message = null;        }
    }
}
