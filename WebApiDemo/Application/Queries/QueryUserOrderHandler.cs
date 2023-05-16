using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using WebApiDemo.Core.Extensions;
using WebApiDemo.Domain.BLL;
using WebApiDemo.Domain.OrderAggregate;
using WebApiDemo.Infrastructure.Repositories;

namespace WebApiDemo.Application.Queries
{
    public class QueryUserOrderHandler : IRequestHandler<QueryUserOrder, List<UserOrder>>
    {
        IOrderRepository _orderRepository;

        public QueryUserOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<UserOrder>> Handle(QueryUserOrder request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_orderRepository.QueryUserOrder(request.UserId));
        }
    }
}
