using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebApiDemo.Application.Queries;
using WebApiDemo.Infrastructure.Repositories;
using WebApiDemo.Test.Base;
using Xunit;

namespace WebApiDemo.Test.Order
{
    public class OrderTest: TestBase
    {
        public IOrderRepository _orderRepository;
        public OrderTest()
        {
            _orderRepository = Services.GetService<IOrderRepository>();
        }

        [Fact]
        public void DapperTest()
        {
            _orderRepository.QueryUserOrder("123");
        }
    }
}
