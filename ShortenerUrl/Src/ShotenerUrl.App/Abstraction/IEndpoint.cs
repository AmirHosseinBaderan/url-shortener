namespace ShotenerUrl.App.Abstraction;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}

public interface IEndpointHandler<TRequest>
{
    Task<ApiModel> HandlerAsync(TRequest request, IMediator mediator, IMapper mapper);
}

public interface IEndpointHandler
{
    Task<ApiModel> HandlerAsync(IMediator mediator, IMapper mapper);
}