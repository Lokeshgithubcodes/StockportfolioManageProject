using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPortfolioManagerProject
{
    public class Program
    {

        static void Main(string[] args)
        {
            Portfolio userPortfolio = new Portfolio();

            while (true)
            {
                Console.WriteLine("\nStock Portfolio Manager");
                Console.WriteLine("1. Buy Stock");
                Console.WriteLine("2. Sell Stock");
                Console.WriteLine("3. View Portfolio");
                Console.WriteLine("4. Exit");

                Console.Write("Select an option (1-4): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        BuyStock(userPortfolio);
                        break;

                    case "2":
                        SellStock(userPortfolio);
                        break;

                    case "3":
                        ViewPortfolio(userPortfolio);
                        break;

                    case "4":
                        Console.WriteLine("Exiting the Stock Portfolio Manager. Goodbye!");
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please choose a valid option.");
                        break;
                }
            }
        }

        static void BuyStock(Portfolio portfolio)
        {
            Console.Write("Enter stock symbol: ");
            string symbol = Console.ReadLine();

            Console.Write("Enter stock name: ");
            string name = Console.ReadLine();

            Console.Write("Enter stock price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            Stock newStock = new Stock { Symbol = symbol, Name = name, Price = price };
            portfolio.Stocks.Add(newStock);

            Console.WriteLine($"Stock '{name}' ({symbol}) bought successfully.");
        }

        static void SellStock(Portfolio portfolio)
        {
            Console.Write("Enter stock symbol to sell: ");
            string symbolToSell = Console.ReadLine();

            Stock stockToRemove = portfolio.Stocks.Find(stock => stock.Symbol.Equals(symbolToSell, StringComparison.OrdinalIgnoreCase));

            if (stockToRemove != null)
            {
                portfolio.Stocks.Remove(stockToRemove);
                Console.WriteLine($"Stock '{stockToRemove.Name}' ({stockToRemove.Symbol}) sold successfully.");
            }
            else
            {
                Console.WriteLine("Stock not found in the portfolio.");
            }
        }

        static void ViewPortfolio(Portfolio portfolio)
        {
            Console.WriteLine("\nYour Portfolio:");

            foreach (var stock in portfolio.Stocks)
            {
                Console.WriteLine($"Stock: {stock.Name} ({stock.Symbol}), Price: {stock.Price:C}");
            }

            Console.WriteLine($"Total Portfolio Value: {portfolio.GetPortfolioValue():C}");
        }
        
    }

}
