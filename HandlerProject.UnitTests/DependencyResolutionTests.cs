using HandlerProject.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace HandlerProject.UnitTests;

public class DependencyResolutionTests
{
    private readonly IServiceProvider _serviceProvider;
    public DependencyResolutionTests()
    {
        var services = new ServiceCollection();
        services.AddLogging();

        // Act
        services.AddMediatrHandlers();
        _serviceProvider = services.BuildServiceProvider();
    }

    [Theory]
    [InlineData(typeof(IRequestHandler<CountFruitRequest<Apple>, string>), typeof(CountFruitRequestHandler<Apple>))]
    [InlineData(typeof(IRequestHandler<CountFruitRequest<Orange>, string>), typeof(CountFruitRequestHandler<Orange>))]
    public void ResolvesMediatrOpenGenericHandler(Type service, Type expected)
    {
        // Arrange
        // Act

        // Assert
        var actual = _serviceProvider.GetService(service);
        Assert.Same(expected, actual.GetType());
    }

    [Fact]
    public async Task ResolvedHandlerForApple_ReturnsExpected()
    {
        // Arrange
        var mediator = _serviceProvider.GetService<IMediator>();
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
        var mediator = _serviceProvider.GetService<IMediator>();
        var request = new CountFruitRequest<Orange> { Count = 1 };

        // Act
        var actual = await mediator.Send(request);

        // Assert
        var expected = "Orange Count: 1";
        Assert.Equal(expected, actual);
    }
}
