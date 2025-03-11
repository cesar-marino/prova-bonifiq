using Moq;
using ProvaPub.Application.UseCases.RandomNumber.GenerateRandomNumber;
using ProvaPub.Domain.Entities;
using ProvaPub.Domain.Exceptions;
using ProvaPub.Domain.Repositories;
using ProvaPub.Domain.SeedWork;

namespace ProvaPub.Test.UnitTest.Application.UseCases.RandomNumber.GenerateRandomNumber
{
    public class GenerateRandomNumberHandlerTest : IClassFixture<GenerateRandomNumberHandlerTestFixture>
    {
        private readonly GenerateRandomNumberHandlerTestFixture _fixture;
        private readonly GenerateRandomNumberHandler _sut;
        private readonly Mock<IRandomNumberRepository> _randomNumberRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;

        public GenerateRandomNumberHandlerTest(GenerateRandomNumberHandlerTestFixture fixture)
        {
            _fixture = fixture;
            _randomNumberRepositoryMock = new();
            _unitOfWorkMock = new();

            _sut = new(
                randomNumberRepository: _randomNumberRepositoryMock.Object,
                unitOfWork: _unitOfWorkMock.Object);
        }

        [Fact(DisplayName = nameof(ShouldRethrowSameExceptionThatCheckNumberAsyncThrows))]
        [Trait("Unit/UseCases", "RandomNumber - GeneraeteRandomNumber")]
        public async Task ShouldRethrowSameExceptionThatCheckNumberAsyncThrows()
        {
            _randomNumberRepositoryMock
                .Setup(x => x.CheckNumberAsync(
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ThrowsAsync(new UnexpectedException());

            var request = _fixture.MakeGenerateRandomNumberRequest();
            var act = () => _sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<UnexpectedException>(act);
            Assert.Equal("unexpected", exception.Code);
            Assert.Equal("An unexpected error occurred", exception.Message);
        }

        [Fact(DisplayName = nameof(ShouldRethrowSameExceptionThatInsertAsyncThrows))]
        [Trait("Unit/UseCases", "RandomNumber - GeneraeteRandomNumber")]
        public async Task ShouldRethrowSameExceptionThatInsertAsyncThrows()
        {
            _randomNumberRepositoryMock
                .Setup(x => x.CheckNumberAsync(
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            _randomNumberRepositoryMock
                .Setup(x => x.InsertAsync(
                    It.IsAny<RandomNumberEntity>(),
                    It.IsAny<CancellationToken>()))
                .ThrowsAsync(new UnexpectedException());

            var request = _fixture.MakeGenerateRandomNumberRequest();
            var act = () => _sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<UnexpectedException>(act);
            Assert.Equal("unexpected", exception.Code);
            Assert.Equal("An unexpected error occurred", exception.Message);
        }

        [Fact(DisplayName = nameof(ShouldRethrowSameExceptionThatCommitAsyncThrows))]
        [Trait("Unit/UseCases", "RandomNumber - GeneraeteRandomNumber")]
        public async Task ShouldRethrowSameExceptionThatCommitAsyncThrows()
        {
            _randomNumberRepositoryMock
                .Setup(x => x.CheckNumberAsync(
                    It.IsAny<int>(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(false);

            _unitOfWorkMock
                .Setup(x => x.CommitAsync(It.IsAny<CancellationToken>()))
                .ThrowsAsync(new UnexpectedException());

            var request = _fixture.MakeGenerateRandomNumberRequest();
            var act = () => _sut.Handle(request, _fixture.CancellationToken);

            var exception = await Assert.ThrowsAsync<UnexpectedException>(act);
            Assert.Equal("unexpected", exception.Code);
            Assert.Equal("An unexpected error occurred", exception.Message);
        }
    }
}
