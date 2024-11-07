namespace Global.Infrastructure.Exceptions.Identity;

public class IdentityException : Exception
{
    public IdentityErrorType AuthErrorType { get; set; }

    public IdentityException(IdentityErrorType authErrorType, string message) : base(message)
    {
        AuthErrorType = authErrorType;
    }
}