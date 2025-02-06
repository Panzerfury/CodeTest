using CodeTest.Application.CQRS.ApproveMissions.Commands;
using CodeTest.Application.Interfaces.Mappings;
using CodeTest.Domain.Entities;

namespace CodeTest.Application.Mappings;

public class ApproveMissionMappingStrategy : IMappingStrategy<ApproveMissionCommand, ApproveMission>{
    public ApproveMission Map(ApproveMissionCommand source)
    {
        return new ApproveMission
        {
            Mission = source.Mission,
            CrewSize = source.CrewSize,
            Days = source.Days
        };
    }
}