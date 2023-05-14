using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiDemo.Core.Infrastructure.Behaviors;

namespace WebApiDemo.Infrastructure
{
    /// <summary>
    /// 事务
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public class OrderingContextTransactionBehavior<TRequest, TResponse> : TransactionBehavior<OrderingContext, TRequest, TResponse>
    {
        public OrderingContextTransactionBehavior(OrderingContext dbContext, ILogger<OrderingContextTransactionBehavior<TRequest, TResponse>> logger) : base(dbContext, logger)
        {
        }
    }
}
