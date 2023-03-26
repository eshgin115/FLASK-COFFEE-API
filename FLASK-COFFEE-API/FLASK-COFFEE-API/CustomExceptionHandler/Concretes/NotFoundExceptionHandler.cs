using FLASK_COFFEE_API.CustomExceptionHandler.Abstracts;
using FLASK_COFFEE_API.DTOs;
using FLASK_COFFEE_API.Exceptions;
using System.Net;
using System.Net.Mime;

namespace FLASK_COFFEE_API.CustomExceptionHandler.Concretes;

public class NotFoundExceptionHandler : IExceptionHandler
{
    public ExceptionResultDto Handle(ApplicationException exception)
    {
        var notFoundException = (NotFoundException)exception;

        return new ExceptionResultDto(MediaTypeNames.Text.Plain, (int)HttpStatusCode.NotFound, notFoundException.Message);
    }
}