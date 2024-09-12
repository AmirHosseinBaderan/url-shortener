namespace ShortenerUrl.Application.Actors;

public interface IUrlActor
{
    Task<string> CreateAsync(string url);
}
