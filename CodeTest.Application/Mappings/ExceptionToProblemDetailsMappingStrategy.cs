using CodeTest.Application.Exceptions;
using CodeTest.Application.Interfaces.Mappings;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeTest.Application.Mappings;

public class ExceptionToProblemDetailsMappingStrategy : IMappingStrategy<Exception, ProblemDetails>
{
    public ProblemDetails Map(Exception exception)
    {
        return exception switch
        {
            ProblemException problemException => new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = problemException.Error,
                Detail = problemException.Message,
                Type = "Bad Request"
            },
            NotFoundException notFoundException => new ProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Title = "Resource Not Found",
                Detail = notFoundException.Message,
                Type = "Not Found"
            },
            ValidationException validationException => new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "Failed Validation",
                Detail = validationException.Errors.First().ErrorMessage,
                Type = "Validation Error"
            },
            _ => new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "Internal Server Error",
                Detail = exception.Message,
                Type = "Internal Server Error"
            }
        };
    }
}