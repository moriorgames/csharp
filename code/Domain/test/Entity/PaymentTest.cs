using Domain.Entity;
using Domain.ValueObject;
using Xunit;

namespace Domain.Test.Entity;

public class PaymentTest
{
    [Fact]
    public void ShouldCreatePayment()
    {
        var amount = new Amount(10, 2);
        var currency = new Currency("USD");
        var money = new Money(amount, currency);
        var payment = new Payment("pay-id", money);

        Assert.Equal("pay-id", payment.Id);
        Assert.Equal(money, payment.Amount);
    }
}
