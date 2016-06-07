using System;
using System.Collections.Generic;
using System.Linq;

namespace Atrox
{
    public class Haikunator
    {
        private readonly Random _random;

        public string[] Adjectives =
        {
            "aged", "ancient", "autumn", "billowing", "bitter", "black", "blue", "bold",
            "broad", "broken", "calm", "cold", "cool", "crimson", "curly", "damp",
            "dark", "dawn", "delicate", "divine", "dry", "empty", "falling", "fancy",
            "flat", "floral", "fragrant", "frosty", "gentle", "green", "hidden", "holy",
            "icy", "jolly", "late", "lingering", "little", "lively", "long", "lucky",
            "misty", "morning", "muddy", "mute", "nameless", "noisy", "odd", "old",
            "orange", "patient", "plain", "polished", "proud", "purple", "quiet", "rapid",
            "raspy", "red", "restless", "rough", "round", "royal", "shiny", "shrill",
            "shy", "silent", "small", "snowy", "soft", "solitary", "sparkling", "spring",
            "square", "steep", "still", "summer", "super", "sweet", "throbbing", "tight",
            "tiny", "twilight", "wandering", "weathered", "white", "wild", "winter", "wispy",
            "withered", "yellow", "young"
        };

        public string[] Nouns =
        {
            "art", "band", "bar", "base", "bird", "block", "boat", "bonus",
            "bread", "breeze", "brook", "bush", "butterfly", "cake", "cell", "cherry",
            "cloud", "credit", "darkness", "dawn", "dew", "disk", "dream", "dust",
            "feather", "field", "fire", "firefly", "flower", "fog", "forest", "frog",
            "frost", "glade", "glitter", "grass", "hall", "hat", "haze", "heart",
            "hill", "king", "lab", "lake", "leaf", "limit", "math", "meadow",
            "mode", "moon", "morning", "mountain", "mouse", "mud", "night", "paper",
            "pine", "poetry", "pond", "queen", "rain", "recipe", "resonance", "rice",
            "river", "salad", "scene", "sea", "shadow", "shape", "silence", "sky",
            "smoke", "snow", "snowflake", "sound", "star", "sun", "sun", "sunset",
            "surf", "term", "thunder", "tooth", "tree", "truth", "union", "unit",
            "violet", "voice", "water", "water", "waterfall", "wave", "wildflower", "wind",
            "wood"
        };

        public Haikunator()
        {
            _random = new Random();
        }

        public Haikunator(int seed)
        {
            _random = new Random(seed);
        }

        /// <summary>
        ///     Generate Heroku-like random names
        /// </summary>
        /// <param name="delimiter">Delimiter</param>
        /// <param name="tokenLength">Token Length</param>
        /// <param name="tokenHex">Token Hex (true/false)</param>
        /// <param name="tokenChars">Token Chars</param>
        /// <returns>Returns heroku-like string</returns>
        public string Haikunate(string delimiter = "-", int tokenLength = 4, bool tokenHex = false,
            string tokenChars = "0123456789")
        {
            if (tokenHex) tokenChars = "0123456789abcdef";

            var adjective = RandomString(Adjectives);
            var noun = RandomString(Nouns);

            var token = "";
            if (tokenChars.Length > 0)
            {
                for (var i = 0; i < tokenLength; i++)
                {
                    token += tokenChars[_random.Next(tokenChars.Length)];
                }
            }

            string[] sections = {adjective, noun, token};
            return string.Join(delimiter, sections.Where(s => !string.IsNullOrEmpty(s)));
        }

        private string RandomString(IReadOnlyList<string> s)
        {
            var length = s.Count;
            if (length <= 0) return "";

            return s[_random.Next(length)];
        }
    }
}