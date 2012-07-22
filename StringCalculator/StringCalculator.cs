using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace StringCalculator
{
    public class StringCalculator
    {
        protected string NumbersString { get; set; }
        protected string[] NumbersArray { get; set; }

        public int Add(string numbers)
        {
            this.NumbersString = numbers;

            if (IsEmptyNumbers())
                return 0;

            SplitNumberStringInArray();

            CheckIfExistNegativeNumbers();

            RemoveNumbersBigThan1000();

            return NumbersArray.Sum(x => int.Parse(x));

        }

        private bool IsEmptyNumbers()
        {
            return string.IsNullOrEmpty(NumbersString);
        }

        private void SplitNumberStringInArray()
        {
            string[] Delimiters = ConfigureDelimiters();

            Regex f = new Regex(@"(\d+)");

            NumbersArray = f.Split(NumbersString);

            NumbersArray = NumbersString.Split(Delimiters, StringSplitOptions.RemoveEmptyEntries);
        }

        private string[] ConfigureDelimiters()
        {
            //Char[] Delimiters = { ',', Convert.ToChar('\n') };
            List<string> Delimiters = new List<string>();
            Delimiters.Add(",");
            Delimiters.Add("\n");

            Regex regularExpresion = new Regex(@"(?<=\[)(.*?)(?=\])");
            var matches = regularExpresion.Matches(NumbersString);

            foreach (Match mach in matches)
                Delimiters.Add(mach.Value);
            


            //if (NumbersString.StartsWith("//"))
            //{
            //    Delimiters[0] = Convert.ToChar(NumbersString.Substring(2, 1));
            //    NumbersString = NumbersString.Remove(0, 2);
            //}

            return Delimiters.ToArray();
        }

        protected void CheckIfExistNegativeNumbers()
        {
            var numbersNegative = NumbersArray.Where(x => int.Parse(x) < 0);
            if (numbersNegative.Any())
                throw new ApplicationException("Negatives not allowed: " + string.Join(", ", numbersNegative.ToArray()));
            
        }

        protected void RemoveNumbersBigThan1000()
        {
            var num = NumbersArray.ToList();
            num.RemoveAll(x => int.Parse(x) > 1000);
            NumbersArray = num.ToArray();
        }
    }
}
