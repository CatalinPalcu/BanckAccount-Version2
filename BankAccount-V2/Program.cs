using System;

namespace BankAccount_V2
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person("Catalin", "Palcu", "Iasi", 1870829451806);

            Account acc1 = new Account(person1);
            acc1.Charge(2000);
            acc1.Withdrawal(2500);
            acc1.Withdrawal(1500);
            acc1.CloseAccount();
            acc1.Charge(1500);
            acc1.ActivateAccount();
            acc1.Charge(1500);
            acc1.Withdrawal(2000);

            Console.WriteLine(acc1.ToString());
            Console.WriteLine(acc1.TransactionsHistory(null));
        }
    }
}
