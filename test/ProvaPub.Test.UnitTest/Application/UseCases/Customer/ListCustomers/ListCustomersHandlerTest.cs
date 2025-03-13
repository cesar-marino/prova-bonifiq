using Moq;
using ProvaPub.Application.UseCases.Customer.ListCustomers;
using ProvaPub.Domain.Exceptions;
using ProvaPub.Domain.Repositories;

namespace ProvaPub.Test.UnitTest.Application.UseCases.Customer.ListCustomers
{
    public class ListCustomersHandlerTest : IClassFixture<ListCustomersHandlerTestFixture>
    {
        private readonly ListCustomersHandlerTestFixture _fixture;
        private readonly ListCustomersHandler _sut;
        private readonly Mock<ICustomerRepository> _customerRepositoryMock;

        public ListCustomersHandlerTest(ListCustomersHandlerTestFixture fixture)
        {
            _fixture = fixture;
            _customerRepositoryMock = new();

            _sut = new(customerRepository: _customerRepositoryMock.Object);
        }

        [Fact(DisplayName = nameof(ShouldRethrowSameExceptionThatFindAllAsyncThrows))]
        [Trait("Unit/UseCases", "Customer - ListCustomers")]
        public async Task ShouldRethrowSameExceptionThatFindAllAsyncThrows()
        {
            _customerRepositoryMock
                .Setup(x => x.FindAllAsync(
                    It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ThrowsAsync(new UnexpectedException());

            var request = _fixture.MakeListCustomersRequest();
            var act = () => _sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<UnexpectedException>(act);
            Assert.Equal("unexpected", exception.Code);
            Assert.Equal("An unexpected error occurred", exception.Message);
        }
    }
}
