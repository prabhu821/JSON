using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONProblem.StockManagement
{
    internal class StockManage
    {
        int totalshare;
        
        //Display 
        public void DisplayStocks(List<Stock.Stocks> stocksList)
        {
            Console.WriteLine("\nSTOCK DETAILS");
            foreach (var i in stocksList)
            {
                Console.WriteLine("Stock name is: {0} \nStock share is: {1} \nStock Price : {2}", i.StockName, i.Shares, i.Price);
                int temp = i.Shares * i.Price;
                totalshare += temp;
                Console.WriteLine("Total stock price for {0} : {1}", i.StockName, temp);
            }
            Console.WriteLine("\nTotal store : {0}", totalshare);
        }
    }
}
