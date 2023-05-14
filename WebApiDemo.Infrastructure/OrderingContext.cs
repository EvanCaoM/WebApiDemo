using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApiDemo.Core.Infrastructure;
using WebApiDemo.Domain.OrderAggregate;
using WebApiDemo.Infrastructure.EntityConfigurations;

namespace WebApiDemo.Infrastructure
{
    public class OrderingContext : EFContext
    {
        public OrderingContext(DbContextOptions options, IMediator mediator) : base(options, mediator)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region 注册领域模型与数据库的映射关系
            modelBuilder.ApplyConfiguration(new OrderEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }
}
