using CodeTest.Application;
using CodeTest.Application.CQRS.Behaviors;
using CodeTest.Application.CQRS.Persons.Queries;
using CodeTest.ExceptionHandlers;
using CodeTest.Infrastructure;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http.Features;
using DependencyInjection = CodeTest.Application.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddMappings();
builder.Services.AddExternalHttpClient();

builder.Services.AddProblemDetails(options =>
{
    options.CustomizeProblemDetails = context =>
    {
        context.ProblemDetails.Instance = $"{context.HttpContext.Request.Method} {context.HttpContext.Request.Path}";
        context.ProblemDetails.Extensions.TryAdd("requestId", context.HttpContext.TraceIdentifier);
        var activity = context.HttpContext.Features.Get<IHttpActivityFeature>()?.Activity;
        context.ProblemDetails.Extensions.TryAdd("traceId", activity?.TraceId);
    };
});
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
// Register all FluentValidation validators from the assembly
builder.Services.AddValidatorsFromAssemblyContaining<GetPersonQueryValidator>();
// Register the validation pipeline behavior
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

// Register individual exception handlers for specific exceptions
builder.Services.AddExceptionHandler<ProblemExceptionHandler>();

builder.Services.AddDatabaseContext();
builder.Services.AddRepositories();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseExceptionHandler();

// Minimal API endpoint to fetch person by ID
app.MapGet("/person/{id:int}", async (int id, IMediator mediator) =>
    {
        var query = new GetPersonQuery { Id = id };

        var person = await mediator.Send(query);
        return person;
    })
    .WithName("GetPerson");

app.Run();