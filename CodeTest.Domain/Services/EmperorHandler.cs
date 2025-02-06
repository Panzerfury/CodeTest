using CodeTest.Domain.Entities;

namespace CodeTest.Domain.Services;

public class EmperorHandler : ApproveMissionHandler
{
    public override string Handle(ApproveMission request)
    {
        return $"The emperor has approved your mission {request.Mission}";
    }
}