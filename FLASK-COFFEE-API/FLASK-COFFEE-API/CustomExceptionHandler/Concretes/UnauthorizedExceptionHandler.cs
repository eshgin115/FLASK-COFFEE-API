using FLASK_COFFEE_API.CustomExceptionHandler.Abstracts;
using FLASK_COFFEE_API.DTOs;
using FLASK_COFFEE_API.Exceptions;
using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace FLASK_COFFEE_API.CustomExceptionHandler.Concretes;
public class UnauthorizedExceptionHandler : IExceptionHandler
{
    public ExceptionResultDto Handle(ApplicationException exception)
    {
        var unauthorizedException = (UnauthorizedException)exception;

        return new ExceptionResultDto(MediaTypeNames.Application.Json, (int)HttpStatusCode.Unauthorized, JsonSerializer.Serialize(unauthorizedException.Message));
    }
}