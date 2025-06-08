using EventStore.Client;

namespace EventStoreFramework.Domain.DomainEvents
{
    public abstract class EventBase
    {
        public Uuid Id { get; set; } = Uuid.NewUuid();
        public string Type { get; set; } = null!;
        public string Data { get; set; } = null!;
    }
}
