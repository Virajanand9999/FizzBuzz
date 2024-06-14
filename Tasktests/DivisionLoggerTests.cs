using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TaskProject.Services;
using TaskProject.Services.Interfaces;
using Xunit;

namespace TaskTests
{
    public class DivisionLoggerTests
    {
        private readonly DivisionLogger logger;

        public DivisionLoggerTests()
        {
            logger = new DivisionLogger();
        }

        [Fact]
        public void LogDivision_ValidInputs_AddsCorrectLog()
        {
            // Arrange
            int number = 10;
            int divisor = 2;

            // Act
            logger.LogDivision(number, divisor);

            // Assert
            Assert.Contains("Divided 10 by 2", logger.GetResults());
        }

        [Fact]
        public void LogInvalidItem_AddsInvalidItemLog()
        {
            // Arrange
            string input = "Invalid";

            // Act
            logger.LogInvalidItem(input);

            // Assert
            Assert.Contains("Invalid Item", logger.GetResults());
        }

        [Fact]
        public void DisplayResults_LogsToConsole()
        {
            // Arrange
            int number = 10;
            int divisor = 2;
            logger.LogDivision(number, divisor);
            string expectedOutput = "Divided 10 by 2" + Environment.NewLine;

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);

                // Act
                logger.DisplayResults();

                // Assert
                Assert.Equal(expectedOutput, sw.ToString());
            }
        }

        [Fact]
        public void Reset_ClearsAllLogs()
        {
            // Arrange
            logger.LogDivision(10, 2);
            logger.LogInvalidItem("Invalid");

            // Act
            logger.Reset();

            // Assert
            Assert.Empty(logger.GetResults());
        }
    }
}
