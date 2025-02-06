using CodeTest.Application.CQRS.Persons.Queries;
using MediatR;

namespace CodeTest.Endpoints;

public static class PersonEndpoints
{
    public static void AddPersonEndpoints(this IEndpointRouteBuilder app)
    {
        // Minimal API endpoint to fetch person by ID
        app.MapGet("/person/{id:int}", async (int id, IMediator mediator) =>
            {
                var query = new GetPersonQuery { Id = id };

                var person = await mediator.Send(query);
                return person;
            })
            .WithName("GetPerson");
    }
}