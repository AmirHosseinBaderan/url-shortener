namespace Shortner.Grain;

public interface IUrlShortenerGrain : IGrainWithStringKey
{
    Task SetLongUrlAsync(string longUrl);

    Task<string> GetLongUrlAsync();
}

