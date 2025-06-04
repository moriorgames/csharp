using Domain;
using Xunit;

namespace Domain.Tests;

public class PaymentTest
{
    [Fact]
    public void TestPaymentEntityIsConsistent()
    {
        var date = new DateTime(2023, 12, 31);
        var payment = new Payment(100m, date);

        Assert.NotEqual(Guid.Empty, payment.Id);
        Assert.Equal(100m, payment.Amount);
        Assert.Equal(date, payment.Date);
    }
}
