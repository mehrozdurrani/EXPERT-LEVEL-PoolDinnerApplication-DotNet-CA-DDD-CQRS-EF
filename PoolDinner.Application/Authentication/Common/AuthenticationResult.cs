using PoolDinner.Domain.UserAggregate;
namespace PoolDinner.Application.Services.Authentication;

public record AuthenticationResult(
    User user,
    string Token
);