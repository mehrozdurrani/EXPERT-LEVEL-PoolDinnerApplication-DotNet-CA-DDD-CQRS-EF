using PoolDinner.Application.Common.Errors;
using FluentValidation;
using MediatR;

namespace PoolDinner.Application.Common.Behaviour
{
    public class ValidationBehaviour <TRequest, TResponse> :
        IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : class 
    {
        private readonly IValidator<TRequest>? _validator;

        public ValidationBehaviour(IValidator<TRequest>? validator = null)
        {
            _validator = validator;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if(_validator ==null)
            {
                return await next();
            }

            // TODO: Add request validation logic

            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

            if (validationResult.IsValid)
            {
                return await next();
            }
            // We can also extract errors from the line below
            //var errorMessages = validationResult.Errors.Select(error => error.ErrorMessage).ToList();

            throw new InvalidRegisterInputException();
        }

    }
}



//namespace BuberDinner.Application.Common.Behaviour
//{
//    public class ValidateRegisterCommandBehaviour : IPipelineBehavior<RegisterCommand, AuthenticationResult>
//    {
//        private readonly IValidator<RegisterCommand> _validator;

//        public ValidateRegisterCommandBehaviour(IValidator<RegisterCommand> validator)
//        {
//            _validator = validator;
//        }
//        public async Task<AuthenticationResult> Handle(RegisterCommand request, RequestHandlerDelegate<AuthenticationResult> next, CancellationToken cancellationToken)
//        {
//            // TODO: Add request validation logic

//            var validationResult = await _validator.ValidateAsync(request, cancellationToken);

//            if (validationResult.IsValid)
//            {
//                return await next();
//            }
//            // We can also extract errors from the line below
//            //var errorMessages = validationResult.Errors.Select(error => error.ErrorMessage).ToList();

//            throw new InvalidRegisterInputException();
//        }
//    }
//}
