
using Marten;

namespace Catalog.API.Products.DeleteProduct
{
    public record DeleteProductCommand(Guid Guid):ICommand<DeleteProductResponse>;
    public record DeleteProductResponse(bool IsSuccess);
    public class DeleteProductHandler(IDocumentSession session, ILogger<DeleteProductHandler> logger) : ICommandHandler<DeleteProductCommand, DeleteProductResponse>
    {
        
        public async Task<DeleteProductResponse> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
             session.Delete<Product>(request.Guid);
           await session.SaveChangesAsync();
            return new DeleteProductResponse(true);
        }
    }
}
