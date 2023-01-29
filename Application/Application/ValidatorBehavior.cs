using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace HealthyHole.Application
{
    public class ValidatorBehavior<TRequest, TResponse> 
        : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidatorBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = _validators
                .Select(validator => validator.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(failure => failure != null)
                .ToList();
            if (failures.Count != 0)
            {
                throw new ValidationException(GetErrorMessage(failures), failures);
            }

            return next();
        }

        private string GetErrorMessage(List<ValidationFailure> failures)
        {
            var message = CONSTANTS.VALIDATOR_EXEPTION_MESSAGE;

            foreach (var validationFailure in failures)
            {
                message += $"\n {validationFailure.ErrorMessage}";
            }

            return message;
        }
    }
}