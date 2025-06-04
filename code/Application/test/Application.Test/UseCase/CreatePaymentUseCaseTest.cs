using Application.UseCase;
using Application.Repository;
using Domain.Entity;
using Xunit;

namespace Application.Test.UseCase;

public class CreatePaymentUseCaseTest
{
    private class FakePaymentRepository : IPaymentRepository
    {
        private readonly Exception? _exception;
        public bool SaveCalled { get; private set; }

        public FakePaymentRepository(Exception? exception = null)
        {
            _exception = exception;
        }

        public void Save(Payment payment)
        {
            SaveCalled = true;
            if (_exception is not null)
            {
                throw _exception;
            }
        }
    }

    [Fact]
    public void Execute_ShouldReturnOk_WhenSaveSucceeds()
    {
        var repository = new FakePaymentRepository();
        var useCase = new CreatePaymentUseCase(repository);
        var input = new CreatePaymentInput(10, 2, "USD");

        var result = useCase.Execute(input);

        Assert.Equal("OK", result);
        Assert.True(repository.SaveCalled);
    }

    [Fact]
    public void Execute_ShouldThrow_WhenRepositoryFails()
    {
        var repository = new FakePaymentRepository(new InvalidOperationException());
        var useCase = new CreatePaymentUseCase(repository);
        var input = new CreatePaymentInput(10, 2, "USD");

        Assert.Throws<InvalidOperationException>(() => useCase.Execute(input));
    }
}