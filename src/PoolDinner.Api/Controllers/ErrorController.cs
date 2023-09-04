using PoolDinner.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace PoolDinner.Api.Controllers
{
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            switch (exception)
            {
                case IServiceException serviceException:
                    return Problem(
                        serviceException.StatusCode.ToString(),
                        serviceException.ErrorMessage
                    );
                default:
                    return Problem(
                        StatusCodes.Status500InternalServerError.ToString(),
                        $"Unknown Error: {exception?.Message.ToString()}"
                    );
            }
        }
    }
}
