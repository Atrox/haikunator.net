using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void testDefaultUse()
        {
            string haikunate = Haikunator.Haikunator.haikunate();
            StringAssert.Matches(haikunate, new Regex("((?:[a-z][a-z]+))(-)((?:[a-z][a-z]+))(-)(\\d{4})$", RegexOptions.IgnoreCase | RegexOptions.Singleline));
        }

        [TestMethod]
        public void testHexUse()
        {
            string haikunate = Haikunator.Haikunator.haikunate(tokenHex: true);
            StringAssert.Matches(haikunate, new Regex("((?:[a-z][a-z]+))(-)((?:[a-z][a-z]+))(-)(.{4})$", RegexOptions.IgnoreCase | RegexOptions.Singleline));
        }

        [TestMethod]
        public void test9DigitsUse()
        {
            string haikunate = Haikunator.Haikunator.haikunate(tokenLength: 9);
            StringAssert.Matches(haikunate, new Regex("((?:[a-z][a-z]+))(-)((?:[a-z][a-z]+))(-)(\\d{9})$", RegexOptions.IgnoreCase | RegexOptions.Singleline));
        }

        [TestMethod]
        public void test9DigitsAsHexUse()
        {
            string haikunate = Haikunator.Haikunator.haikunate(tokenLength: 9, tokenHex: true);
            StringAssert.Matches(haikunate, new Regex("((?:[a-z][a-z]+))(-)((?:[a-z][a-z]+))(-)(.{9})$", RegexOptions.IgnoreCase | RegexOptions.Singleline));
        }

        [TestMethod]
        public void testWontReturnSameForSubsequentCalls()
        {
            string haikunate = Haikunator.Haikunator.haikunate();
            string haikunate2 = Haikunator.Haikunator.haikunate();
            StringAssert.Equals(haikunate, haikunate2);
        }

        [TestMethod]
        public void testDropsToken()
        {
            string haikunate = Haikunator.Haikunator.haikunate(tokenLength: 0);
            StringAssert.Matches(haikunate, new Regex("((?:[a-z][a-z]+))(-)((?:[a-z][a-z]+))$", RegexOptions.IgnoreCase | RegexOptions.Singleline));
        }

        [TestMethod]
        public void testPermitsOptionalDelimiter()
        {
            string haikunate = Haikunator.Haikunator.haikunate(delimiter: ".");
            StringAssert.Matches(haikunate, new Regex("((?:[a-z][a-z]+))(\\.)((?:[a-z][a-z]+))(\\.)(\\d+)$", RegexOptions.IgnoreCase | RegexOptions.Singleline));
        }

        [TestMethod]
        public void testSpaceDelimiterAndNoToken()
        {
            string haikunate = Haikunator.Haikunator.haikunate(delimiter: " ", tokenLength: 0);
            StringAssert.Matches(haikunate, new Regex("((?:[a-z][a-z]+))( )((?:[a-z][a-z]+))$", RegexOptions.IgnoreCase | RegexOptions.Singleline));
        }

        [TestMethod]
        public void testOneSingleWord()
        {
            string haikunate = Haikunator.Haikunator.haikunate(delimiter: "", tokenLength: 0);
            StringAssert.Matches(haikunate, new Regex("((?:[a-z][a-z]+))$", RegexOptions.IgnoreCase | RegexOptions.Singleline));
        }

        [TestMethod]
        public void testCustomChars()
        {
            string haikunate = Haikunator.Haikunator.haikunate(tokenChars: "A");
            StringAssert.Matches(haikunate, new Regex("((?:[a-z][a-z]+))(-)((?:[a-z][a-z]+))(-)(AAAA)$", RegexOptions.IgnoreCase | RegexOptions.Singleline));
        }
    }
}
