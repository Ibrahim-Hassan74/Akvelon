using Akvelon;
using Xunit;

namespace Akvelon.Tests
{
    public class FizzBuzzDetectorTests
    {
        private readonly FizzBuzzDetector _detector = new FizzBuzzDetector();

        // Test 1: The given example from the task description
        [Fact]
        public void GetOverlappings_GivenExample_ReturnsExpectedOutputAndCount()
        {
            string input =
                "Mary had a little lamb\n" +
                "Little lamb, little lamb\n" +
                "Mary had a little lamb\n" +
                "It's fleece was white as snow";

            var result = _detector.GetOverlappings(input);

            string expected =
                "Mary had Fizz little Buzz\n" +
                "Fizz lamb, little Fizz\n" +
                "Buzz had Fizz little lamb\n" +
                "FizzBuzz fleece was Fizz as Buzz";

            Assert.Equal(expected, result.OutputString);
            Assert.Equal(9, result.Count);
        }

        // Test 2: Every 3rd word replaced with Fizz
        [Fact]
        public void GetOverlappings_ThirdWordReplacedWithFizz()
        {
            string input = "one two three";

            var result = _detector.GetOverlappings(input);

            Assert.Equal("one two Fizz", result.OutputString);
            Assert.Equal(1, result.Count);
        }

        // Test 3: Every 5th word replaced with Buzz
        [Fact]
        public void GetOverlappings_FifthWordReplacedWithBuzz()
        {
            string input = "one two three four five";

            var result = _detector.GetOverlappings(input);

            Assert.Equal("one two Fizz four Buzz", result.OutputString);
            Assert.Equal(2, result.Count);
        }

        // Test 4: 15th word replaced with FizzBuzz (divisible by both 3 and 5)
        [Fact]
        public void GetOverlappings_FifteenthWordReplacedWithFizzBuzz()
        {
            string input = "a b c d e f g h i j k l m n o";

            var result = _detector.GetOverlappings(input);
            Assert.Equal("a b Fizz d Buzz Fizz g h Fizz Buzz k Fizz m n FizzBuzz", result.OutputString);
            Assert.Equal(7, result.Count);
        }

        // Test 5: Non-alphanumeric symbols attached to words are preserved when not replaced
        [Fact]
        public void GetOverlappings_PunctuationPreservedOnNonReplacedWords()
        {
            string input = "hello, world! foo";

            var result = _detector.GetOverlappings(input);

            Assert.Equal("hello, world! Fizz", result.OutputString);
            Assert.Equal(1, result.Count);
        }

        // Test 6: Null input throws ArgumentNullException
        [Fact]
        public void GetOverlappings_NullInput_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _detector.GetOverlappings(null!));
        }

        // Test 7: String with only non-alphanumeric characters returns same string, count 0
        [Fact]
        public void GetOverlappings_OnlySymbols_ReturnsUnchanged()
        {
            string input = "!@# $%^ &*()";

            var result = _detector.GetOverlappings(input);

            Assert.Equal("!@# $%^ &*()", result.OutputString);
            Assert.Equal(0, result.Count);
        }

        // Test 8: Single word — no replacements
        [Fact]
        public void GetOverlappings_SingleWord_NoReplacement()
        {
            string input = "hello";

            var result = _detector.GetOverlappings(input);

            Assert.Equal("hello", result.OutputString);
            Assert.Equal(0, result.Count);
        }

        // Test 9: Words with digits are considered alphanumeric
        [Fact]
        public void GetOverlappings_WordsWithDigitsAreAlphanumeric()
        {
            string input = "word1 word2 word3";

            var result = _detector.GetOverlappings(input);

            Assert.Equal("word1 word2 Fizz", result.OutputString);
            Assert.Equal(1, result.Count);
        }

        // Test 10: Multiple spaces and tabs between words are preserved
        [Fact]
        public void GetOverlappings_MultipleSpacesPreserved()
        {
            string input = "one  two   three";

            var result = _detector.GetOverlappings(input);

            Assert.Equal("one  two   Fizz", result.OutputString);
            Assert.Equal(1, result.Count);
        }
    }
}
