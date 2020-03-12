using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coffeemachine.Models
{
    class ReportingOrdersAndPrices
    {
        int[] drinkSaled;
        string[] drinkNames;
        double[] drinkPrices;

        public ReportingOrdersAndPrices(string[] drinkType, double[] prices)
        {
            drinkSaled = new int[drinkType.Length];
            drinkNames = drinkType;
            drinkPrices = prices;
        }

        public void IncrementDrinkSales(int positionElementIncresed)
        {
            drinkSaled[positionElementIncresed]++;
        }

        public void PrintReport()
        {
            Console.WriteLine("You have saled :");
            int i = 0;
            foreach (var name in drinkNames)
            {
                Console.WriteLine($"{drinkSaled[i]} {name} for a total of {drinkPrices[i] * Convert.ToDouble(drinkSaled[i])} $");
                i++;
            }
        }
    }
}
