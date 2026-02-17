using System;
using System.Collections.Generic;
using System.Text;

namespace swiper.Utils {
    internal class DescriptionGenerator {
        private readonly string[] adjectives = ["nice", "horrible", "great", "terribly old", "brand new"];
        private readonly string[] other = ["picture of grandpa", "car", "photo of a forest", "duck"];

        private static readonly Random random = new();

        public string Generate() {
            var a = adjectives[random.Next(adjectives.Count())];
            var b = other[random.Next(other.Count())];
            return $"A {a} {b}";
        }
    }
}
