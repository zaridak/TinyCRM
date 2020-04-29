using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace tinyCrm
{
    public class Order
    {
        List<Product> AllProducts;

        private static long OrderId = 0;
        public long MyOrderId { get; set; }
        public string DeliveryAddress { get; set; }
        public decimal TotalAmount;

        public Order(string DeliveryAddress)
        {
            this.DeliveryAddress = DeliveryAddress;
            this.AllProducts = new List<Product>();         
            this.MyOrderId = ++OrderId;
        }

        public void AddProduct(Product p)
        {
            this.AllProducts.Add(p);
        }

        public decimal getTotalAmount()
        {
            decimal tmpAmount = 0.0M;
            foreach(Product tmp in this.AllProducts)
            {
                tmpAmount += tmp.Price;
            }
            return tmpAmount;
        }

        public long getOrderId() { return this.MyOrderId; }

    }
}
