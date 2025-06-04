using Domain.ValueObject;

namespace Domain.Entity;

public class Payment(string id, Money amount)
{
    public string Id { get; } = id;
    public Money Amount { get; } = amount;
}
