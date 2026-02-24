using Bms.Core.Domain;
using FluentValidation;

namespace Bms.Core.Application;

public static class FluentValidationClientExceptionExtension
{
    public static IRuleBuilderOptions<T, TProperty> Failure<T, TProperty, TException>(
        this IRuleBuilderOptions<T, TProperty> rule,
        TException exception)
        where TException : ClientException
    {
        int errorCode = (int)exception.Code;

        return rule.WithMessage(exception.Message).WithErrorCode(errorCode.ToString());
    }

    public static IRuleBuilderOptions<T, TProperty> Failure<T, TProperty>(
        this IRuleBuilderOptions<T, TProperty> rule,
        Func<TProperty, ClientException> exceptionFactory)
    {
        int errorCode = (int)exceptionFactory.Invoke(default).Code;

        return rule
            .WithMessage((model, value) => exceptionFactory(value).Message)
            .WithErrorCode(errorCode.ToString());
    }
}