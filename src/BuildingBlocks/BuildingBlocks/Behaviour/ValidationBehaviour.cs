using BuildingBlocks.CQRS;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationException = FluentValidation.ValidationException;

namespace BuildingBlocks.Behaviour
{
    public class ValidationBehaviour<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators) : 
        IPipelineBehavior<TRequest, TResponse>
        where TRequest : ICommand<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
           var validationRes= await Task.WhenAll(validators.Select(v=>v.ValidateAsync(context,cancellationToken)));

            var failures = validationRes.Where(x=>x.Errors.Any()).SelectMany(x=>x.Errors).ToList();

            if (failures.Any())
            {
                throw new ValidationException(failures);
            }
           return await next(); 
        }
    }
}
