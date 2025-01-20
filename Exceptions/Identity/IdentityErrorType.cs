namespace Global.Infrastructure.Exceptions.Identity;

public enum IdentityErrorType
{
    InvalidToken,
    FileNotFound,
    InvalidRefreshToken,
    InvalidCredentials,
    UserNotFound,
    InvalidRequest,
    PasswordMismatch,
    EmailNotConfirmed,
    EmailAlreadyConfirmed,
    EmailAlreadyExist
}