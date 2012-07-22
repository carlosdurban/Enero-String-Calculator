using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StringCalculator;
using NUnit;
using NUnit.Framework;

namespace StringCalculatorTest
{
    [TestFixture]
    public class StringCalculatorTest
    {

        [Test]
        public void ForStringEmptyReturnZero()
        {
            string numbers = "";

            Assert.AreEqual(0, new StringCalculator.StringCalculator().Add(numbers));

        }

        [Test]
        public void AddOneNumberReturnThis()
        {
            string numbers = "1";

            Assert.AreEqual(1, new StringCalculator.StringCalculator().Add(numbers));
        }
        
        [Test]
        public void AddNumbersReturnSum()
        {
            string numbers = "1, 0, 2";

            Assert.AreEqual(3, new StringCalculator.StringCalculator().Add(numbers));
        }

        [Test]
        public void AddNewLinesInNumberReturnSum()
        {
            string numbers = "1\n0, 2";

            Assert.AreEqual(3, new StringCalculator.StringCalculator().Add(numbers));
        }

        [Test]
        public void ChangeDefaultDelimiter()
        {
            string numbers = "//;\n1;2";

            Assert.AreEqual(3, new StringCalculator.StringCalculator().Add(numbers));
        }

        [Test]
        public void NegativeNumberNotAllowedThrowException()
        {
            string numbers = "1,-2";
            try
            {
                new StringCalculator.StringCalculator().Add(numbers);
                Assert.Fail("Fail Test, exception expected");
            }
            catch (ApplicationException ex)
            {
                Assert.AreEqual("Negatives not allowed: -2", ex.Message);
            }
        }

        [Test]
        public void NegativeNumbersNotAllowedThrowException()
        {
            string numbers = "1,-2,-3";
            try
            {
                new StringCalculator.StringCalculator().Add(numbers);
                Assert.Fail("Fail Test, exception expected");
            }
            catch (ApplicationException ex)
            {
                Assert.AreEqual("Negatives not allowed: -2, -3", ex.Message);
            }
        }

        [Test]
        public void NumbersBigThan1000Ignored()
        {
            string numbers = "1,1001";

            Assert.AreEqual(1, new StringCalculator.StringCalculator().Add(numbers));
        }

        [Test]
        public void DelimiterCanBeAnyLength()
        {
            string numbers = "//[***]\n1***2***3";

            Assert.AreEqual(6, new StringCalculator.StringCalculator().Add(numbers));
        }

        

    }
}
