using CodeTest.Application.Interfaces.Mappings;
using CodeTest.Domain.Entities;
using CodeTest.Domain.Services;
using MediatR;

namespace CodeTest.Application.CQRS.ApproveMissions.Commands;

public class ApproveMissionCommand : IRequest<string>
{
    public string? Mission { get; set; }
    public int Days { get; set; }
    public int CrewSize { get; set; }
}

public class ApproveMissionCommandHandler(
    ApproveMissionProcessor processor,
    IMappingStrategy<ApproveMissionCommand, ApproveMission> mappingStrategy)
    : IRequestHandler<ApproveMissionCommand, string>
{
    public Task<string> Handle(ApproveMissionCommand request, CancellationToken cancellationToken)
    {
        var approveMission = mappingStrategy.Map(request);
        var result = processor.Process(approveMission);
        return Task.FromResult(result);
    }
}