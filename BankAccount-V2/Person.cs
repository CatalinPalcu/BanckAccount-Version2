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
            if (!cnp.ValidateCnp())
                throw new Exception("Wrong input for the cnp");

            this.FirstName = firstName;
            this.LastName = lastName;
            this.Address = address;
            this.cnp = cnp;
        }

        public override string ToString()
        {
            return String.Format($"{FirstName} {LastName}\t Cnp : {Cnp}\nAddress {Address}");
        }

    }
}
