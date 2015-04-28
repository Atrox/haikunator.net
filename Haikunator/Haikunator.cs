using System;
using System.Linq;

namespace Atrox
{
    public class Haikunator
    {
        private readonly Random _rnd = new Random();
        public string[] Adjectives = {
            "autumn", "hidden", "bitter", "misty", "silent", "empty", "dry", "dark",
            "summer", "icy", "delicate", "quiet", "white", "cool", "spring", "winter",
            "patient", "twilight", "dawn", "crimson", "wispy", "weathered", "blue",
            "billowing", "broken", "cold", "damp", "falling", "frosty", "green",
            "long", "late", "lingering", "bold", "little", "morning", "muddy", "old",
            "red", "rough", "still", "small", "sparkling", "throbbing", "shy",
            "wandering", "withered", "wild", "black", "young", "holy", "solitary",
            "fragrant", "aged", "snowy", "proud", "floral", "restless", "divine",
            "polished", "ancient", "purple", "lively", "nameless", "lucky", "odd", "tiny",
            "free", "dry", "yellow", "orange", "gentle", "tight", "super", "royal", "broad",
            "steep", "flat", "square", "round", "mute", "noisy", "hushy", "raspy", "soft",
            "shrill", "rapid", "sweet", "curly", "calm", "jolly", "fancy", "plain", "shinny"
        };
        public string[] Nouns = {
            "waterfall", "river", "breeze", "moon", "rain", "wind", "sea", "morning",
            "snow", "lake", "sunset", "pine", "shadow", "leaf", "dawn", "glitter",
            "forest", "hill", "cloud", "meadow", "sun", "glade", "bird", "brook",
            "butterfly", "bush", "dew", "dust", "field", "fire", "flower", "firefly",
            "feather", "grass", "haze", "mountain", "night", "pond", "darkness",
            "snowflake", "silence", "sound", "sky", "shape", "surf", "thunder",
            "violet", "water", "wildflower", "wave", "water", "resonance", "sun",
            "wood", "dream", "cherry", "tree", "fog", "frost", "voice", "paper",
            "frog", "smoke", "star", "atom", "band", "bar", "base", "block", "boat",
            "term", "credit", "art", "fashion", "truth", "disk", "math", "unit", "cell",
            "scene", "heart", "recipe", "union", "limit", "bread", "toast", "bonus",
            "lab", "mud", "mode", "poetry", "tooth", "hall", "king", "queen", "lion", "tiger",
            "penguin", "kiwi", "cake", "mouse", "rice", "coke", "hola", "salad", "hat"
        };

        /// <summary>
        ///     Generate Heroku-like random names
        /// </summary>
        /// <param name="delimiter">Delimiter</param>
        /// <param name="tokenLength">Token Length</param>
        /// <param name="tokenHex">Token Hex (true/false)</param>
        /// <param name="tokenChars">Token Chars</param>
        /// <returns>Heroku-like string</returns>
        public string Haikunate(string delimiter = "-", int tokenLength = 4, bool tokenHex = false,
            string tokenChars = "0123456789")
        {
            if (tokenHex) tokenChars = "0123456789abcdef";
            
            var adjective = Adjectives[_rnd.Next(Adjectives.Length)];
            var noun = Nouns[_rnd.Next(Nouns.Length)];
            var token = "";

            for (var i = 0; i < tokenLength; i++)
            {
                token += tokenChars[_rnd.Next(tokenChars.Length)];
            }

            string[] sections = { adjective, noun, token };
            return string.Join(delimiter, sections.Where(s => !string.IsNullOrEmpty(s)));
        }
    }
}