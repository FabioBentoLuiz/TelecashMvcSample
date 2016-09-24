using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelecashSample.Models
{
    public class Customer
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products = new List<Product>();
        public string TransactionTime { get; set; }

        //for test purposes the total must be a value between 1 and 999
        public int Total
        {
            get
            {
                int sum = 0;
                foreach (Product p in Products)
                    sum += p.Total;
                return sum;
            }

            private set { }
        }
        public string Hash { get; set; }
    }
}