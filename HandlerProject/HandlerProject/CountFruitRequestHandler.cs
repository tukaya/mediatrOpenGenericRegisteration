using HandlerProject.Models;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HandlerProject;

internal class CountFruitRequestHandler<TFruit> : IRequestHandler<CountFruitRequest<TFruit>, string> where TFruit : Fruit
{
    private readonly ILogger _logger;
    public CountFruitRequestHandler(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<CountFruitRequestHandler<TFruit>>();
    }

    public Task<string> Handle(CountFruitRequest<TFruit> request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Fruit count is {count}", request.Count);

        return Task.FromResult($"{typeof(TFruit).Name} Count: {request.Count}");
    }
}
