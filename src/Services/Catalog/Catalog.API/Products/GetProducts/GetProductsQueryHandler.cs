using Marten;
using Marten.Internal;
using Marten.Linq.QueryHandlers;
using Marten.Pagination;
using System.Data.Common;
using Weasel.Postgresql;

namespace Catalog.API.Products.GetProducts
{
    public record GetProductsQuery():IQuery<GetProductsResult>;
    public record GetProductsResult(IEnumerable<Product> Products);

    public class GetProductsQueryHandler(IDocumentSession session,ILogger<GetProductsQueryHandler> logger) :
        IQueryHandler<GetProductsQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            var products =  session.Query<Product>();

            return new GetProductsResult([.. products]);
        }
    }
}
