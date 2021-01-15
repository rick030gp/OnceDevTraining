using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnceDev.Training.Application.OrderItem.Queries;
using OnceDev.Training.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnceDev.Training.Api.Controllers
{
    [ApiController]
    [Route("api/order_items")]
    public class OrderItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItem>>> Get()
        {
            return Ok(await _mediator.Send(new GetOrderItemItemsQuery()));
        }
    }
}
