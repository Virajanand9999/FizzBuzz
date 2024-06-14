using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.Services.Interfaces;

namespace TaskProject.Services
{
    public class FizzBuzzCalculator : IFizzBuzzCalculator
    {
        private readonly IDivisionLogger logger;
        public FizzBuzzCalculator(IDivisionLogger logger)
        {
            this.logger = logger;
        }
        public string Calculate(int number)
        {
            logger.LogDivision(number, 3);
            logger.LogDivision(number, 5);

            if (number % 3 == 0 && number % 5 == 0)
            {
                return "FizzBuzz";
            }
            else if (number % 3 == 0)
            {
                return "Fizz";
            }
            else if (number % 5 == 0)
            {
                return "Buzz";
            }
            else
            {
                return null;
            }
        }
    }
}
