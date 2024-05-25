using Carter;
using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Catalog.API.Products.GetProducts
{
    public record GetProductSResponse(IEnumerable<Product> Products);
    public class GetProductsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products", async(ISender sender) =>
            {
               var res= await sender.Send(new GetProductsQuery());
                var result= res.Adapt<GetProductSResponse>(); 
                return  Results.Ok(result);
            }).WithName("GetProducts")
        .Produces<GetProductSResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Products")
        .WithDescription("Get Products");
        }
    }
}
