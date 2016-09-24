using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelecashSample.Models
{
    public class Product
    {
        

        public int Price { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Total
        {
            get
            {
                return Price * Quantity;
            }

            private set { }
        }

        
        
        
    }
}