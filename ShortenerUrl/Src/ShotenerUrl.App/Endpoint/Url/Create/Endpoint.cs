namespace ShotenerUrl.App.Endpoint;

public class CreateShortUrlEndpoint : IEndpoint, IEndpointHandler<CreateShortUrlRequest>
{
    public Task<ApiModel> HandlerAsync(CreateShortUrlRequest request, IMediator mediator, IMapper mapper)
    {

    }

    public void MapEndpoint(IEndpointRouteBuilder app)
        => app.MapPost(UrlSchema.Create, HandlerAsync)
                .WithTags(UrlSchema.Tag)
        .Validator<CreateShortUrlRequest>();
}
