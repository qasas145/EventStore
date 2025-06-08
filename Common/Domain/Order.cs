namespace Common.Domain;
public class Order
{
    public Guid Id { get; private set; }

    public string Address { get; set; }
    public int UserId { get; set; }
    public int Amount { get; set; }

    public Order(Guid id, string address, int userId, int amount)
    {
        Id = id;
        Address = address;
        UserId = userId;
        Amount = amount;
    }

}