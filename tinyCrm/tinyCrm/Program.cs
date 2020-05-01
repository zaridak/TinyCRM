using System;
using System.Linq;

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
                //string filePath = "C:\\Users\\alexa\\source\\repos\\tinyCRM\\tinyCRM\\tinyCrm\\products.txt";
                string filePath = "products.txt";
                ProductsList2 = p.readFile(filePath);

                var LinQProductList = new List<Product>();

                /*foreach(KeyValuePair<string,Product> tmp in ProductsList2)
                {
                    Console.WriteLine(tmp.Value.toString());
                }*/

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Customer firstCustomer = new Customer("first@live.com", "123456789",
                "123123123", "Alexandros", "Zaridak");

            Customer SecondCustomer = new Customer("second@live.com", "987654321",
                "321654123", "Nick", "Nickolopoulos");

            Order a = new Order("order1");
            Order b = new Order("order2");            

            ProductsList = p.DictToList(ProductsList2);
            // shufle product list
            ProductsList = ProductsList.OrderBy(a => Guid.NewGuid()).ToList();

            var r = new Random();
            
            for(int i =0; i < 10; i++)
            {
                var rInt = r.Next(0, ProductsList.Count - 1);
                var rInt2 = r.Next(0, ProductsList.Count - 1);
                a.AddProduct(ProductsList.ElementAt(rInt));
                b.AddProduct(ProductsList.ElementAt(rInt2));
            }

            // making sure two products most apperaed for test
            Console.WriteLine("most product is "+ ProductsList.ElementAt(0).Name);
            a.AddProduct(ProductsList.ElementAt(0));
            a.AddProduct(ProductsList.ElementAt(0));
            a.AddProduct(ProductsList.ElementAt(0));
            a.AddProduct(ProductsList.ElementAt(0));
            a.AddProduct(ProductsList.ElementAt(0));
            a.AddProduct(ProductsList.ElementAt(0));

            Console.WriteLine("Second product is " + ProductsList.ElementAt(1).Name
                +"\n \\\\\\\\\\\\\\\\ end of test");
            a.AddProduct(ProductsList.ElementAt(1));
            a.AddProduct(ProductsList.ElementAt(1));
            a.AddProduct(ProductsList.ElementAt(1));
            a.AddProduct(ProductsList.ElementAt(1));
            a.AddProduct(ProductsList.ElementAt(1));
            a.AddProduct(ProductsList.ElementAt(1));

            // end of test products

            firstCustomer.AddNewOrder(a);
            SecondCustomer.AddNewOrder(b);            

            var Alltmp = new List<Product>(a.getAllProducts().Count+ b.getAllProducts().Count);

            Alltmp.AddRange(a.getAllProducts());
            Alltmp.AddRange(b.getAllProducts());            

            //
            var MostSelledProducts = Alltmp.GroupBy(x => new { x.Name })
                        .Select(group => new { Name = group.Key, Count = group.Count() })
                        .OrderByDescending(x => x.Count);

            Console.WriteLine("Top 5 selling products");
            for (int i = 0; i < 5 ; i++)
                Console.WriteLine(MostSelledProducts.ElementAt(i).Name);


            Console.WriteLine("***************");
            Console.WriteLine("Order a total Amount: "+ String.Format("{0:0.##}", a.getTotalAmount()));
            Console.WriteLine("Order b total Amount: "+ String.Format("{0:0.##}", b.getTotalAmount()));
            Console.WriteLine($"FirstCustomer totalGross: { String.Format("{0:0.##}", firstCustomer.getTotalGross())}");
            Console.WriteLine($"SecondCustomer totalGross: {String.Format("{0:0.##}", SecondCustomer.getTotalGross())}");            
            Console.WriteLine("Most Valueable Customer: " + (firstCustomer.getTotalGross() > SecondCustomer.getTotalGross()?
                                firstCustomer.FirstName:SecondCustomer.FirstName));
            
         //   Console.ReadLine();
        }

        public List<Product> readFileLinq(string FilePath)
        {
            var tmp = new List<Product>();
            foreach (string line in File.ReadLines(FilePath))
            {
                var str = line.Split(";");
                var procId = str[0];                                
            }
            return tmp;
        }

        public Dictionary<string, Product> readFile(string FilePath)
        {
            //List<Product> all = new List<Product>();
            var tmpDic = new Dictionary<string, Product>();
            foreach (string line in File.ReadLines(FilePath))
            {
                String[] tmp = line.Split(';');
                if (tmp[0] == "productId") continue;                
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