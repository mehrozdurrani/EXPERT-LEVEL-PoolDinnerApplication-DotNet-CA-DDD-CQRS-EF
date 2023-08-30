using PoolDinner.Api;
using PoolDinner.Application;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddPresentation()
        .AddApplication().
        AddInfrastructure(builder.Configuration);
}

var app = builder.Build();
{
    //app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.UseAuthentication(); // Sets up All the parameters for Authentication, such as Claims, Authentication Scheme etc, Token Validaton etc.
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
