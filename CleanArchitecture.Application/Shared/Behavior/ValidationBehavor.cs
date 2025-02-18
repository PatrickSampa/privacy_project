
using FluentValidation;
using MediatR;

namespace CleanArchitecture.Application.Shared.Behavior
{
  public sealed class ValidationBehavor<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
  {



    private readonly IEnumerable<IValidator<TRequest>> _validator;

    public ValidationBehavor(IEnumerable<IValidator<TRequest>> validator)
    {
      _validator = validator;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
      if (!_validator.Any()) return await next();

      var context = new ValidationContext<TRequest>(request);

      if (_validator.Any())
      {
        context = new ValidationContext<TRequest>(request);

        var validationResults = await Task.WhenAll(_validator.Select(v => v.ValidateAsync(context, cancellationToken)));

        var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

        if (failures.Count != 0)
        {
          throw new FluentValidation.ValidationException(failures);
        }
      }

      return await next();
    }
  }
}
