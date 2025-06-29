using CalcLibrary;
using NUnit.Framework;
using TestContext = NUnit.Framework.TestContext;
namespace CalcLibrary.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private SimpleCalculator _calculator;

        [SetUp]
        public void Init()
        {
            _calculator = new SimpleCalculator();
            TestContext.WriteLine("SetUp: Calculator instance created.");
        }

        [TearDown]
        public void Cleanup()
        {
            TestContext.WriteLine("TearDown: Test completed.");
        }

        [Test]
        [TestCase(2, 3, 5)]
        [TestCase(-1, 1, 0)]
        [TestCase(100, 200, 300)]
        public void Add_ValidInputs_ReturnsCorrectResult(int a, int b, int expected)
        {
            var result = _calculator.Addition(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [NUnit.Framework.Ignore("Test is ignored for demonstration purposes.")]
        public void ThisTestIsIgnored()
        {
            Assert.Fail("This test is ignored.");
        }
    }
}
