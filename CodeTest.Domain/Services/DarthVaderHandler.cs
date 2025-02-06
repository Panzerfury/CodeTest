using CodeTest.Domain.Entities;

namespace CodeTest.Domain.Services;

public class DarthVaderHandler : ApproveMissionHandler
{
    public override string Handle(ApproveMission request)
    {
        return request is { Days: < 15, CrewSize: < 50 }
            ? $"Darth vader has approved your mission {request.Mission}"
            : base.Handle(request);
    }
}