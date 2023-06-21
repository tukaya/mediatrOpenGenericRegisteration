using Autofac;
using HandlerProject.Models;
using MediatR;

namespace HandlerProject.UnitTests;

public class ExtensionsAutoFacTests
{
    private readonly IContainer _container;
    public ExtensionsAutoFacTests()
    {
        var builder = new ContainerBuilder();
        builder.AddMediatrHandlersWithOpenGeneric();
        _container = builder.Build();
    }

    [Theory]
    [InlineData(typeof(IRequestHandler<CountFruitRequest<Apple>, string>), typeof(CountFruitRequestHandler<Apple>))]
    [InlineData(typeof(IRequestHandler<CountFruitRequest<Orange>, string>), typeof(CountFruitRequestHandler<Orange>))]
    public void ResolvesMediatrOpenGenericHandler(Type service, Type expected)
    {
        // Arrange
        // Act

        // Assert
        var actual = _container.Resolve(service);
        Assert.Same(expected, actual.GetType());
    }

    [Fact]
    public async Task ResolvedHandlerForApple_ReturnsExpected()
    {
        // Arrange
        var mediator = _container.Resolve<IMediator>();
        var request = new CountFruitRequest<Apple> { Count = 1 };

        // Act
        var actual = await mediator.Send(request);

        // Assert
        var expected = "Apple Count: 1";
        Assert.Equal(expected, actual);
    }

    [Fact]
    public async Task ResolvedHandlerForOrange_ReturnsExpected()
    {
        // Arrange
        var mediator = _container.Resolve<IMediator>();
        var request = new CountFruitRequest<Orange> { Count = 1 };

        // Act
        var actual = await mediator.Send(request);

        // Assert
        var expected = "Orange Count: 1";
        Assert.Equal(expected, actual);
    }
}
