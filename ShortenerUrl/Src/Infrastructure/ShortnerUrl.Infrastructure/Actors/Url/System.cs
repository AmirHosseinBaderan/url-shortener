using Akka.Actor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShortnerUrl.Infrastructure.Actors.Url.Messages;

namespace ShortnerUrl.Infrastructure.Actors;

public class UrlActorSystem<TActor> : IUrlActor, IHostedService where TActor : ReceiveActor
{
    private readonly IServiceScopeFactory _scopeFactory;

    private IActorRef _urlMaster;

    public UrlActorSystem(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
        ActorSystem system = ActorSystem.Create(Schema.SystemName);
        _urlMaster = system.ActorOf(Props.Create(typeof(TActor), _scopeFactory), Schema.ActorName);
    }

    public async Task<string> CreateAsync(string url)
            => await _urlMaster.Ask<string>(message: new CreateUrlMessage(url),
                                            timeout: TimeSpan.FromSeconds(3));


    public async Task<string> GetAsync(string url)
        => await _urlMaster.Ask<string>(message: new GetUrlMessage(url),
                                        timeout: TimeSpan.FromSeconds(3));

    // IHostedService
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await _urlMaster.GracefulStop(TimeSpan.FromSeconds(3));
        await Task.CompletedTask;
    }
}
