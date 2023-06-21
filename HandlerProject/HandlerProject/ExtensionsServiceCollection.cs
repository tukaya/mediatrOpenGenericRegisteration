using System.Reflection;
using HandlerProject.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace HandlerProject;

public static class ExtensionsServiceCollection
{
    public static IServiceCollection AddMediatrHandlersExplicitly(this IServiceCollection services)
    {
        var assembly = typeof(CountFruitRequestHandler<>).GetTypeInfo().Assembly;
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));

        services
            .AddTransient<IRequestHandler<CountFruitRequest<Apple>, string>, CountFruitRequestHandler<Apple>>()
            .AddTransient<IRequestHandler<CountFruitRequest<Orange>, string>, CountFruitRequestHandler<Orange>>();

        return services;
    }
}
