using Marten;
using Marten.Linq.QueryHandlers;
using System.Linq;

namespace Catalog.API.Products.GetProductByCategory
{
    public record GetProductByCategoryQuery(string Category): IQuery<GetProductByCategoryResult>;
    public record GetProductByCategoryResult(IEnumerable<Product> Products);
    public class GetProductByCategoryHanlder(IDocumentSession session, ILogger<GetProductByCategoryHanlder> logger) : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
    {
        public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery request, CancellationToken cancellationToken)
        {
            logger.LogDebug(" Exectunig the Qury hanlder");
          var res =  await session.Query<Product>().Where(c => c.Category.Contains(request.Category)).ToListAsync(cancellationToken); ;

            return new GetProductByCategoryResult(res);
        }
    }
}
