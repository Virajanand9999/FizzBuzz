namespace TaskProject.Services.Interfaces
{
    public interface IDivisionLogger
    {
        void LogDivision(int number, int divisor);
        void LogInvalidItem(string input);
        void DisplayResults();

        void Reset();

    }
}