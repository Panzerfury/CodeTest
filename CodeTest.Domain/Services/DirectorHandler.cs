using CodeTest.Domain.Entities;

namespace CodeTest.Domain.Services;

public class DirectorHandler : ApproveMissionHandler
{
    public override string Handle(ApproveMission request)
    {
        return request is { Days: < 5, CrewSize: < 10 }
            ? $"Director has approved your mission {request.Mission}"
            : base.Handle(request);
    }
}