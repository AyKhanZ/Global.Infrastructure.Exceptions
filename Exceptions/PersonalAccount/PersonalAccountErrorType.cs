namespace Global.Infrastructure.Exceptions.PersonalAccount;

public enum PersonalAccountErrorType
{
    UserNotFound,
    ClientNotFound,
    StaffNotFound,
    CompanyNotFound,
    VoenNotFound,
    TypeOfActivityNotFound,
    CommentNotFound,
    ProjectTaskNotFound,
    ProjectSubTicketNotFound,
    ProjectTicketUserNotFound,
    ReactionNotFound,
    ProjectTicketNotFound,
    TaskRoleNotFound,
    SerteficateNotFound,
    ProductNotFound,
    ProjectNotFound,
    
    InvalidTaskState,
    ConcurrencyError,
    GeneralError,

    ProjectAlreadyExists,
    UserAlreadyExists,
    ClientAlreadyExists,
    StaffAlreadyExists,
    EmailAlreadyExists,
    ProjectSubTicketAlreadyExists,
    ProjectTicketAlreadyExists
}