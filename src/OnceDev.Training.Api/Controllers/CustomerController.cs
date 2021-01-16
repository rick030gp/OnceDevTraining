using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnceDev.Training.Application.Customer.Commands.Insert;
using OnceDev.Training.Application.Customer.Queries;
using OnceDev.Training.Domain;
using System;
using System.Threading.Tasks;

namespace OnceDev.Training.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetCustomersQuery()));
        }

        [HttpGet("{id:int}", Name = "GetCustomer")]        
        public async Task<ActionResult<Customer>> Get([FromRoute] int id)
        {
            return Ok(await _mediator.Send(new GetCustomerQuery { Id = id }));
        }

        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] PostInsertCustomerCommand postCustomer)
        {
            var customerId = await _mediator.Send(postCustomer);
            return CreatedAtRoute("GetCustomer", new { Id = customerId }, postCustomer);
        }


    }
}
