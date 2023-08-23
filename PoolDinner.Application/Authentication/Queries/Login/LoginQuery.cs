using System;
using PoolDinner.Application.Services.Authentication;
using MediatR;

namespace PoolDinner.Application.Authentication.Queries
{
    public record LoginQuery(string Email, string Password):IRequest<AuthenticationResult>;
}

