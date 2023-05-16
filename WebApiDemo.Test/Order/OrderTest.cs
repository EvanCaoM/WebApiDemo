using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemo.Application.Queries;
using WebApiDemo.Domain.BLL;
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
        public async Task QueryTest()
        {
            var result = await _orderRepository.GetByUserId("xiaohong1998");
            Assert.True(result.Count > 0);
        }

        [Fact]
        public async Task DapperTest()
        {
            var result = await _orderRepository.QueryUserOrder("xiaohong1998");
            Assert.True(result.Count > 0);
        }

        [Fact]
        public async Task QueryDictionaryTest()
        {
            var result = await _orderRepository.QueryDynamic("xiaohong1998");
            var rs = result.FirstOrDefault();
            var userOrder = new UserOrder
            {
                UserId = rs.userId,
                Count = (int)rs.count
            };
            Assert.True(result.Count > 0);
        }
    }
}
