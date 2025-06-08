using System.Text;
using EventStore.Client;
using Common.Infrastructure;
using Common.Uitlities;
using Common.Domain;

public class EventStoreGateway
{
    public async Task AppendEventAsync(string streamName, Order order)
    {

        var settings = EventStoreClientSettings.Create("esdb://localhost:2113?tls=false");
        using var client = new EventStoreClient(settings);
        var eventData = EventFactory.CreateEvent(order);

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

            PrintInConsole.PrintWithColor(() => Console.ForegroundColor = ConsoleColor.Blue, json);
        }
    }

}
