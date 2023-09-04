using PoolDinner.Application.Common.Errors;
using PoolDinner.Application.Common.Interfaces.Authentication;
using PoolDinner.Application.Common.Interfaces.Persistence;
using PoolDinner.Application.Services.Authentication;
using PoolDinner.Domain.UserAggregate;
using MediatR;

namespace PoolDinner.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResult>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(
            IJwtTokenGenerator jwtTokenGenerator,
            IUserRepository userRepository
        )
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<AuthenticationResult> Handle(
            RegisterCommand request,
            CancellationToken cancellationToken
        )
        {
            await Task.CompletedTask; // temporary to remove warning

            // 1. Check if the user already exists
            if (_userRepository.GetUserByEmail(request.Email) is not null)
            {
                //throw new Exception("User with given email already exists");
                throw new DuplicateEmailException();
            }

            // 2. Create User (generate unique ID)
            var user = User.Create(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password
            );
            _userRepository.Add(user);

            // 3. Create JWT Token
            Guid userId = Guid.NewGuid();
            var token = _jwtTokenGenerator.GenerateToken(
                userId,
                request.FirstName,
                request.LastName
            );
            return new AuthenticationResult(user, token);
        }
    }
}
