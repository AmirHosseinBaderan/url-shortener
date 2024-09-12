using Akka.Actor;
using Microsoft.Extensions.DependencyInjection;
using ShortnerUrl.Infrastructure.Actors;

namespace ShortnerUrl.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection ConfigureInfrastructureLayer(this IServiceCollection services)
    {
        services.AddUrlActor<UrlMaster>();

        return services;
    }

    public static void AddUrlActor<TActor>(this IServiceCollection services) where TActor : ReceiveActor
    {
        services.AddSingleton<IUrlActor, UrlActorSystem<TActor>>();
        services.AddHostedService(sp => (UrlActorSystem<TActor>)sp.GetRequiredService<IUrlActor>());
    }
}
