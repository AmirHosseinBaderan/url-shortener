using Akka.Actor;
using Microsoft.Extensions.DependencyInjection;
using ShortenerUrl.Application.Actors;
using ShortenerUrl.Application.Service.Abstraction;

namespace ShortenerUrl.Application.Service.Implementation;

public class UrlActor : IUrlActor
{
    private readonly IServiceScopeFactory _scopeFactory;

    private readonly IActorRef _urlMaster;

    public UrlActor(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
        ActorSystem system = ActorSystem.Create(ActorSchema.SystemName);

    }

    public Task<string> CreateAsync(string url)
    {
        throw new NotImplementedException();
    }
}
