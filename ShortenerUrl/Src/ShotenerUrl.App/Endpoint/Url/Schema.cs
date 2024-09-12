namespace ShotenerUrl.App.Endpoint;

public class UrlSchema
{
    public const string Tag = "Url";

    public const string _BaseAddress = $"{EndpointSchema.BaseAddress}url";

    public const string Create = $"{_BaseAddress}/create";

    public const string Get = $"{_BaseAddress}/get";

    public const string Redirect = $"{_BaseAddress}/redirect";
}
