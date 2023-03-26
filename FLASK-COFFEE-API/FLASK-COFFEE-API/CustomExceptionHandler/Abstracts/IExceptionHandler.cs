using FLASK_COFFEE_API.DTOs;

namespace FLASK_COFFEE_API.CustomExceptionHandler.Abstracts;

public interface IExceptionHandler
{
    public ExceptionResultDto Handle(ApplicationException exception);
}
