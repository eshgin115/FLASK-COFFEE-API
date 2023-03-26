using FLASK_COFFEE_API.CustomExceptionHandler.Abstracts;
using FLASK_COFFEE_API.DTOs;

namespace FLASK_COFFEE_API.CustomExceptionHandler.Concretes;

public class ExceptionHandlerService
{
    private readonly Dictionary<Type, Func<IExceptionHandler>> _exceptionHandlers;

    public ExceptionHandlerService()
    {
        _exceptionHandlers = new Dictionary<Type, Func<IExceptionHandler>>();
    }

    public void RegisterHandler<T>(Func<IExceptionHandler> handler)
        where T : ApplicationException
    {
        ArgumentNullException.ThrowIfNull(handler);

        _exceptionHandlers[typeof(T)] = handler;
    }

    public ExceptionResultDto Handle(ApplicationException exception)
    {
        ArgumentNullException.ThrowIfNull(exception);

        return _exceptionHandlers[exception.GetType()].Invoke().Handle(exception);
    }
}
