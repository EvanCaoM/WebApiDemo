using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDemo.Core.Infrastructure;
using WebApiDemo.Domain.BLL;
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

        public async Task<List<UserOrder>> QueryUserOrder(string userId)
        {
            var sql = "select userId,count(1) count from `order` where userId=@userId group by userId";
            return (await this.QueryAsync<UserOrder>(sql, new { userId})).ToList();
        }

        public async Task<List<dynamic>> QueryDynamic(string userId)
        {
            var sql = "select userId,count(1) count from `order` where userId=@userId group by userId";
            return (await this.QueryAsync(sql, new { userId })).ToList();
        }

        public async Task<List<dynamic>> QueryJoinDynamic(string userId)
        {
            var sql = "select userId,r.name from `order` o inner join role r on o.id=r.id where userId=@userId";
            return (await this.QueryAsync(sql, new { userId })).ToList();
        }
    }
}
