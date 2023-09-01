// VERY IMPORTANT: We have placed this registercommand validator
// in Register folder as 'Register' Folder Represents the whole
// 'Register' feature we are working on.

using FluentValidation;

namespace PoolDinner.Application.Authentication.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}

