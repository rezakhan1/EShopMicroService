using Carter;
using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Catalog.API.Products.GetProducts
{
    public record GetProductRequest(int? PagneNumber, int? PageSize);
    public record GetProductSResponse(IEnumerable<Product> Products);
    public class GetProductsEndpoint : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var query= 
            app.MapGet("/products", async([AsParameters] GetProductRequest  request , ISender sender) =>
            {
                var query = request.Adapt<GetProductsQuery>();
               var res= await sender.Send(query);
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
