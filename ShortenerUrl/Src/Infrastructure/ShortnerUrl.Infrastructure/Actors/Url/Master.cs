using Akka.Actor;
using ShortnerUrl.Infrastructure.Actors.Url.Messages;

namespace ShortnerUrl.Infrastructure.Actors;

public class UrlMaster : ReceiveActor
{
    public UrlMaster()
    {
        Receive<CreateUrlMessage>(CreateUrl);
        Receive<GetUrlMessage>(GetUrl);
    }

    public void CreateUrl(CreateUrlMessage message)
    {

    }

    public void GetUrl(GetUrlMessage message)
    {

    }
}
