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
            string StockfilePath = @"D:\OneDrive\Documents\BridgeLabz\JSON\JSONProblem\StockManagement\Stock.json";
            string CustomerfilePath = @"D:\OneDrive\Documents\BridgeLabz\JSON\JSONProblem\StockManagement\Customer.json";

            Console.WriteLine("Welcome to JSON Problem");
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("\nStock Management");
                Console.WriteLine("\nSelect the option \n1.Stock Data Management \n2.Customer Data Management \n3.Buy Stock \n4.Exit");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        stockManage.ReadStockJsonFile(StockfilePath);
                        break;
                    case 2:
                        stockManage.ReadCustomerJsonFile(CustomerfilePath);
                        break;
                    case 3:
                        Console.WriteLine("Enter name of the stock u want to buy");
                        string name=Console.ReadLine();
                        stockManage.BuyStock(name);
                        stockManage.WriteToStockJsonFile(StockfilePath);
                        stockManage.WriteToCustomerJsonFile(CustomerfilePath);
                        break;
                    default:
                        flag = false;
                        break;
                }
            }
        }
    }
}