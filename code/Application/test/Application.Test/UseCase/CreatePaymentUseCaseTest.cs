using Application.Dto;
using Application.UseCase;
using Application.Repository;
using Domain.Entity;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Xunit;

namespace Application.Test.UseCase;

public class CreatePaymentUseCaseTest
{
    private readonly IPaymentRepository _repository;
    private readonly CreatePaymentUseCase _createPaymentUseCase;
    
    public CreatePaymentUseCaseTest()
    {
        _repository = Substitute.For<IPaymentRepository>();
        _createPaymentUseCase = new CreatePaymentUseCase(_repository);
    }

    [Fact]
    public void ShouldReturnOk_WhenSaveSucceeds()
    {
        var input = new CreatePaymentInput(10, 2, "USD");

        var actual = _createPaymentUseCase.Execute(input);

        Assert.Equal("OK", actual);
    }

    [Fact]
    public void ShouldThrow_WhenRepositoryFails()
    {
        _repository
            .Save(Arg.Any<Payment>())
            .Throws(new InvalidOperationException());
        var input = new CreatePaymentInput(10, 2, "USD");

        Assert.Throws<InvalidOperationException>(() => _createPaymentUseCase.Execute(input));
    }
}