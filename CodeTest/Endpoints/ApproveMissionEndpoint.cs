using CodeTest.Application.CQRS.ApproveMissions.Commands;
using MediatR;

namespace CodeTest.Endpoints;

public static class ApproveMissionEndpoint
{
    public static void AddApproveMissionEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/process-mission", async (ApproveMissionCommand command, IMediator mediator) =>
        {
            var result = await mediator.Send(command);
            return result;
        });
    }
}