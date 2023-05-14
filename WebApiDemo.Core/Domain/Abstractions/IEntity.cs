using System;
using System.Collections.Generic;
using System.Text;

namespace WebApiDemo.Core.Domain.Abstractions
{
    /// <summary>
    /// 多个主键的实体
    /// </summary>
    public interface IEntity
    {
        object[] GetKeys();
    }

    /// <summary>
    /// 一个主键的实体
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface IEntity<TKey> : IEntity
    { 
        TKey Id { get; }
    }
}
