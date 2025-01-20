namespace Global.Infrastructure.Exceptions.Marketing;

public enum MarketingErrorType
{
    CRMNotFound,
    NewsNotFound,
    PartnerNotFound,
    TranslationNotFound,
    FileNotFound,
    
    InvalidRequest,
    
    PartnerAlreadyExists,
}