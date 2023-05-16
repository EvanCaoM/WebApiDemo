using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiDemo.Core.Infrastructure;
using WebApiDemo.Domain.BLL;
using WebApiDemo.Domain.OrderAggregate;

namespace WebApiDemo.Infrastructure.Repositories
{
    public interface IOrderRepository : IRepository<Order, long>
    {
        Task<List<Order>> GetByUserId(string userId);

        Task<List<UserOrder>> QueryUserOrder(string userId);

        Task<List<dynamic>> QueryDynamic(string userId);

    }
}
