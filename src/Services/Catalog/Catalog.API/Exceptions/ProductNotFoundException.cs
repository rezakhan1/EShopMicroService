using BuildingBlocks.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Catalog.API.Exceptions
{
    public class ProductNotFoundException: NotFoundException
    {
        public ProductNotFoundException(string mssg):base(mssg) { }

        public ProductNotFoundException(Guid id) : base("Product",id) { }


    }
}
