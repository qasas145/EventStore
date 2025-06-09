using EventStoreFramework.Domain.DomainEvents;

namespace EventStoreFramework.Infrastructure.Interfaces
{
    public interface IEventStore
    {
        Task SaveEventAsync(string streamName, EventBase @event);
        Task ReadEventAsync(string streamName);
    }
}
