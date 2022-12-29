using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONProblem.StockManagement
{
    public class StockManage
    {
        List<Stock> stock = new List<Stock>(); 
        List<Stock> customer = new List<Stock>(); 
        public void ReadStockJsonFile(string filePath)
        {
            var json=File.ReadAllText(filePath);
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

        public void BuyStock(string name)
        {
            double amount = 1000, count = 0;
            Stock stocks;
            foreach(var data in stock)
            {
                if(data.StockName.Equals(name))
                {
                    Console.WriteLine("Enter the no. of stocks u want to buy");
                    int noOfStocks = Convert.ToInt32(Console.ReadLine());
                    if(noOfStocks*data.StockPrice<=amount && noOfStocks<=data.NoOfShares)
                    {
                        Stock stock = new Stock()
                        {
                            StockName = data.StockName,
                            StockPrice = data.StockPrice,
                            NoOfShares = noOfStocks
                        };
                        data.NoOfShares = noOfStocks;
                        amount-=data.StockPrice*noOfStocks;
                        
                        foreach(var account in customer)
                        {
                            if (account.StockName.Equals(name))
                            {
                                count++;
                            }
                        }
                        if(count ==1)
                        {
                            data.NoOfShares += noOfStocks;
                        }
                        else 
                        {
                            customer.Add(stock);
                        }
                    }
                }
            }
        }
        public void WriteToStockJsonFile(string filePath)
        {
            var json = JsonConvert.SerializeObject(stock);
            File.WriteAllText(filePath, json);
        }
        public void WriteToCustomerJsonFile(string filePath)
        {
            var json = JsonConvert.SerializeObject(stock);
            File.WriteAllText(filePath, json);
        }
    }
}
