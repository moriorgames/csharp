namespace Application.Repository;

using Domain.Entity;

public interface IPaymentRepository
{
    void Save(Payment payment);
}
