using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount_V2
{
    public static class Extensions
    {
        public static bool ValidateCnp(this long cnp)
        {
            if (cnp.NrOfDigits() != 13)
                return false;

            string month = cnp.ToString().Substring(3, 2);
            string day = cnp.ToString().Substring(5, 2);
            int year = Int32.Parse(cnp.ToString().Substring(1, 2));
            year = ((year > DateTime.Now.Year % 100) ? 1900 : 2000) + year;

            DateTime nastere;
            bool isGood = DateTime.TryParse(String.Format($"{year}/{month}/{day}"), out nastere);

            return isGood;
        }

        public static int NrOfDigits(this long number)
        {
            number = Math.Abs(number);

            int nrDigits = 0;
            while (number > 10)
            {
                nrDigits++;
                number = number / 10;
            }
            nrDigits++;

            return nrDigits;

        }
    }
}
