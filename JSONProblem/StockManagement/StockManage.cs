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
        double amount = 1000, count = 0;
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
                                account.NoOfShares += noOfStocks;
                                count++;
                            }
                        }
                        if(count ==0)
                        {
                            customer.Add(stock);
                        }
                    }
                }
            }
        }
        public void SellStock(string name)
        {
            foreach (var data in customer)
            {
                int count = 0;
                if (data.StockName.Equals(name))
                {
                    Console.WriteLine("Available Amount :{0}", amount);
                    Console.WriteLine("Enter the number of stocks you need to sell : ");
                    int noOfStocks = Convert.ToInt32(Console.ReadLine());
                    if (noOfStocks <= data.NoOfShares)
                    {
                        data.NoOfShares -= noOfStocks;
                        amount += noOfStocks * data.StockPrice;
                        foreach (var account in stock)
                        {
                            if (account.StockName.Equals(name))
                            {
                                data.NoOfShares -= noOfStocks;
                                return;
                            }
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
