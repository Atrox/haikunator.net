using NUnit.Framework;

namespace Haikunator.Tests
{
    [TestFixture]
    public class HaikunateTests
    {
        [SetUp]
        public void SetUp()
        {
            _haikunator = new Atrox.Haikunator();
        }

        private Atrox.Haikunator _haikunator;

        [Test]
        public void Test9DigitsAsHexUse()
        {
            StringAssert.IsMatch(@"((?:[a-z][a-z]+))(-)((?:[a-z][a-z]+))(-)(.{9})$",
                _haikunator.Haikunate(tokenLength: 9, tokenHex: true));
        }

        [Test]
        public void Test9DigitsUse()
        {
            StringAssert.IsMatch(@"((?:[a-z][a-z]+))(-)((?:[a-z][a-z]+))(-)(\d{9})$",
                _haikunator.Haikunate(tokenLength: 9));
        }

        [Test]
        public void TestCustomAdjectivesAndNouns()
        {
            var haikunator = new Atrox.Haikunator
            {
                Adjectives = new[] {"red"},
                Nouns = new[] {"reindeer"}
            };

            StringAssert.IsMatch(@"(red)(-)(reindeer)(-)(\d{4})$", haikunator.Haikunate());
        }

        [Test]
        public void TestCustomChars()
        {
            StringAssert.IsMatch(@"((?:[a-z][a-z]+))(-)((?:[a-z][a-z]+))(-)(AAAA)$",
                _haikunator.Haikunate(tokenChars: "A"));
        }

        [Test]
        public void TestCustomRandom()
        {
            var haikunator1 = new Atrox.Haikunator(1234);
            var haikunator2 = new Atrox.Haikunator(1234);

            Assert.AreEqual(haikunator1.Haikunate(), haikunator2.Haikunate());
        }

        [Test]
        public void TestCustomWords()
        {
            _haikunator.Adjectives = new[] {"haiku"};
            _haikunator.Nouns = new[] {"nator"};

            StringAssert.IsMatch(@"(haiku)(-)(nator)$", _haikunator.Haikunate(tokenLength: 0));
        }

        [Test]
        public void TestDefaultUse()
        {
            StringAssert.IsMatch(@"((?:[a-z][a-z]+))(-)((?:[a-z][a-z]+))(-)(\d{4})$", _haikunator.Haikunate());
        }

        [Test]
        public void TestDropsToken()
        {
            StringAssert.IsMatch(@"((?:[a-z][a-z]+))(-)((?:[a-z][a-z]+))$", _haikunator.Haikunate(tokenLength: 0));
        }

        [Test]
        public void TestHexUse()
        {
            StringAssert.IsMatch(@"((?:[a-z][a-z]+))(-)((?:[a-z][a-z]+))(-)(.{4})$",
                _haikunator.Haikunate(tokenHex: true));
        }

        [Test]
        public void TestOneSingleWord()
        {
            StringAssert.IsMatch(@"((?:[a-z][a-z]+))$", _haikunator.Haikunate("", 0));
        }

        [Test]
        public void TestPermitsOptionalDelimiter()
        {
            StringAssert.IsMatch(@"((?:[a-z][a-z]+))(\.)((?:[a-z][a-z]+))(\.)(\d+)$", _haikunator.Haikunate("."));
        }

        [Test]
        public void TestRemoveAdjectivesAndNouns()
        {
            var haikunator = new Atrox.Haikunator
            {
                Adjectives = new string[0],
                Nouns = new string[0]
            };

            StringAssert.IsMatch(@"(\d{4})$", haikunator.Haikunate());
        }

        [Test]
        public void TestSpaceDelimiterAndNoToken()
        {
            StringAssert.IsMatch(@"((?:[a-z][a-z]+))( )((?:[a-z][a-z]+))$", _haikunator.Haikunate(" ", 0));
        }

        [Test]
        public void TestWontReturnSameForSubsequentCalls()
        {
            Assert.AreNotEqual(_haikunator.Haikunate(), _haikunator.Haikunate());
        }
    }
}