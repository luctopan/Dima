using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Orders;
using Dima.Core.Responses;

namespace Dima.Api.Endpoints.Orders;

public class GetProductBySlugEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapGet("/{slug}", HandleAsync)
            .WithName("Products: Get By Slug")
            .WithSummary("Gets a product by a Slug")
            .WithDescription("Gets a product by a Slug")
            .WithOrder(2)
            .Produces<Response<Product?>>();

    private static async Task<IResult> HandleAsync(
        IProductHandler handler,
        string slug)
    {
        var request = new GetProductBySlugRequest
        {
            Slug = slug
        };

        var result = await handler.GetBySlugAsync(request);

        return result.IsSuccess
            ? TypedResults.Ok(result)
            : TypedResults.BadRequest(result);
    }
}