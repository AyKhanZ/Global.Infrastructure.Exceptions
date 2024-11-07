using Global.Infrastructure.Exceptions.Vacancy;


public class VacancyException : Exception
{
    public VacancyErrorType ErrorType { get; }

    public VacancyException(VacancyErrorType errorType, string message) : base(message)
    {
        ErrorType = errorType;
    }
}