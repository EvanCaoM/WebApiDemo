using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiDemo.Application.Commands;
using WebApiDemo.Application.Queries;
using WebApiDemo.Domain.OrderAggregate;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<long> CreateOrder([FromBody] CreateOrderCommand cmd)
        {
            return await _mediator.Send(cmd, HttpContext.RequestAborted);
        }

        [HttpGet]
        public async Task<List<Order>> QueryOrder([FromQuery] MyOrderQuery request)
        {
            return await _mediator.Send(request);
        }
    }
}
