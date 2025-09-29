using Moq;
using NUnit.Framework;
using TestDemo;
namespace CalculatorTests
{


    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator;
        private Mock<ILogger> _mockLogger;

        [SetUp]
        public void Setup()
        {
            _mockLogger = new Mock<ILogger>();
            _calculator = new Calculator(_mockLogger.Object);
        }

        [Test]
        public void Add_GivenTwoNumbers_ReturnsCorrectSum()
        {
            int result = _calculator.Add(5, 3);
            Assert.AreEqual(8, result);
        }
    }
}