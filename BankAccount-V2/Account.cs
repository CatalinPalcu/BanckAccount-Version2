using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount_V2
{
    class Account
    {
        private readonly Person owner;
        private readonly DateTime openingDate;
        private bool isActive;
        private decimal amount;
        private List<Transaction> transactions;

        public Person Owner
        {
            get { return owner; }
        }

        public DateTime OpeningDate
        {
            get { return openingDate; }
        }

        public bool IsActive
        {
            get { return isActive; }
            private set { isActive = value; }
        }

        public Account(Person owner)
        {
            this.owner = owner;
            this.openingDate = DateTime.Now;
            this.isActive = true;
            this.amount = 0;
            transactions = new List<Transaction>();
        }

        public void ActivateAccount()
        {
            isActive = true;
            Console.WriteLine("The account was activated");
        }

        public void CloseAccount()
        {
            isActive = false;
            Console.WriteLine("The account was closed");
        }

        public decimal AccountQuery()
        {
            if (isActive)
                return amount;

            Console.WriteLine("The account is closed / no operations allowed");
            return 0;
        }

        public bool Withdrawal(decimal _amount)
        {
            if (_amount <= 0)
            {
                Console.WriteLine("The amount should be positive");
                return false;
            }
            if (isActive)
                if (this.amount >= _amount)
                {
                    this.amount -= _amount;
                    Console.WriteLine("transaction completed");
                    this.transactions.Add(new Transaction(DateTime.Now, -_amount));
                    return true;
                }
                else
                {
                    Console.WriteLine("You dont't have enough money");
                    return false;
                }
            else
            {
                Console.WriteLine("The account is closed / no operations allowed");
                return false;
            }
        }

        public bool Charge(decimal _amount)
        {
            if (_amount <= 0)
            {
                Console.WriteLine("The amount should be positive");
                return false;
            }
            if (isActive)
            {
                this.amount += _amount;
                Console.WriteLine("transaction completed");
                this.transactions.Add(new Transaction(DateTime.Now, _amount));
                return true;
            }
            else
            {
                Console.WriteLine("The account is closed / no operations allowed");
                return false;
            }
        }

        public string TransactionsHistory(DateTime? startDate)
        {
            StringBuilder output = new StringBuilder();
            if (!startDate.HasValue)
                if (transactions.Count > 0)
                    startDate = transactions[0].Date;

            foreach (var transaction in transactions)
            {
                if (transaction.Date.CompareTo(startDate) >= 0)
                {
                    output.Append(transaction.ToString());
                    output.Append("\n");
                }
            }

            if (output.Length > 0)
                return output.ToString();
            return String.Format("there was no transaction made after this date");
        }

        public override string ToString()
        {
            return String.Format($"{owner.ToString()}\nOpening Date: {openingDate} \n" +
                $"Current status : {(isActive ? "Active" : "Closed")}\nCurrent amount : {amount}\n");
        }
    }
}
