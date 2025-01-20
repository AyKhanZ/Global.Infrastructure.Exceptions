namespace Global.Infrastructure.Exceptions.PersonalAccount;

public enum PersonalAccountErrorType
{
    UserNotFound,
    ClientNotFound,
    StaffNotFound,
    CertificateNotFound,
    CompanyNotFound,
    VoenNotFound,
    TypeOfActivityNotFound,
    CommentNotFound,
    TaskNotFound,
    SubTicketNotFound,
    ReactionNotFound,
    TicketNotFound,
    TaskRoleNotFound,
    ProductNotFound,
    ProjectNotFound,
    FileNotFound,
    CheckListNotFound,
    NotificationNotFound,
    
    VoenIsNull,
    InvalidTaskState,
    ConcurrencyError,
    GeneralError,

    ProjectAlreadyExists,
    UserAlreadyExists,
    ClientAlreadyExists,
    StaffAlreadyExists,
    EmailAlreadyExists,
    SubTicketAlreadyExists,
    TicketAlreadyExists,
    CommentAlreadyExists,
    ReactionAlreadyExists,
    NotificationAlreadyExists,
    TaskAlreadyExists,
    CheckListAlreadyExists
}
