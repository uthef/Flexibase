namespace FlexibaseTests
{
    public class Tests
    {
        [Test]
        [TestCase(" ", new int[0])]
        [TestCase("11", new int[] { 11 })]
        [TestCase("1, 2, 3, 4, 5", new int[] { 1, 2, 3, 4, 5 })]
        [TestCase("48,   54, 2,12", new int[] { 48, 54, 2, 12 })]
        public void TestInputParser(string input, IEnumerable<int> expectedSequence)
        {
            var sequence = new RawInput(input).ToSequence();
            Assert.That(sequence, Is.EquivalentTo(expectedSequence));
        }

        [Test]
        [TestCase(
            "1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15", 
            "1, 2, fizz, 4, buzz, fizz, 7, 8, fizz, buzz, 11, fizz, 13, 14, fizz-buzz"
        )]
        public void Test1(string input, string expectedOutput)
        {
            var sequence = new RawInput(input).ToSequence();
            var converter = new NumberConverter(sequence);
            var actualOutput = converter.ExecuteTaskChain(new Task1(animalMode: false));

            Assert.That(actualOutput, Is.EqualTo(expectedOutput));
        }

        [Test]
        [TestCase(
            "1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 60, 105, 420", 
            "1, 2, fizz, muzz, buzz, fizz, guzz, muzz, fizz, buzz, 11, fizz-muzz, 13, guzz, fizz-buzz, fizz-buzz-muzz, fizz-buzz-guzz, fizz-buzz-muzz-guzz"
        )]
        public void Test2(string input, string expectedOutput)
        {
            var sequence = new RawInput(input).ToSequence();
            var converter = new NumberConverter(sequence);
            var actualOutput = converter.ExecuteTaskChain(new Task1(animalMode: false), new Task2());

            Assert.That(actualOutput, Is.EqualTo(expectedOutput));
        }

        [Test]
        [TestCase(
            "1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 60, 105, 420",
            "1, 2, dog, muzz, cat, dog, guzz, muzz, dog, cat, 11, dog-muzz, 13, guzz, good-boy, good-boy-muzz, good-boy-guzz, good-boy-muzz-guzz"
        )]
        public void Test3(string input, string expectedOutput)
        {
            var sequence = new RawInput(input).ToSequence();
            var converter = new NumberConverter(sequence);
            var actualOutput = converter.ExecuteTaskChain(new Task1(animalMode: true), new Task2());

            Assert.That(actualOutput, Is.EqualTo(expectedOutput));
        }
    }
}