using Application.Dto;

namespace Application.UseCase;

using Repository;
using Domain.Entity;
using Domain.ValueObject;

public class CreatePaymentUseCase(IPaymentRepository repository)
{
    public string Execute(CreatePaymentInput input)
    {
        var amount = new Amount(input.AmountValue, input.Exponent);
        var currency = new Currency(input.Currency);
        var money = new Money(amount, currency);
        var payment = new Payment(Guid.NewGuid().ToString(), money);

        repository.Save(payment);
        return "OK";
    }
}