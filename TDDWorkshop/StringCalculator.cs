using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDWorkshop
{
    public class StringCalculator
    {
        public static int Calculate(string str)
        {
            if (string.IsNullOrEmpty(str))
                return 0;

            string[] valuesStr;
            if (str.StartsWith("//") && str[3] == '\n')
               valuesStr = str[4..].Split(',', '\n', str[2]);
            else
                valuesStr = str.Split(',', '\n');
            int sum = 0;
            foreach (string strVal in valuesStr)
                if (int.TryParse(strVal, out var val))
                {
                    if (val > 1000)
                        continue;
                    if (val < 0)
                        throw new ArgumentException();
                    sum += val;
                }
                else
                    throw new ArgumentException();

            return sum;
        }
    }
}
