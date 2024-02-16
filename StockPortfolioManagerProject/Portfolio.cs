using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPortfolioManagerProject
{
    public class Portfolio
    {
        public List<Stock> Stocks { get; set; }=new List<Stock>();

        public decimal GetPortfolioValue()
        {
            decimal totalValue = 0;

            foreach(var stock in Stocks)
            {
                totalValue += stock.Price;
            }
            return totalValue;
                    
        }
    }
}
