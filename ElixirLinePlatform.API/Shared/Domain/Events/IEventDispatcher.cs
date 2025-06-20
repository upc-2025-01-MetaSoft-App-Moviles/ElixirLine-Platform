namespace ElixirLinePlatform.API.Shared.Domain.Events;

public interface IEventDispatcher
{
    void Dispatch<TEvent>(TEvent @event);
}

public class EventDispatcher : IEventDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public EventDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void Dispatch<TEvent>(TEvent @event)
    {
        var handlers = _serviceProvider.GetServices(typeof(IEventHandler<TEvent>));
        foreach (var handler in handlers)
        {
            ((IEventHandler<TEvent>)handler).Handle(@event);
        }
    }
}

public interface IEventHandler<in TEvent>
{
    void Handle(TEvent @event);
}