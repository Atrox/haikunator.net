using NUnit.Framework;
using System;

namespace Haikunator.Tests
{
	[TestFixture]
	public class Test
	{
		[Test]
		public void TestDefaultUse()
		{
			var haikunator = new Atrox.Haikunator();
			StringAssert.IsMatch(@"((?:[a-z][a-z]+))(-)((?:[a-z][a-z]+))(-)(\d{4})$", haikunator.Haikunate());
		}

		[Test]
		public void TestHexUse()
		{
			var haikunator = new Atrox.Haikunator();
			StringAssert.IsMatch(@"((?:[a-z][a-z]+))(-)((?:[a-z][a-z]+))(-)(.{4})$", haikunator.Haikunate(tokenHex: true));
		}

		[Test]
		public void Test9DigitsUse()
		{
			var haikunator = new Atrox.Haikunator();
			StringAssert.IsMatch(@"((?:[a-z][a-z]+))(-)((?:[a-z][a-z]+))(-)(\d{9})$", haikunator.Haikunate(tokenLength: 9));
		}

		[Test]
		public void Test9DigitsAsHexUse()
		{
			var haikunator = new Atrox.Haikunator();
			StringAssert.IsMatch(@"((?:[a-z][a-z]+))(-)((?:[a-z][a-z]+))(-)(.{9})$", haikunator.Haikunate(tokenLength: 9, tokenHex: true));
		}

		[Test]
		public void TestWontReturnSameForSubsequentCalls()
		{
			var haikunator = new Atrox.Haikunator();
			Assert.AreNotEqual(haikunator.Haikunate(), haikunator.Haikunate());
		}

		[Test]
		public void TestDropsToken()
		{
			var haikunator = new Atrox.Haikunator();
			StringAssert.IsMatch(@"((?:[a-z][a-z]+))(-)((?:[a-z][a-z]+))$", haikunator.Haikunate(tokenLength: 0));
		}

		[Test]
		public void TestPermitsOptionalDelimiter()
		{
			var haikunator = new Atrox.Haikunator();
			StringAssert.IsMatch(@"((?:[a-z][a-z]+))(\.)((?:[a-z][a-z]+))(\.)(\d+)$", haikunator.Haikunate(delimiter: "."));
		}

		[Test]
		public void TestSpaceDelimiterAndNoToken()
		{
			var haikunator = new Atrox.Haikunator();
			StringAssert.IsMatch(@"((?:[a-z][a-z]+))( )((?:[a-z][a-z]+))$", haikunator.Haikunate(delimiter: " ", tokenLength: 0));
		}

		[Test]
		public void TestOneSingleWord()
		{
			var haikunator = new Atrox.Haikunator();
			StringAssert.IsMatch(@"((?:[a-z][a-z]+))$", haikunator.Haikunate(delimiter: "", tokenLength: 0));
		}

		[Test]
		public void TestCustomChars()
		{
			var haikunator = new Atrox.Haikunator();
			StringAssert.IsMatch(@"((?:[a-z][a-z]+))(-)((?:[a-z][a-z]+))(-)(AAAA)$", haikunator.Haikunate(tokenChars: "A"));
		}

		[Test]
		public void TestCustomWords()
		{
			var haikunator = new Atrox.Haikunator { Adjectives = new[] {"haiku"}, Nouns = new [] {"nator"}};
			StringAssert.IsMatch(@"(haiku)(-)(nator)$", haikunator.Haikunate(tokenLength: 0));
		}
	}
}

