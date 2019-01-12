using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount_V2
{ 

    class Transaction
    {
        private readonly DateTime date;
        private readonly decimal amount;

        public Transaction(DateTime date, decimal amount)
        {
            this.date = date;
            this.amount = amount;
        }

        public DateTime Date
        {
            get
            {
                return this.date;
            }
        }

        public decimal Amount
        {
            get
            {
                return this.amount;
            }
        }

        public override string ToString()
        {
            if (amount > 0)
                return String.Format($"charging :\t {date.ToShortDateString()} \t {amount} ");
            return String.Format($"withdrawal :\t {date.ToShortDateString()} \t {-amount} ");
        }

    }
}
