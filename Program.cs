using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory_Activity_10
{
    class Transaction
    {
        public string Date;
        public string Type;
        public decimal Amount;
        public string Memo;

        public Transaction(string date, string type, decimal amount, string memo)
        {
            Date = date;
            Type = type;
            Amount = amount;
            Memo = memo;
        }
    }

    class Program
    {
        static void Main()
        {
            decimal balance = 0;
            Console.Write("Enter opening balance: ");
            balance = decimal.Parse(Console.ReadLine());

            Console.Write("Enter number of transactions: ");
            int count = int.Parse(Console.ReadLine());

            List<Transaction> list = new List<Transaction>();

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("\nTransaction " + (i + 1));
                Console.Write("Date (yyyy-mm-dd): ");
                string date = Console.ReadLine();
                Console.Write("Type (deposit/withdrawal): ");
                string type = Console.ReadLine().ToLower();
                Console.Write("Amount: ");
                decimal amount = decimal.Parse(Console.ReadLine());
                Console.Write("Memo: ");
                string memo = Console.ReadLine();

                if (type == "withdrawal" && amount > balance)
                {
                    Console.WriteLine("Not enough balance! Transaction skipped.");
                    i--;
                    continue;
                }

                if (type == "deposit")
                    balance += amount;
                else if (type == "withdrawal")
                    balance -= amount;

                list.Add(new Transaction(date, type, amount, memo));

                if (amount >= 1000)
                    Console.WriteLine("Suspicious transaction (high amount).");

                Console.WriteLine("Running Balance: " + balance);
            }

            Console.Write("\nEnter bank statement ending balance: ");
            decimal bankBal = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Ledger Summary");
            foreach (var t in list)
            {
                Console.WriteLine($"{t.Date} | {t.Type} | {t.Amount} | {t.Memo}");
            }
            Console.WriteLine("Final Balance: " + balance);
            Console.WriteLine("Bank Balance: " + bankBal);
            Console.WriteLine("Variance: " + (bankBal - balance));
        }
    }
}

    
    