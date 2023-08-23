using System.Reflection;
using PoolDinner.Application.Common.Behaviour;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace PoolDinner.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Adding Middleware for MediatR for reading all the IRequest and ICommandHandler Derived Classes.
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));

        // Adding Middleware for FluentValidation
        // services.AddScoped<IPipelineBehavior<RegisterCommand, AuthenticationResult>, ValidationBehaviour>();
        services.AddScoped(typeof( IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

        // Wiring all the validators -> classed from AbstractValidator
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}
