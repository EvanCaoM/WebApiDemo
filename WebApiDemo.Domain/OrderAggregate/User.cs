using System;
using System.Collections.Generic;
using System.Text;
using WebApiDemo.Core.Domain.Abstractions;

namespace WebApiDemo.Domain.OrderAggregate
{
    public class User : Entity<long>, IAggregateRoot
    {
        public string UserId { get; private set; }

        public string UserName { get; private set; }

        public int Age { get; private set; }

        protected User()
        { }

        public User(string userId, string userName, int age)
        {
            this.UserId = userId;
            this.UserName = userName;
            this.Age = age;
        }

    }
}
