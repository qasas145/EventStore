using EventStoreFramework.Domain.Entities;
using EventStoreFramework.Utilities;
using EventStore.Console;
using EventStore.Framework.Utilities;


var store = new EventStoreGateway(); 

// random data 
var orders = new List<Order>
{
    new Order(Guid.NewGuid(),"Nader", 1, 100),
    new Order(Guid.NewGuid(),"Menofia", 2, 16),
    new Order(Guid.NewGuid(),"PorSaid", 24, 812),
};

// Storing events 

foreach (var order in orders)
{

    var orderCreateEvent = new OrderCreateEvent()
    {
        Data = $"{order.UserId} has created an order to this address {order.Address} with this amount {order.Amount}",
        Type = typeof(Order).ToString()
    };
    await store.SaveEventAsync(Constants.StreamName, orderCreateEvent);
}


await store.ReadEventAsync(Constants.StreamName);

PrintInConsole.PrintWithColor(Colors.Green, "All done!");