using CodeTest.Domain.Entities;

namespace CodeTest.Domain.Services;

public class ApproveMissionProcessor
{
    private readonly ApproveMissionHandler _chain;

    public ApproveMissionProcessor()
    {
        var director = new DirectorHandler();
        var darthVader = new DarthVaderHandler();
        var emperor = new EmperorHandler();
        
        director.SetNextHandler(darthVader).SetNextHandler(emperor);
        _chain = director;
    }

    public string Process(ApproveMission request)
    {
        return _chain.Handle(request);
    }
}