using Carter;
using Mapster;

namespace Catalog.API.Products.DeleteProduct
{
    public record DeleteProductResult(bool IsSuccess);
    public class DeleteProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/product/{id}", async(Guid id,ISender sender) =>
            {
               var res=await sender.Send(new DeleteProductCommand(id));
                var result = res.Adapt<DeleteProductResult>();

                return Results.Ok(result);
            }).WithName("DeleteProduct")
        .Produces<DeleteProductResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Delete Product")
        .WithDescription("Delete Product");
        }
    }
}
