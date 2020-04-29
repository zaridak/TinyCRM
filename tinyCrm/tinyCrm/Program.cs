using System;

namespace tinyCrm
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    class Program
    {        

        static void Main(string[] args)
        {
            
            Program p = new Program();
            List<Product> ProductsList = new List<Product>();
            //product Id, whole Product
            Dictionary<string, Product> ProductsList2 = new Dictionary<string, Product>();

            try
            {
                List<Product> AllProducts = new List<Product>();
                string filePath = "C:\\Users\\User\\Desktop\\dotNetProjectCH\\tinyCrm\\tinyCrm\\tinyCrm\\Products.txt";
                ProductsList2 = p.readFile(filePath);

                foreach(KeyValuePair<string,Product> tmp in ProductsList2)
                {
                    Console.WriteLine(tmp.Value.toString());
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Customer firstCustomer = new Customer("first@live.com", "123456789",
                "123123123", "Alexandros", "Zaridak");

            Customer SecondCustomer = new Customer("second@live.com", "987654321",
                "321654123", "Test2", "Customer2");

            Order a = new Order("order1");
            Order b = new Order("order2");
            Order c = new Order("order3");

            ProductsList = p.DictToList(ProductsList2);

            a.AddProduct(ProductsList[1]);
            a.AddProduct(ProductsList[2]);
            a.AddProduct(ProductsList[3]);

            b.AddProduct(ProductsList[4]);
            b.AddProduct(ProductsList[5]);
            b.AddProduct(ProductsList[6]);

            firstCustomer.AddNewOrder(a);
            //firstCustomer.AddNewOrder(b);
            SecondCustomer.AddNewOrder(b);

            Console.WriteLine("Order a total Amount: "+a.getTotalAmount());
            Console.WriteLine("Order b total Amount: "+b.getTotalAmount());

            Console.WriteLine($"FirstCustomer totalGross: {firstCustomer.getTotalGross()}");
            Console.WriteLine($"SecondCustomer totalGross: {SecondCustomer.getTotalGross()}");

            Console.ReadLine();
        }


        public Dictionary<string, Product> readFile(string FilePath)
        {
            //List<Product> all = new List<Product>();
            Dictionary<string, Product> tmpDic = new Dictionary<string, Product>();
            foreach (string line in File.ReadLines(FilePath))
            {
                String[] tmp = line.Split(";");
                if (tmp[0] == "productId") continue;
                //all.Add(new Product(tmp[0], tmp[1], tmp[2]));
                tmpDic.Add(tmp[0], new Product(tmp[0], tmp[1], tmp[2]));
            }
            return tmpDic;
        }

        public List<Product> DictToList(Dictionary<string, Product> dic)
        {
            List<Product> ret = new List<Product>();
            foreach (KeyValuePair<string, Product> tmp in dic)
            {
                ret.Add(tmp.Value);
            }
            return ret;
        }


        bool IsAdult(int age)
        {
            return (age >= 18 && age < 100) ? true : false;
        }

        public string checkLength(string test)
        {
            return string.IsNullOrWhiteSpace(test) ? "zero or empty" : test.Length >= 20 ?
                                              "more that 20 chars 32" : "less than 20 chars";
        }
    }
}