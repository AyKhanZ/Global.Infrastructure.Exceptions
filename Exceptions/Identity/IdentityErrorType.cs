namespace Global.Infrastructure.Exceptions.Identity;

public enum IdentityErrorType
{
    InvalidToken,
    InvalidRefreshToken,
    InvalidCredentials,
    UserNotFound,
    InvalidRequest,
    PasswordMismatch,
    EmailNotConfirmed,
    EmailAlreadyConfirmed
}