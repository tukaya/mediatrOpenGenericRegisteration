using System.Reflection;
using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;

namespace HandlerProject;

public static class ExtensionsAutoFac
{
    public static ContainerBuilder AddMediatrHandlersWithOpenGeneric(this ContainerBuilder builder)
    {
        var assembly = typeof(CountFruitRequestHandler<>).GetTypeInfo().Assembly;
        var configuration = MediatRConfigurationBuilder
            .Create(assembly)
            .Build();
        builder.RegisterMediatR(configuration);

        builder.RegisterGeneric(typeof(CountFruitRequestHandler<>)).AsImplementedInterfaces();

        return builder;
    }
}
