using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnceDev.Training.Application.Order.Queries.OrderItemQueries;
using OnceDev.Training.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnceDev.Training.Api.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> Get()
        {
            return Ok(await _mediator.Send(new GetOrderItemQuery()));
        }
    }
}
