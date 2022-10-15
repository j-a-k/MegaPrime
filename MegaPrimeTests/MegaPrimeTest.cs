using MegaPrime;

namespace MegaPrimeTests
{
    public class MegaPrimeTest
    {

        [Test]
        [TestCase(1u)]
        [TestCase(10u, 2u, 3u, 5u, 7u)]
        [TestCase(37u, 2u, 3u, 5u, 7u, 23u, 37u)]
        public void Examples(uint max, params uint[] expected)
        {
            var actual = MegaPrimeChecker.GetMegaPrimes(max);
            Assert.That(actual, Is.EqualTo(new List<uint>(expected)));
        }

        [Test]
        public void GetMegaPrimesTest0()
        {
            Assert.Throws<ArgumentException>(() => MegaPrimeChecker.GetMegaPrimes(0));
        }

        [Test]
        [TestCase(1u)]
        [TestCase(10u, 2u, 3u, 5u, 7u)]
        [TestCase(13u, 2u, 3u, 5u, 7u, 11u, 13u)]
        public void GetPrimesTest(uint max, params uint[] expected)
        {
            var actual = MegaPrimeChecker.GetPrimes(max);
            Assert.That(actual, Is.EqualTo(new List<uint>(expected)));
        }


        [Test]
        [TestCase(1u, false)]
        [TestCase(10u, false)]
        [TestCase(37u, true)]
        public void HasPrimeDigitsTest(uint max, bool expected)
        {
            var actual = MegaPrimeChecker.HasPrimeDigits(max);
            Assert.That(actual, Is.EqualTo(expected));
        }

    }
}