using System;
using System.Collections.Generic;

namespace Session2_assign
{
    public abstract class Account
    {
        static int counter = 1000;
        public int Number;
        public decimal Balance;
        public DateTime OpenDate;
        public List<string> Transactions = new List<string>();

        public Account(decimal balance)
        {
            Number = counter++;
            Balance = balance;
            OpenDate = DateTime.Now;
            Transactions.Add("Account opened with balance " + balance);
        }

        public void Deposit(decimal amt)
        {
            Balance += amt;
            Transactions.Add("Deposit: " + amt);
        }

        public virtual bool Withdraw(decimal amt)
        {
            if (amt > Balance) return false;
            Balance -= amt;
            Transactions.Add("Withdraw: " + amt);
            return true;
        }

        public bool Transfer(Account to, decimal amt)
        {
            if (!Withdraw(amt)) return false;
            to.Deposit(amt);
            Transactions.Add("Transfer to " + to.Number);
            return true;
        }

        public abstract decimal MonthlyInterest();

        public void Show()
        {
            Console.WriteLine($"Account: {Number} | Balance: {Balance}");
        }
    }

}
