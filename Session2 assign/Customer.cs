using System;
using System.Collections.Generic;


namespace Session2_assign
{
    public class Customer
    {
        static int counter = 1;
        public int Id;
        public string Name;
        public List<Account> Accounts = new List<Account>();

        public Customer(string name)
        {
            Id = counter++;
            Name = name;
        }

        public decimal TotalBalance()
        {
            decimal sum = 0;
            foreach (Account a in Accounts)
                sum += a.Balance;
            return sum;
        }

        public void Show()
        {
            Console.WriteLine($"Customer ID: {Id}, Name: {Name}");
            Console.WriteLine("---------------------------------");
            foreach (Account a in Accounts)
                a.Show();
        }
    }

}
