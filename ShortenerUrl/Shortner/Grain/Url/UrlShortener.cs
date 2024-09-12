
namespace Shortner.Grain;

public class UrlShortenerGrain([PersistentState(stateName: UrlSchema.StateName, storageName: UrlSchema.StorageName)] IPersistentState<UrlDetails> state) : Orleans.Grain, IUrlShortenerGrain
{
    public Task<string> GetLongUrlAsync()
        => Task.FromResult(state.State.LongUrl);

    public async Task SetLongUrlAsync(string longUrl)
    {
        state.State = new()
        {
            LongUrl = longUrl,
            ShortCode = this.GetPrimaryKeyString(),
        };

        await state.WriteStateAsync();
    }
}
