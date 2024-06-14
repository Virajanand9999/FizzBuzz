using System;
using Moq;
using TaskProject.Services;
using TaskProject.Services.Interfaces;
using Xunit;

namespace Tasktests
{
    public class FizzBuzzCalculatorTests
    {
        private readonly Mock<IDivisionLogger> mockLogger;
        private readonly FizzBuzzCalculator calculator;

        public FizzBuzzCalculatorTests()
        {
            mockLogger = new Mock<IDivisionLogger>();
            calculator = new FizzBuzzCalculator(mockLogger.Object);
        }

        [Fact]
        public void Calculate_NumberDivisibleBy3_ReturnsFizz()
        {
            // Arrange
            int number = 3;

            // Act
            string result = calculator.Calculate(number);

            // Assert
            Assert.Equal("Fizz", result);
            mockLogger.Verify(logger => logger.LogDivision(number, 3), Times.Once);
            mockLogger.Verify(logger => logger.LogDivision(number, 5), Times.Once);
        }

        [Fact]
        public void Calculate_NumberDivisibleBy5_ReturnsBuzz()
        {
            // Arrange
            int number = 5;

            // Act
            string result = calculator.Calculate(number);

            // Assert
            Assert.Equal("Buzz", result);
            mockLogger.Verify(logger => logger.LogDivision(number, 3), Times.Once);
            mockLogger.Verify(logger => logger.LogDivision(number, 5), Times.Once);
        }

        [Fact]
        public void Calculate_NumberDivisibleBy3And5_ReturnsFizzBuzz()
        {
            // Arrange
            int number = 15;

            // Act
            string result = calculator.Calculate(number);

            // Assert
            Assert.Equal("FizzBuzz", result);
            mockLogger.Verify(logger => logger.LogDivision(number, 3), Times.Once);
            mockLogger.Verify(logger => logger.LogDivision(number, 5), Times.Once);
        }

        [Fact]
        public void Calculate_NumberNotDivisibleBy3Or5_ReturnsNull()
        {
            // Arrange
            int number = 7;

            // Act
            string result = calculator.Calculate(number);

            // Assert
            Assert.Null(result);
            mockLogger.Verify(logger => logger.LogDivision(number, 3), Times.Once);
            mockLogger.Verify(logger => logger.LogDivision(number, 5), Times.Once);
        }
    }
}
