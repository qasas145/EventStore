using Common.Domain;
using Common.Uitlities;



var store = new EventStoreGateway();
var orders = new List<Order>
{
    new Order(Guid.NewGuid(),"Nader", 1, 100),
    new Order(Guid.NewGuid(),"Menofia", 2, 16),
    new Order(Guid.NewGuid(),"PorSaid", 24, 812),
};

foreach(var order in orders)
    await store.AppendEventAsync($"OrderStore", order);
await store.ReadEventAsync("OrderStore");

PrintInConsole.PrintWithColor(() => Console.ForegroundColor = ConsoleColor.Green, "All done!");