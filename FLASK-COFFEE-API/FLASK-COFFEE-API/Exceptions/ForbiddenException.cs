namespace FLASK_COFFEE_API.Exceptions;

public class ForbiddenException : ApplicationException
{
    public ForbiddenException(string message)
        : base(message)
    {

    }
}