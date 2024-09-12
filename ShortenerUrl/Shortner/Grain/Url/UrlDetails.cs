namespace Shortner.Grain;

[GenerateSerializer, Alias(nameof(UrlDetails))]
public class UrlDetails
{
    [Id(0)]
    public string LongUrl { get; set; } = null!;

    [Id(1)]
    public string ShortCode { get; set; } = null!;
}