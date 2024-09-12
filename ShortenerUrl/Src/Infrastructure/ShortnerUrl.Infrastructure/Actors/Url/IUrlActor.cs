namespace ShortnerUrl.Infrastructure.Actors;

public interface IUrlActor
{
    Task<string> CreateAsync(string url);

    Task<string> GetAsync(string url);
}
