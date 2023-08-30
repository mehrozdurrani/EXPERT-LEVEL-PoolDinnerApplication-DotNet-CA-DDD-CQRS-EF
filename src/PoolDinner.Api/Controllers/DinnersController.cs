using PoolDinner.Api.Controllers;
using Microsoft.AspNetCore.Mvc;


[Route("[controller]")]
public class DinnersController : ApiController
{
    [HttpGet]
    public IActionResult ListDinners()
    {
        return Ok();
    }
}


