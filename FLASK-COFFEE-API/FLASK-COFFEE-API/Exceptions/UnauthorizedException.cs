namespace FLASK_COFFEE_API.Exceptions;

public class UnauthorizedException : ApplicationException
{
    public UnauthorizedException(string message)
        : base(message)
    {

    }
}