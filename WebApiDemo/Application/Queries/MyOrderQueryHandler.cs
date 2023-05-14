using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WebApiDemo.Core.Extensions;
using WebApiDemo.Domain.OrderAggregate;
using WebApiDemo.Infrastructure.Repositories;

namespace WebApiDemo.Application.Queries
{
    public class MyOrderQueryHandler : IRequestHandler<MyOrderQuery, List<Order>>
    {
        IOrderRepository _orderRepository;

        public MyOrderQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<Order>> Handle(MyOrderQuery request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetByUserId(request.UserId);
        }
    }
}
