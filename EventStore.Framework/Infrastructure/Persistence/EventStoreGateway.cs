using System.Text;
using EventStore.Client;
using EventStore.Framework.Utilities;
using EventStoreFramework.Domain.DomainEvents;
using EventStoreFramework.Infrastructure.Interfaces;
using EventStoreFramework.Utilities;

public class EventStoreGateway : IEventStore
{
    public async Task SaveEventAsync(string streamName, EventBase @event)
    {

        var settings = EventStoreClientSettings.Create("esdb://localhost:2113?tls=false");
        using var client = new EventStoreClient(settings);
        var eventData = new EventData(

                @event.Id,
                @event.Type,
                Encoding.UTF8.GetBytes(@event.Data)
        );

        await client.AppendToStreamAsync(
            streamName,
            StreamState.Any,
            [eventData]
        );
    }
    public async Task ReadEventAsync(string streamName)
    {
        var settings = EventStoreClientSettings.Create("esdb://localhost:2113?tls=false");
        using var client = new EventStoreClient(settings);

        var result = client.ReadStreamAsync(Direction.Forwards, streamName, StreamPosition.Start);

        await foreach (var resolvedEvent in result)
        {
            var json = Encoding.UTF8.GetString(resolvedEvent.Event.Data.Span);

            PrintInConsole.PrintWithColor(Colors.Blue, json);
        }
    }

}
