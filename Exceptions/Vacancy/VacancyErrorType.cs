namespace Global.Infrastructure.Exceptions.Vacancy;

public enum VacancyErrorType
{
    VacancyNotFound,
    ResumeNotFound,

    VacancyAlreadyExists,
    ResumeAlreadyExists,
    UserAlreadyExists,
}