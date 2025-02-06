using CodeTest.Application.CQRS.Starships.Commands;
using MediatR;

namespace CodeTest.Endpoints;

public static class StarshipEndpoints
{
    public static void AddStarshipEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/starships", async (CreateStarshipCommand command, IMediator mediator) =>
        {
            var starshipDto = await mediator.Send(command);
            // Returns a 201 Created response with a location header pointing to the new resource.
            return starshipDto;
        });

    }
}