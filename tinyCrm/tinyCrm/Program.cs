using System;


namespace tinyCrm
{
    using System;
    using System.Text.RegularExpressions;
    
    class Program
    {
        public void PrintName(string name)
        {
            Console.WriteLine($"You gave me us name: {name}");
        }

        static void Main(string[] args)
        {
            //   var name = Console.ReadLine();

            Program p = new Program();
            //p.PrintName(name);
            Customer zaridak = null;
            try
            {
                zaridak = new Customer("test@te@st.com", "813445679", "testteste", 4);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Product lol = new Product();
            lol.code = "aek";


            Console.WriteLine(zaridak.toString());
            Console.ReadLine();
        }

        bool IsValidEmail2(string mail)
        {
            if (!string.IsNullOrWhiteSpace(mail))
            {
                mail = mail.Trim();

                if (mail.Contains("@") &&
                    (mail.EndsWith(".com") || mail.EndsWith(".gr")))
                {
                    return true;
                }
            }
            return false;
        }

        bool IsValidEmail(string mail)
        {
            Regex mRegxExpression;

            if (mail.Trim() != string.Empty)
            {
                mRegxExpression = new Regex(@"^([a-zA-Z0-9_\-])([a-zA-Z0-9_\-\.]*)@(\[((25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\.){3}|((([a-zA-Z0-9\-]+)\.)+))([a-zA-Z]{2,}|(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9][0-9]|[0-9])\])$");

                if (!mRegxExpression.IsMatch(mail.Trim()))
                {
                    return false;
                }
            }
            return true;
        }


        bool IsAdult(int age)
        {
            return (age >= 18 && age < 100) ? true : false;
        }

        bool IsValidAfm(string afm)
        {
            if (string.IsNullOrWhiteSpace(afm))
                return false;
            afm = afm.Trim();
            if (afm.Length != 9)
                return false;
            foreach (char c in afm)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        public string checkLength(string test)
        {
            return string.IsNullOrWhiteSpace(test) ? "zero or empty" : test.Length >= 20 ?
                                              "more that 20 chars 32" : "less than 20 chars";
        }
    }
}