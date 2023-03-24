namespace FLASK_COFFEE_API.Exceptions
{
    public class IdentityCookieException : ApplicationException
    {
        public IdentityCookieException(string? message)
           : base(message)
        {

        }
    }
}
