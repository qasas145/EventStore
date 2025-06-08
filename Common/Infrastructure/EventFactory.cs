using System.Text;
using Common.Domain;
using EventStore.Client;

namespace Common.Infrastructure
{
    public class EventFactory
    {
        public static EventData CreateEvent(Order order)
        {
            var @event = new EventData(
                Uuid.NewUuid(),
                order.GetType().ToString(),
                Encoding.UTF8.GetBytes($"user {order.UserId} made an order to this address {order.Address} with this amount {order.Amount}")
                );
            return @event;
        }
    }
}
