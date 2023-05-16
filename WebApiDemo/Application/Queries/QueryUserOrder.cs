using MediatR;
using System.Collections.Generic;
using WebApiDemo.Domain.BLL;

namespace WebApiDemo.Application.Queries
{
    public class QueryUserOrder : IRequest<List<UserOrder>>
    {
        public string UserId { get; set; }
    }
}
