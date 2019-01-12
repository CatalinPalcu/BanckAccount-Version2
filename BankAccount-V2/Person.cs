using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount_V2
{
    public class Person
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Address { get; private set; }
        private readonly long cnp;

        public long Cnp
        {
            get { return cnp; }
        }

        public Person(string firstName, string lastName, string address, long cnp)
        {
            if (!ValidateCnp(cnp))
                throw new Exception("Wrong input for the cnp");

            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.cnp = cnp;
        }

        public static bool ValidateCnp(long cnp)
        {
            if (NrOfDigits(cnp) != 13)
                return false;

            return true;
        }

        public static int NrOfDigits(long number)
        {
            int nrDigits = 0;
            while (number > 10)
            {
                nrDigits++;
                number = number / 10;
            }
            nrDigits++;

            return nrDigits;

        }

        public override string ToString()
        {
            return String.Format($"{FirstName} {LastName}\t Cnp : {Cnp}\nAddress {Address}");
        }

    }
}
