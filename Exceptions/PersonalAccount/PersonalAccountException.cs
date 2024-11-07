using Global.Infrastructure.Exceptions.PersonalAccount;

public class PersonalAccountException : Exception
{
    public PersonalAccountErrorType ErrorType { get; }

    public PersonalAccountException(PersonalAccountErrorType errorType, string message) : base(message)
    {
        ErrorType = errorType;
    }
}