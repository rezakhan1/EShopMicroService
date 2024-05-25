
using Catalog.API.Exceptions;
using Marten;

namespace Catalog.API.Products.UpdateProduct
{
    public record UpdateProductCommand(Guid Id, string Name, List<string> Category, string Description, string ImageFile, decimal Price):ICommand<UpdateProductResponse>;
    public record UpdateProductResponse(bool IsSuccess);
    public class UpdateProductCommandHandler(IDocumentSession session ,ILogger<UpdateProductCommandHandler> logger) : ICommandHandler<UpdateProductCommand, UpdateProductResponse>
    {
        public async Task<UpdateProductResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            logger.LogDebug("UpdateProductHandler Runing");
            var product =await session.LoadAsync<Product>(request.Id, cancellationToken);
            if (product == null)
            {
                throw new ProductNotFoundException();
            }
            product.Name = request.Name;
            product.Category = request.Category;
            product.Description = request.Description;
            product.ImageFile = request.ImageFile;
            product.Price = request.Price;
            session.Update(product);
            await session.SaveChangesAsync();

            return new UpdateProductResponse(true);
        }
    }
}
