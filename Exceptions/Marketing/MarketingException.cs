namespace Global.Infrastructure.Exceptions.Marketing;

public class MarketingException : Exception
{
    public MarketingErrorType MarketingErrorType { get; set; }

    public MarketingException(MarketingErrorType marketingErrorType, string message) : base(message)
    {
        MarketingErrorType = marketingErrorType;
    }
}