using Dima.Api.Common.Api;
using Dima.Core.Handlers;
using Dima.Core.Models;
using Dima.Core.Requests.Categories;
using Dima.Core.Responses;

namespace Dima.Api.Endpoints.Categories;

public class CreateCategoryEndpoint : IEndpoint
{
    public static void Map(IEndpointRouteBuilder app)
        => app.MapPost("/", HandleAsync)
            .WithName("Categories: Create")
            .WithSummary("Creates a new category")
            .WithDescription("Creates a new category")
            .WithOrder(1)
            .Produces<Response<Category?>>();

    private static async Task<IResult> HandleAsync(ICategoryHandler handler, CreateCategoryRequest request)
    {
        request.UserId = "alex@balta";
        
        var result = await handler.CreateAsync(request);

        return result.IsSuccess
            ? TypedResults.Created($"/{result.Data?.Id}", result)
            : TypedResults.BadRequest(result);
    }
}