﻿using FLASK_COFFEE_API.Exceptions;
using FLASK_COFFEE_API.Middlewares;

namespace FLASK_COFFEE_API.Infrastructure.Extensions
{
    public static class AppBuilderExtensions
    {
        public static void ConfigureMiddlewarePipeline(this WebApplication app)
        {
            app.UseCustomExceptionHandler();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseAuthorization();
            app.MapGet("/not-found-example", () =>
            {
                throw new NotFoundException("Information is not found in DB");
            });

            app.MapGet("/bad-request-example", () =>
            {
                throw new BadRequestException("Requester URL is invalid");
            });

            app.MapGet("/forbidden-request-example", () =>
            {
                throw new ForbiddenException("Requester URL is invalid");
            });

            app.MapGet("/unauthorized-request-example", () =>
            {
                throw new UnauthorizedException("You don't have access to this module");
            });

            app.MapGet("/validation-request-example", () =>
            {
                throw new ValidationException("Only only admin is allowed");
            });

            //app.MapControllers();
        }
    }
}
