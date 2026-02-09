using System;
using System.Collections.Generic;

namespace Session2_assign
{
    public class Bank
    {
        private string Name;
        private string BranchBank;
        private List<Customer> Customers = new List<Customer>();

        public Bank(string name, string branchBank)
        {
            Name = name;
            BranchBank = branchBank;
        }

        public void AddCustomer()
        {
            Console.Write("Customer Name: ");
            string name = Console.ReadLine();
            Customers.Add(new Customer(name));
            Console.WriteLine("Customer added.");
        }

        private Customer FindCustomer()
        {
            Console.Write("Customer ID: ");
            int id = int.Parse(Console.ReadLine());

            foreach (Customer c in Customers)
                if (c.Id == id)
                    return c;

            Console.WriteLine("Customer not found.");
            return null;
        }
        public void UpdateCustomer()
        {
            Customer c = FindCustomer();
            if (c == null) return;

            Console.Write("New Name: ");
            c.Name = Console.ReadLine();
            Console.WriteLine("Customer updated.");
        }

        public void RemoveCustomer()
        {
            Customer c = FindCustomer();
            if (c == null) return;

            if (c.TotalBalance() != 0)
            {
                Console.WriteLine("Customer has balance, cannot remove.");
                return;
            }

            Customers.Remove(c);
            Console.WriteLine("Customer removed.");
        }

        public void SearchCustomer()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            foreach (Customer c in Customers)
            {
                if (c.Name.ToLower() == name.ToLower())
                    c.Show();
            }
        }

        public void AddAccount() 
        {
            Customer c = FindCustomer();
            if (c == null) return;

            Console.WriteLine("1- Savings Account");
            Console.WriteLine("2- Current Account");
            Console.Write("Type: ");
            string type = Console.ReadLine();

            Console.Write("Initial Balance: ");
            decimal bal = decimal.Parse(Console.ReadLine());

            if (type == "1")
            {
                Console.Write("Interest Rate: ");
                decimal rate = decimal.Parse(Console.ReadLine());
                c.Accounts.Add(new SavingsAccount(bal, rate));
            }
            else if (type == "2") 
            {
            
                Console.Write("Overdraft Limit: ");
                decimal limit = decimal.Parse(Console.ReadLine());
                c.Accounts.Add(new CurrentAccount(bal, limit));
            }
            else
            {
                Console.WriteLine("Wrong input");
            }
        }

        public void Deposit()
        {
            Account a = FindAccount();
            if (a == null) return;

            Console.Write("Amount: ");
            decimal amt = decimal.Parse(Console.ReadLine());
            a.Deposit(amt);
        }

        public void Withdraw()
        {
            Account a = FindAccount();
            if (a == null) return;

            Console.Write("Amount: ");
            decimal amt = decimal.Parse(Console.ReadLine());

            if (!a.Withdraw(amt))
                Console.WriteLine("Not enough balance.");
        }

        public void Transfer()
        {
            Console.WriteLine("From Account:");
            Account from = FindAccount();
            Console.WriteLine("To Account:");
            Account to = FindAccount();
            if (from == null || to == null) return;

            Console.Write("Amount: ");
            decimal amt = decimal.Parse(Console.ReadLine());

            if (!from.Transfer(to, amt))
                Console.WriteLine("Transfer failed.");
        }

        public void ShowTransactions()
        {
            Account a = FindAccount();
            if (a == null) return;

            foreach (string t in a.Transactions)
                Console.WriteLine(t);
        }

        public void ShowReport()
        {
            foreach (Customer c in Customers)
            {
                c.Show();
                Console.WriteLine($"Total Balance: {c.TotalBalance()}" );
                Console.WriteLine("---------------------");
            }
        }


        Account FindAccount()
        {
            Console.Write("Account Number: ");
            int num;
            if (!int.TryParse(Console.ReadLine(), out num)) return null;

            foreach (Customer c in Customers)
                foreach (Account a in c.Accounts)
                    if (a.Number == num)
                        return a;

            Console.WriteLine("Account not found.");
            return null;
        }
    }
}
