using System;
using System.Collections.Generic;
using System.Text;

namespace tinyCrm
{
    public class Product
    {
        public string ProductId { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        
        public Product(string ProductId, string Name, string Description)
        {
            this.ProductId = ProductId;
            this.Name = Name;
            this.Description = Description;
            Random r = new Random();
            this.Price = (decimal)(r.NextDouble() * 100);
        }


        public string toString()
        {
            return $"Id = {this.ProductId} Name = {this.Name} Price = {this.Price.ToString("0.##")} ";
        }
    }
}
