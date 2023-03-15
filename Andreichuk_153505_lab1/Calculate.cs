using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Andreichuk_153505_lab1
{
    public static class Calculate
    {
        public static double Calculation(double value1, double value2, string mathOperation)
        {
            double result = 0;
            switch (mathOperation)
            {
                case "+":
                    result= value1+value2;
                    break;
                case "-":
                    result= value1-value2;
                    break;
                case "x":
                    result = value1 * value2;
                    break;
                case "÷":
                    result=value1/value2;
                    break;
            }
            return result;
        }
    }
}
