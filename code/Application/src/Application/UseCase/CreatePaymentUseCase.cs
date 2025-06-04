namespace Application.UseCase;

using Application.Repository;
using Domain.Entity;
using Domain.ValueObject;

public readonly record struct CreatePaymentInput(int AmountValue, int Exponent, string Currency);

public class CreatePaymentUseCase
{
    private readonly IPaymentRepository _repository;

    public CreatePaymentUseCase(IPaymentRepository repository)
    {
        _repository = repository;
    }

    public string Execute(CreatePaymentInput input)
    {
        var amount = new Amount(input.AmountValue, input.Exponent);
        var currency = new Currency(input.Currency);
        var money = new Money(amount, currency);
        var payment = new Payment(Guid.NewGuid().ToString(), money);

        _repository.Save(payment);
        return "OK";
    }
}
