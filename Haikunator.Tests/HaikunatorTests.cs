using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace Haikunator.Tests
{
    public class HaikunatorTests
    {
        private readonly Haikunator _haikunator = new Haikunator();
        private readonly MethodInfo _haikunate = typeof(Haikunator).GetMethod("Haikunate");

        public static IEnumerable<object[]> TestGeneralFunctionalityData =>
            new List<object[]>
            {
                new object[] {new Dictionary<string, object>(), @"[a-z]+-[a-z]+-[0-9]{4}$"},
                new object[] {new Dictionary<string, object> {{"tokenHex", true}}, "[a-z]+-[a-z]+-[0-f]{4}$"},
                new object[] {new Dictionary<string, object> {{"tokenLength", 9}}, "[a-z]+-[a-z]+-[0-9]{9}$"},
                new object[] {new Dictionary<string, object> {{"tokenLength", 9}, {"tokenHex", true}}, "[a-z]+-[a-z]+-[0-f]{9}$"},
                new object[] {new Dictionary<string, object> {{"tokenLength", 0}}, "[a-z]+-[a-z]+$"},
                new object[] {new Dictionary<string, object> {{"delimiter", "."}}, "[a-z]+.[a-z]+.[0-9]{4}$"},
                new object[] {new Dictionary<string, object> {{"delimiter", " "}, {"tokenLength", 0}}, "[a-z]+ [a-z]+$"},
                new object[] {new Dictionary<string, object> {{"delimiter", ""}, {"tokenLength", 0}}, "[a-z]+$"},
                new object[] {new Dictionary<string, object> {{"tokenChars", "xyz"}}, "[a-z]+-[a-z]+-[x-z]{4}$"},
            };

        [Theory]
        [MemberData(nameof(TestGeneralFunctionalityData))]
        public void TestGeneralFunctionality(Dictionary<string, object> parameters, string regex)
        {
            var haikunate = (string) _haikunate.InvokeWithNamedParameters(_haikunator, parameters);
            Assert.Matches(regex, haikunate);
        }

        [Fact]
        public void TestWontReturnSameForSubsequentCalls()
        {
            var haikunators = new[] {new Haikunator(), new Haikunator(),};

            foreach (var h1 in haikunators)
            foreach (var h2 in haikunators)
                Assert.NotEqual(h1.Haikunate(), h2.Haikunate());
        }

        [Fact]
        public void TestReturnsSameForSameSeed()
        {
            const int seed = 1001;

            var h1 = new Haikunator(seed);
            var h2 = new Haikunator(seed);

            Assert.Equal(h1.Haikunate(), h2.Haikunate());
            Assert.Equal(h1.Haikunate(), h2.Haikunate());
        }

        [Fact]
        public void TestZeroLengthOptionsException()
        {
            var haikunator = new Haikunator {Adjectives = null, Nouns = null};
            Assert.Equal("", haikunator.Haikunate(tokenChars: null));
        }
    }
}