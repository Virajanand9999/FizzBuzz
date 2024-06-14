using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskProject.Services.Interfaces;

namespace TaskProject.Services
{
    public class DivisionLogger : IDivisionLogger
    {
        private List<string> divisionResults = new List<string>();

        public void LogDivision(int number, int divisor)
        {
            divisionResults.Add($"Divided {number} by {divisor}");
        }

        public void LogInvalidItem(string input)
        {
            divisionResults.Add($"Invalid Item");
        }

        public void DisplayResults()
        {
            foreach (var result in divisionResults)
            {
                Console.WriteLine(result);
            }
        }

        public void Reset()
        {
            divisionResults = new List<string>();
        }

        public List<string> GetResults()
        {
            return new List<string>(divisionResults);
        }
    }
}
