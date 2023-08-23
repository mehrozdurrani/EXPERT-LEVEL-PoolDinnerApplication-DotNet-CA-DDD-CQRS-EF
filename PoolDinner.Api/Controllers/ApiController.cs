using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PoolDinner.Api.Controllers
{
    [Authorize]
    [ApiController]
    public class ApiController : ControllerBase
    {
        public ApiController()
        {
        }
    }
}

