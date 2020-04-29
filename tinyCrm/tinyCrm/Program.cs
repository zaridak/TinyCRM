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
            Order a = new Order("lolaa");
            Order b = new Order("lolab");
            Order c = new Order("lolac");

            Console.WriteLine(a.getOrderId());
            Console.WriteLine(b.getOrderId());
            Console.WriteLine(c.getOrderId());

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