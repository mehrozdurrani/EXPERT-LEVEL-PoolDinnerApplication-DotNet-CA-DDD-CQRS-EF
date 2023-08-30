using PoolDinner.Contracts.Authentication;
using PoolDinner.Api.Controllers;
using PoolDinner.Application.Authentication.Commands.Register;
using PoolDinner.Application.Authentication.Queries;
using PoolDinner.Application.Services.Authentication;

using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PoolDinner.Api.Contollers;

[AllowAnonymous]
[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public AuthenticationController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    // POST /auth/login
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        // Call authentication service's login method

        //var query = new LoginQuery(request.Email, request.Password);

        var query = _mapper.Map<LoginQuery>(request);
        AuthenticationResult authResult = await _mediator.Send(query);

        //AuthenticationResponse response = new(
        //            authResult.user.Id,
        //            authResult.user.Firstname,
        //            authResult.user.LastName,
        //            authResult.user.Email,
        //            authResult.Token);

        var response = _mapper.Map<AuthenticationResponse>(authResult);
        return Ok(response);
    }

    //Post /auth/register
    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(RegisterRequest request)
    {
        // Call authentication service's register method
        //var command = new RegisterCommand(request.FirstName,
        //    request.LastName,
        //    request.Email,
        //    request.Password);

        var command = _mapper.Map<RegisterCommand>(request);

        AuthenticationResult authResult = await _mediator.Send(command);

        //AuthenticationResponse response = new(
        //            authResult.user.Id,
        //            authResult.user.Firstname,
        //            authResult.user.LastName,
        //            authResult.user.Email,
        //            authResult.Token);

        var response = _mapper.Map<AuthenticationResponse>(authResult);

        return Ok(response);
    }
};
