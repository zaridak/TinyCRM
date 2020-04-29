using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace tinyCrm
{
    class Order
    {
        List<Product> AllProducts;

        private static long OrderId = 0;
        public long MyOrderId { get; set; }
        public string DeliveryAddress { get; set; }
        public decimal TotalAmount { get; }

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

        public long getOrderId() { return this.MyOrderId; }

    }
}
