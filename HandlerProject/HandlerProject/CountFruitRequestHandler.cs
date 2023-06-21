using HandlerProject.Models;
using MediatR;

namespace HandlerProject;

internal class CountFruitRequestHandler<TFruit> : IRequestHandler<CountFruitRequest<TFruit>, string> where TFruit : Fruit
{
    public Task<string> Handle(CountFruitRequest<TFruit> request, CancellationToken cancellationToken)
    {
        return Task.FromResult($"{typeof(TFruit).Name} Count: {request.Count}");
    }
}
