using Microsoft.Extensions.DependencyInjection;
using System;
using TaskProject.Services.Interfaces;
using TaskProject.Services;

namespace TaskProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setup DI
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IFizzBuzzCalculator, FizzBuzzCalculator>()
                .AddSingleton<IDivisionLogger, DivisionLogger>()
                .BuildServiceProvider();

            var logger = serviceProvider.GetService<IDivisionLogger>();
            var calculator = new FizzBuzzCalculator(logger);
            string? userInput = string.Empty;
            do{
                logger.Reset();
                Console.WriteLine("Enter a number:");
                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    string result = calculator.Calculate(number);
                    if(result != null)
                    Console.WriteLine($"{result}");
                }
                else
                {
                    logger.LogInvalidItem(Convert.ToString(number));                   
                }
                logger.DisplayResults();
                Console.WriteLine("Do you want to retry another number? Press Y");
                userInput = Convert.ToString(Console.ReadLine()); 
            }
            while(userInput?.ToUpper() == "Y");



          
        

    }
    }
}
