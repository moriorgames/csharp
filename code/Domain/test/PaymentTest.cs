using Xunit;

namespace Domain.Test;

public class PaymentTest
{
    [Fact]
    public void ShouldCreatePayment()
    {
        var payment = new Payment();

        Assert.True(true);
    }
}