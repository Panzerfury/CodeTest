using CodeTest.Domain.Entities;

namespace CodeTest.Domain.Services;

public abstract class ApproveMissionHandler
{
    private ApproveMissionHandler? _nextHandler;

    public ApproveMissionHandler SetNextHandler(ApproveMissionHandler nextHandler)
    {
        _nextHandler = nextHandler;
        return nextHandler;
    }

    public virtual string Handle(ApproveMission request)
    {
        return _nextHandler != null
            ? _nextHandler.Handle(request)
            : $"Request for {request.Mission} could not be handled.";
    }
}