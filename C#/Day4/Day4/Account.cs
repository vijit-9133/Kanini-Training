using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    class Account
    {
        private string AccountNumber;
        private string OwnerName;
        private decimal Balance;

        public Account(string accountNumber, string ownerName, decimal balance)
        {
            AccountNumber = accountNumber;
            OwnerName = ownerName;
            Balance = balance;
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"{amount} credited to {AccountNumber}");
            }
            else
            {
                Console.WriteLine("Invalid deposit amount.");
            }
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid withdrawal amount.");
            }
            else if (amount > Balance)
            {
                Console.WriteLine("Insufficient balance.");
            }
            else
            {
                Balance -= amount;
                Console.WriteLine($"{amount} withdrawn from {AccountNumber}");
            }
        }

        public void DisplayAccountInfo()
        {
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine($"Account Number : {AccountNumber}");
            Console.WriteLine($"Owner Name     : {OwnerName}");
            Console.WriteLine($"Balance        : {Balance}");
            Console.WriteLine("------------------------------------------------");
        }
    }
}
