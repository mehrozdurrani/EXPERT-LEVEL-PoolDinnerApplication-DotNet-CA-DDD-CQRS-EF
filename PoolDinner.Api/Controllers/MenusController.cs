using PoolDinner.Application.Menus.Commands.CreateMenu;
using PoolDinner.Contracts.Menus;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace PoolDinner.Api.Controllers
{
    [Route("hosts/{hostId}/menus")]
    public class MenusController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public MenusController(IMediator mediator, IMapper mapper )
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> CreateMenu(CreateMenuRequest request, string hostId)
        {
            var command = _mapper.Map<CreateMenuCommand>((request, hostId));
            var createMenuResult = await _mediator.Send(command);
            var response = _mapper.Map<MenuResponse>(createMenuResult);
            return Ok(response);
        }

    }
}

