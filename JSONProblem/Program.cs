using JSONProblem.StockManagement;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace JSONProblem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StockManage stockManage = new StockManage();
            string file = @"D:\OneDrive\Documents\BridgeLabz\JSON\JSONProblem\StockManagement\Stock.json";

            Console.WriteLine("Welcome to JSON Problem");
            Stock stock = JsonConvert.DeserializeObject<Stock>(File.ReadAllText(file));
            var fs = stock.stocksList;
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("\nStock Management");
                Console.WriteLine("\nSelect the option \n1.Stock Data Management \n2.Exit");
                {
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            stockManage.DisplayStocks(fs);
                            break;
                        default:
                            flag = false;
                            break;
                    }
                }
            }
        }
    }
}