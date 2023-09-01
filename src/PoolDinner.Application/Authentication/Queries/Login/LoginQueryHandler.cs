using PoolDinner.Application.Common.Errors;
using PoolDinner.Application.Common.Interfaces.Authentication;
using PoolDinner.Application.Common.Interfaces.Persistence;
using PoolDinner.Application.Services.Authentication;
using PoolDinner.Domain.UserAggregate;
using MediatR;

namespace PoolDinner.Application.Authentication.Queries
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResult>
    {

        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<AuthenticationResult> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask; // temporary to remove warning

            // 1. If User Exists
            if (_userRepository.GetUserByEmail(request.Email) is not User user)
            {
                throw new UserDoesntExistsException();
            }

            // 2. Validate the password is correct

            if (user.Password != request.Email)
            {
                //throw new Exception("Wrong password, try again!");
                throw new WrongUsernameOrPasswordException();
            }

            // 3. Create JWT Token

            var token = _jwtTokenGenerator.GenerateToken(user.Id.Value, user.FirstName, user.LastName);

            return new AuthenticationResult(user, token);
        }
    }
}

