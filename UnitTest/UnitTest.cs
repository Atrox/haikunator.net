using System.Text.RegularExpressions;
using Atrox;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestDefaultUse()
        {
            var haikunator = new Haikunator();
            StringAssert.Matches(haikunator.Haikunate(), new Regex(@"((?:[a-z][a-z]+))(-)((?:[a-z][a-z]+))(-)(\d{4})$", RegexOptions.IgnoreCase | RegexOptions.Singleline));
        }

        [TestMethod]
        public void TestHexUse()
        {
            var haikunator = new Haikunator();
            StringAssert.Matches(haikunator.Haikunate(tokenHex: true), new Regex("((?:[a-z][a-z]+))(-)((?:[a-z][a-z]+))(-)(.{4})$", RegexOptions.IgnoreCase | RegexOptions.Singleline));
        }

        [TestMethod]
        public void Test9DigitsUse()
        {
            var haikunator = new Haikunator();
            StringAssert.Matches(haikunator.Haikunate(tokenLength: 9), new Regex(@"((?:[a-z][a-z]+))(-)((?:[a-z][a-z]+))(-)(\d{9})$", RegexOptions.IgnoreCase | RegexOptions.Singleline));
        }

        [TestMethod]
        public void Test9DigitsAsHexUse()
        {
            var haikunator = new Haikunator();
            StringAssert.Matches(haikunator.Haikunate(tokenLength: 9, tokenHex: true), new Regex("((?:[a-z][a-z]+))(-)((?:[a-z][a-z]+))(-)(.{9})$", RegexOptions.IgnoreCase | RegexOptions.Singleline));
        }

        [TestMethod]
        public void TestWontReturnSameForSubsequentCalls()
        {
            var haikunator = new Haikunator();
            Equals(haikunator.Haikunate(), haikunator.Haikunate());
        }

        [TestMethod]
        public void TestDropsToken()
        {
            var haikunator = new Haikunator();
            StringAssert.Matches(haikunator.Haikunate(tokenLength: 0), new Regex("((?:[a-z][a-z]+))(-)((?:[a-z][a-z]+))$", RegexOptions.IgnoreCase | RegexOptions.Singleline));
        }

        [TestMethod]
        public void TestPermitsOptionalDelimiter()
        {
            var haikunator = new Haikunator();
            StringAssert.Matches(haikunator.Haikunate(delimiter: "."), new Regex(@"((?:[a-z][a-z]+))(\.)((?:[a-z][a-z]+))(\.)(\d+)$", RegexOptions.IgnoreCase | RegexOptions.Singleline));
        }

        [TestMethod]
        public void TestSpaceDelimiterAndNoToken()
        {
            var haikunator = new Haikunator();
            StringAssert.Matches(haikunator.Haikunate(delimiter: " ", tokenLength: 0), new Regex("((?:[a-z][a-z]+))( )((?:[a-z][a-z]+))$", RegexOptions.IgnoreCase | RegexOptions.Singleline));
        }

        [TestMethod]
        public void TestOneSingleWord()
        {
            var haikunator = new Haikunator();
            StringAssert.Matches(haikunator.Haikunate(delimiter: "", tokenLength: 0), new Regex("((?:[a-z][a-z]+))$", RegexOptions.IgnoreCase | RegexOptions.Singleline));
        }

        [TestMethod]
        public void TestCustomChars()
        {
            var haikunator = new Haikunator();
            StringAssert.Matches(haikunator.Haikunate(tokenChars: "A"), new Regex("((?:[a-z][a-z]+))(-)((?:[a-z][a-z]+))(-)(AAAA)$", RegexOptions.IgnoreCase | RegexOptions.Singleline));
        }

        [TestMethod]
        public void TestCustomWords()
        {
            var haikunator = new Haikunator { Adjectives = new[] {"haiku"}, Nouns = new [] {"nator"}};
            StringAssert.Matches(haikunator.Haikunate(tokenLength: 0), new Regex("(haiku)(-)(nator)$", RegexOptions.IgnoreCase | RegexOptions.Singleline));
        }
    }
}
