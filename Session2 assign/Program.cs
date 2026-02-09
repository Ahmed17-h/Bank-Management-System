using Session2_assign;
using System;

namespace SimpleBankOOP
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("======= Welcome To Our Bank =======");
            Bank bank = new Bank("ElBank", "RD4000");
            
            while (true)
            {
                Console.WriteLine("\n1- Add Customer");
                Console.WriteLine("2- Update Customer");
                Console.WriteLine("3- Remove Customer");
                Console.WriteLine("4- Search Customer");
                Console.WriteLine("5- Add Account to Customer");
                Console.WriteLine("6- Deposit");
                Console.WriteLine("7- Withdraw");
                Console.WriteLine("8- Transfer");
                Console.WriteLine("9- Show Bank Report");
                Console.WriteLine("10- Show Account Transactions");
                Console.WriteLine("0- Exit");

                Console.Write("Choice: ");
                string ch = Console.ReadLine();

                if (ch == "0") break;

                switch (ch)
                {
                    case "1": 
                        bank.AddCustomer();
                        break;
                    case "2": 
                        bank.UpdateCustomer(); 
                        break;
                    case "3": 
                        bank.RemoveCustomer(); 
                        break;
                    case "4": 
                        bank.SearchCustomer(); 
                        break;
                    case "5": 
                        bank.AddAccount();
                        break;
                    case "6": 
                        bank.Deposit();
                        break;
                    case "7": 
                        bank.Withdraw(); 
                        break;
                    case "8":
                        bank.Transfer(); 
                        break;
                    case "9": 
                        bank.ShowReport(); 
                        break;
                    case "10": 
                        bank.ShowTransactions(); 
                        break;
                    default: 
                        Console.WriteLine("Invalid choice"); 
                        break;
                }
            }
        }
    }
}
