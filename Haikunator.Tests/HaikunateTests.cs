using NUnit.Framework;

namespace Haikunator.Tests
{
	[TestFixture]
	public class HaikunateTests
	{
		private Atrox.Haikunator haikunator;

		[SetUp]
		public void SetUp()
		{
			haikunator = new Atrox.Haikunator();
		}

		[Test]
		public void TestDefaultUse()
		{
			StringAssert.IsMatch(@"((?:[a-z][a-z]+))(-)((?:[a-z][a-z]+))(-)(\d{4})$", haikunator.Haikunate());
		}

		[Test]
		public void TestHexUse()
		{
			StringAssert.IsMatch(@"((?:[a-z][a-z]+))(-)((?:[a-z][a-z]+))(-)(.{4})$", haikunator.Haikunate(tokenHex: true));
		}

		[Test]
		public void Test9DigitsUse()
		{
			StringAssert.IsMatch(@"((?:[a-z][a-z]+))(-)((?:[a-z][a-z]+))(-)(\d{9})$", haikunator.Haikunate(tokenLength: 9));
		}

		[Test]
		public void Test9DigitsAsHexUse()
		{
			StringAssert.IsMatch(@"((?:[a-z][a-z]+))(-)((?:[a-z][a-z]+))(-)(.{9})$", haikunator.Haikunate(tokenLength: 9, tokenHex: true));
		}

		[Test]
		public void TestWontReturnSameForSubsequentCalls()
		{
			Assert.AreNotEqual(haikunator.Haikunate(), haikunator.Haikunate());
		}

		[Test]
		public void TestDropsToken()
		{
			StringAssert.IsMatch(@"((?:[a-z][a-z]+))(-)((?:[a-z][a-z]+))$", haikunator.Haikunate(tokenLength: 0));
		}

		[Test]
		public void TestPermitsOptionalDelimiter()
		{
			StringAssert.IsMatch(@"((?:[a-z][a-z]+))(\.)((?:[a-z][a-z]+))(\.)(\d+)$", haikunator.Haikunate(delimiter: "."));
		}

		[Test]
		public void TestSpaceDelimiterAndNoToken()
		{
			StringAssert.IsMatch(@"((?:[a-z][a-z]+))( )((?:[a-z][a-z]+))$", haikunator.Haikunate(delimiter: " ", tokenLength: 0));
		}

		[Test]
		public void TestOneSingleWord()
		{
			StringAssert.IsMatch(@"((?:[a-z][a-z]+))$", haikunator.Haikunate(delimiter: "", tokenLength: 0));
		}

		[Test]
		public void TestCustomChars()
		{
			StringAssert.IsMatch(@"((?:[a-z][a-z]+))(-)((?:[a-z][a-z]+))(-)(AAAA)$", haikunator.Haikunate(tokenChars: "A"));
		}

		[Test]
		public void TestCustomWords()
		{
			haikunator.Adjectives = new[] { "haiku" };
			haikunator.Nouns = new[] { "nator" };

			StringAssert.IsMatch(@"(haiku)(-)(nator)$", haikunator.Haikunate(tokenLength: 0));
		}
	}
}

