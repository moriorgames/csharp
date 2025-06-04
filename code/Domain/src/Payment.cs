namespace Domain;

public class Payment
{
    public Payment(string id, Money amount)
    {
        Id = id;
        Amount = amount;
    }

    public string Id { get; }
    public Money Amount { get; }
}
