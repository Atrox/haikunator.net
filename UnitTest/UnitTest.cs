using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestDefaultUse()
        {
            var haikunate = Haikunator.Haikunator.Haikunate();
            StringAssert.Matches(haikunate, new Regex(@"((?:[a-z][a-z]+))(-)((?:[a-z][a-z]+))(-)(\d{4})$", RegexOptions.IgnoreCase | RegexOptions.Singleline));
        }

        [TestMethod]
        public void TestHexUse()
        {
            var haikunate = Haikunator.Haikunator.Haikunate(tokenHex: true);
            StringAssert.Matches(haikunate, new Regex("((?:[a-z][a-z]+))(-)((?:[a-z][a-z]+))(-)(.{4})$", RegexOptions.IgnoreCase | RegexOptions.Singleline));
        }

        [TestMethod]
        public void Test9DigitsUse()
        {
            var haikunate = Haikunator.Haikunator.Haikunate(tokenLength: 9);
            StringAssert.Matches(haikunate, new Regex(@"((?:[a-z][a-z]+))(-)((?:[a-z][a-z]+))(-)(\d{9})$", RegexOptions.IgnoreCase | RegexOptions.Singleline));
        }

        [TestMethod]
        public void Test9DigitsAsHexUse()
        {
            var haikunate = Haikunator.Haikunator.Haikunate(tokenLength: 9, tokenHex: true);
            StringAssert.Matches(haikunate, new Regex("((?:[a-z][a-z]+))(-)((?:[a-z][a-z]+))(-)(.{9})$", RegexOptions.IgnoreCase | RegexOptions.Singleline));
        }

        [TestMethod]
        public void TestWontReturnSameForSubsequentCalls()
        {
            var haikunate = Haikunator.Haikunator.Haikunate();
            var haikunate2 = Haikunator.Haikunator.Haikunate();
            Equals(haikunate, haikunate2);
        }

        [TestMethod]
        public void TestDropsToken()
        {
            var haikunate = Haikunator.Haikunator.Haikunate(tokenLength: 0);
            StringAssert.Matches(haikunate, new Regex("((?:[a-z][a-z]+))(-)((?:[a-z][a-z]+))$", RegexOptions.IgnoreCase | RegexOptions.Singleline));
        }

        [TestMethod]
        public void TestPermitsOptionalDelimiter()
        {
            var haikunate = Haikunator.Haikunator.Haikunate(delimiter: ".");
            StringAssert.Matches(haikunate, new Regex(@"((?:[a-z][a-z]+))(\.)((?:[a-z][a-z]+))(\.)(\d+)$", RegexOptions.IgnoreCase | RegexOptions.Singleline));
        }

        [TestMethod]
        public void TestSpaceDelimiterAndNoToken()
        {
            var haikunate = Haikunator.Haikunator.Haikunate(delimiter: " ", tokenLength: 0);
            StringAssert.Matches(haikunate, new Regex("((?:[a-z][a-z]+))( )((?:[a-z][a-z]+))$", RegexOptions.IgnoreCase | RegexOptions.Singleline));
        }

        [TestMethod]
        public void TestOneSingleWord()
        {
            var haikunate = Haikunator.Haikunator.Haikunate(delimiter: "", tokenLength: 0);
            StringAssert.Matches(haikunate, new Regex("((?:[a-z][a-z]+))$", RegexOptions.IgnoreCase | RegexOptions.Singleline));
        }

        [TestMethod]
        public void TestCustomChars()
        {
            var haikunate = Haikunator.Haikunator.Haikunate(tokenChars: "A");
            StringAssert.Matches(haikunate, new Regex("((?:[a-z][a-z]+))(-)((?:[a-z][a-z]+))(-)(AAAA)$", RegexOptions.IgnoreCase | RegexOptions.Singleline));
        }
    }
}
