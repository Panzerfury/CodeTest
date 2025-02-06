using CodeTest.Application.Exceptions;
using CodeTest.Application.Interfaces.Mappings;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CodeTest.ExceptionHandlers;

public class ProblemExceptionHandler(IProblemDetailsService problemDetailsService, IMappingStrategy<Exception, ProblemDetails> mappingStrategy) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        // Handle different exception types and map to different status codes
        ProblemDetails problemDetails = mappingStrategy.Map(exception);
        httpContext.Response.StatusCode = problemDetails.Status ?? StatusCodes.Status500InternalServerError;
        // If problemDetails is set, send it using the service
        return await problemDetailsService.TryWriteAsync(new ProblemDetailsContext
        {
            HttpContext = httpContext,
            ProblemDetails = problemDetails
        });
    }
}