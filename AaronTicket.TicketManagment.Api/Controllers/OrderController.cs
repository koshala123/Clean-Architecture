using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AaronTicket.TicketManagment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
