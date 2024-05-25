
using Catalog.API.Exceptions;
using Marten;

namespace Catalog.API.Products.GetProductById
{
    public record GetProductByIdQuery(Guid Id):IQuery<GetProductByIdResult>;

    public record GetProductByIdResult(Product Product);
    public class GetProductByIdQueryHandler(IDocumentSession session, ILogger<GetProductByIdQueryHandler> logger) : IQueryHandler<GetProductByIdQuery, GetProductByIdResult>
    {
        public async Task<GetProductByIdResult> Handle(GetProductByIdQuery Query, CancellationToken cancellationToken)
        {
            logger.LogDebug("Ecexcuting the ProductById query handler");
           var  result= await session.LoadAsync<Product>(Query.Id, cancellationToken);
            return result is  null ? throw new ProductNotFoundException() : new GetProductByIdResult(result);
        }
    }
}
