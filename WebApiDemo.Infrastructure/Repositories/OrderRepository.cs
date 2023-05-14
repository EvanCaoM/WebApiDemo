using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemo.Core.Infrastructure;
using WebApiDemo.Domain.OrderAggregate;
using WebApiDemo.Infrastructure.Repositories;

namespace WebApiDemo.Infrastructure.Repositories
{
    public class OrderRepository : Repository<Order, long, OrderingContext>, IOrderRepository
    {
        public OrderRepository(OrderingContext context) : base(context)
        {
        }

        public async Task<List<Order>> GetByUserId(string userId)
        {
            //关联User表查询
            return await DbContext.Orders.Include(x => x.User).Where(x => x.UserId.Equals(userId)).ToListAsync();
        }
    }
}
