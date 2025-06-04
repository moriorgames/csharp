namespace Application.Repository;

using Domain.Entity;

public interface IPaymentRepository
{
    bool Save(Payment payment);
}
