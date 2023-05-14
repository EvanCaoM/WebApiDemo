using MediatR;
using System.Collections.Generic;
using WebApiDemo.Domain.OrderAggregate;

namespace WebApiDemo.Application.Queries
{
    public class MyOrderQuery : IRequest<List<Order>>
    {
        public string UserName { get; set; }

        public string UserId { get; set; }


    }
}
