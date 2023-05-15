using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiDemo.Application.Commands;
using WebApiDemo.Application.Queries;
using WebApiDemo.Controllers.Base;
using WebApiDemo.Core.Response;
using WebApiDemo.Domain.OrderAggregate;

namespace WebApiDemo.Controllers
{
    public class OrderController : BaseApiController
    {
        IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<JsonResponse<long>> CreateOrder([FromBody] CreateOrderCommand cmd)
        {
            var result = await _mediator.Send(cmd, HttpContext.RequestAborted);
            return ResponseHelp.Success(result);
        }

        [HttpGet]
        public async Task<JsonResponse<List<Order>>> QueryOrder([FromQuery] MyOrderQuery request)
        {
            var result = await _mediator.Send(request);
            return ResponseHelp.Success(result);
        }
    }
}
