using System.Linq;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace Quantum2
{
    public static class ComplexExtension
    {
        public static string TS(this Complex number)
        {
            string result = number.Real.ToString();

            if(number.Imaginary >= 0)
            {
                result += " + " + number.Imaginary + "i";
            }
            else
            {
                result += number.Imaginary + "i";
            }

            return result;
        }

        public static Complex Parse(string complexString)
        {
            Complex resultComplex = Complex.Zero;

            complexString = complexString.Replace(" ", "");
            complexString = complexString.Replace(".", ",");

            List < string> partsComplexNumber = new List<string>( complexString.SplitKeepSeparators(new char[] { '+', '-'}));

            for(int i = 0; i < partsComplexNumber.Count;i++)
            {
                if(partsComplexNumber[i] == "")
                {
                    partsComplexNumber.RemoveAt(i);
                }
            }

            if (partsComplexNumber.Count > 4 || partsComplexNumber.Count == 0)
                throw new FormatException("Incorrect number format!");

            if (partsComplexNumber.Count == 4)
            {
                string strNumberOne = partsComplexNumber[0] + partsComplexNumber[1];
                string strNumberTwo = partsComplexNumber[2] + partsComplexNumber[3];


                resultComplex = CreateComplexNumber(strNumberOne, strNumberTwo);
            }
            else if(partsComplexNumber.Count == 3)
            {
                if(partsComplexNumber[0] == "+" || partsComplexNumber[0] == "-")
                {
                    throw new FormatException("Incorrect number format!");
                }

                if(partsComplexNumber[1] == "+" || partsComplexNumber[1] == "-")
                {
                    string strNumberOne = partsComplexNumber[0];
                    string strNumberTwo = partsComplexNumber[1] + partsComplexNumber[2];

                    resultComplex = CreateComplexNumber(strNumberOne, strNumberTwo);
                }
            }
            else if(partsComplexNumber.Count == 2)
            {

                string strNumberOne = partsComplexNumber[0] + partsComplexNumber[1];

                resultComplex = CreateComplexNumber(strNumberOne, "0");
            }
            else if(partsComplexNumber.Count == 1)
            {
                if(partsComplexNumber[0] == "-")
                    throw new FormatException("Incorrect number format!");
                if(partsComplexNumber[0] == "+")
                    throw new FormatException("Incorrect number format!");

                resultComplex = CreateComplexNumber(partsComplexNumber[0], "0");
            }

            return resultComplex;
        }

        private static Complex CreateComplexNumber(string strNumberOne, string strNumberTwo)
        {
            if(strNumberTwo == "0")
            {
                if (strNumberOne.Contains('i'))
                {
                    strNumberOne = strNumberOne.Replace("i", "");
                    return new Complex(0, double.Parse(strNumberOne));
                }
                else
                {
                    return new Complex(double.Parse(strNumberOne), 0);
                }
            }
            if (strNumberOne.Contains('i'))
            {
                strNumberOne = strNumberOne.Replace("i", "");
                return new Complex(double.Parse(strNumberTwo), double.Parse(strNumberOne));
            }
            else if (strNumberTwo.Contains('i'))
            {
                strNumberTwo = strNumberTwo.Replace("i", "");
                return new Complex(double.Parse(strNumberOne), double.Parse(strNumberTwo));
            }
            else
            {
                throw new Exception("Incorrect number format!");
            }

            //return Complex.Zero;
        }
      
    }
}
