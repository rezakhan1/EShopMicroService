using Marten;
using Marten.Internal;
using Marten.Linq.QueryHandlers;
using Marten.Pagination;
using System.Data.Common;
using Weasel.Postgresql;

namespace Catalog.API.Products.GetProducts
{
    public record GetProductsQuery(int? PagneNumber, int? PageSize):IQuery<GetProductsResult>;
    public record GetProductsResult(IEnumerable<Product> Products);

    public class GetProductsQueryHandler(IDocumentSession session) :
        IQueryHandler<GetProductsQuery, GetProductsResult>
    {
        public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
        {
            var products = await session.Query<Product>().
                ToPagedListAsync(query.PagneNumber??1, query.PageSize??10,cancellationToken);

            return new GetProductsResult(products);
        }
    }
}
