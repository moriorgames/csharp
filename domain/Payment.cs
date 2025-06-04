namespace Domain;

public class Payment
{
    public Guid Id { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime Date { get; private set; }

    public Payment(decimal amount, DateTime date)
    {
        Id = Guid.NewGuid();
        Amount = amount;
        Date = date;
    }
}
