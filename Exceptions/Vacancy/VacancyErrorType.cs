namespace Global.Infrastructure.Exceptions.Vacancy;

public enum VacancyErrorType
{
    WorkExperienceNotFound,
    EducationNotFound,
    PersonalInfoNotFound,
    ContactInfoNotFound,
    AdditionalInfoNotFound,
    VacancyNotFound,
    ResumeNotFound,

    VacancyAlreadyExists,
    ResumeAlreadyExists,
    
    VacancyNotActual
}
