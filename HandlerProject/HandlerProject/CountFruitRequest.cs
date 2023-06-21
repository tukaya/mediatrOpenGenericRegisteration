using HandlerProject.Models;
using MediatR;

namespace HandlerProject;

internal class CountFruitRequest<TFruit> : IRequest<string> where TFruit : Fruit
{
    public int Count { get; set; }
}
