using Bms.Core.Domain;
using FluentValidation;
using MediatR;

namespace Bms.Core.Application;

public class ValidationBehaviour<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
{
    private readonly IEnumerable<IValidator> _validators;

    public ValidationBehaviour(IEnumerable<IValidator> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request,
                                  RequestHandlerDelegate<TResponse> next,
                                  CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var validationResults = await Task.WhenAll(
            _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

        var failures = validationResults
            .Where(r => r.Errors.Any())
            .SelectMany(r => r.Errors)
            .ToList();

        if (failures.Any())
        {
            var valError = failures.First();

            var errorCode = new ErrorCode();

            try
            {
                ushort code = ushort.Parse(valError.ErrorCode);

                errorCode = Enum.GetValues(typeof(ErrorCode))
                    .Cast<ErrorCode>()
                    .FirstOrDefault(e => (int)e == code);
            }
            catch { }

            throw new ClientException(errorCode, valError.ErrorMessage);
        }

        return await next();
    }
}
