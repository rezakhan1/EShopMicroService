using Carter;
using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Catalog.API.Products.UpdateProduct
{
    public record UpdateProductRequest(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price):ICommand<UpdateProductResponse>;
    public record UpdateProductResult(bool IsSuccess);
    public class UpdateProductEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/products", async(UpdateProductRequest request, ISender sender) =>
            {
                var updateCommand= request.Adapt<UpdateProductCommand>();
               var res= await sender.Send(updateCommand);
                var result = res.Adapt<UpdateProductResult>();
                return Results.Ok(result);
            }).WithName("UpdateProduct")
            .Produces<UpdateProductResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .ProducesProblem(StatusCodes.Status404NotFound)
            .WithSummary("Update Product")
            .WithDescription("Update Product");
        }
    }
}
