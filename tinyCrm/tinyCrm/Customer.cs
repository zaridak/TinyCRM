using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace tinyCrm
{
    public class Customer
    {
        private string Email;    
        private string VatNumber;
        private DateTime Created { get; set; }  
        private string Phone;
        private decimal TotalGross;
        public bool IsActive { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private List<Order> MyOrders;
        

        public Customer(){}

        public Customer(string email, string vatNumber, string phone, decimal totalGross,string FirstName,string LastName)
        {
            if (!IsValidEmail(email))
                throw new Exception("Invalid Email");
            if (!IsValidAfm(vatNumber))
                throw new Exception("Invalid Vat Number");
            this.Email = email;
            this.VatNumber = vatNumber;
            this.Phone = phone;
            this.TotalGross = totalGross;
            this.Created = DateTime.Now;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.MyOrders = new List<Order>();
        }

        public string toString()
        {
            return this.Email + " " + this.VatNumber;
        }

        public bool IsHighValuedCustomer()
        {
            return this.TotalGross > 10000M;
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

    }
}
