using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONProblem.StockManagement
{
    internal class StockManage
    {
        List<Stock> stock = new List<Stock>(); 
        List<Stock> customer = new List<Stock>(); 
        public void ReadStockJsonFile(string file)
        {
            var json=File.ReadAllText(file);
            this.stock = JsonConvert.DeserializeObject<List<Stock>>(json);
            foreach(var content in stock)
            {
                Console.WriteLine("Stock Name: "+content.StockName + "\nStock Price: " + content.StockPrice + "\nNo of Shares: " + content.NoOfShares);
            }
        }

        public void ReadCustomerJsonFile(string filePath)
        {
            var json = File.ReadAllText(filePath);
            this.customer = JsonConvert.DeserializeObject<List<Stock>>(json);
            foreach (var content in customer)
            {
                Console.WriteLine("Stock Name: " + content.StockName + "\nStock Price: " + content.StockPrice + "\nNo of Shares: " + content.NoOfShares);
            }
        }
    }
}
