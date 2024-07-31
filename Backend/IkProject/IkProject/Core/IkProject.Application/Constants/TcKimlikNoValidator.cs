using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Constants
{
    public static class TcKimlikNoValidator
    {
        public static bool Validate(string identityNo)
        {
            if (identityNo.Length != 11)
                return false;   

            long parsedNumber;
            if (!long.TryParse(identityNo, out parsedNumber))
                return false;

            // TC kimlik numarası algoritması
            int[] digits = identityNo.Select(c => int.Parse(c.ToString())).ToArray();
            int sumOdd = digits[0] + digits[2] + digits[4] + digits[6] + digits[8];
            int sumEven = digits[1] + digits[3] + digits[5] + digits[7];
            int lastDigit = (sumOdd * 7 - sumEven) % 10;

            return digits[9] == lastDigit && digits.Take(10).Sum() % 10 == digits[10];
        }
    }
}
