using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebApiDemo.Core.Domain.Abstractions;

namespace WebApiDemo.Core.Infrastructure
{
    public abstract class Repository<TEntity, TDbContext> : IRepository<TEntity> where TEntity : Entity, IAggregateRoot where TDbContext : EFContext
    {
        protected virtual TDbContext DbContext { get; set; }

        public Repository(TDbContext context)
        {
            DbContext = context;
        }
        public virtual IUnitOfWork UnitOfWork => DbContext;

        public virtual TEntity Add(TEntity entity)
        {
            return DbContext.Add(entity).Entity;
        }

        public virtual Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Add(entity));
        }

        public virtual TEntity Update(TEntity entity)
        {
            return DbContext.Update(entity).Entity;
        }

        public virtual Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Update(entity));
        }

        public virtual bool Remove(Entity entity)
        {
            DbContext.Remove(entity);
            return true;
        }

        public virtual Task<bool> RemoveAsync(Entity entity)
        {
            return Task.FromResult(Remove(entity));
        }
    }


    public abstract class Repository<TEntity, TKey, TDbContext> : Repository<TEntity, TDbContext>, IRepository<TEntity, TKey> where TEntity : Entity<TKey>, IAggregateRoot where TDbContext : EFContext
    {
        public Repository(TDbContext context) : base(context)
        {
        }

        public virtual bool Delete(TKey id)
        {
            var entity = DbContext.Find<TEntity>(id);
            if (entity == null)
            {
                return false;
            }
            DbContext.Remove(entity);
            return true;
        }

        public virtual async Task<bool> DeleteAsync(TKey id, CancellationToken cancellationToken = default)
        {
            var entity = await DbContext.FindAsync<TEntity>(id, cancellationToken);
            if (entity == null)
            {
                return false;
            }
            DbContext.Remove(entity);
            return true;
        }

        public virtual TEntity Get(TKey id)
        {
            return DbContext.Find<TEntity>(id);
        }

        public virtual async Task<TEntity> GetAsync(TKey id, CancellationToken cancellationToken = default)
        {
            return await DbContext.FindAsync<TEntity>(id, cancellationToken);
        }

        public virtual IEnumerable<dynamic> Query(string sql,object param = null)
        {
            return DbContext.Database.GetDbConnection().Query(sql,param);
        }

        public virtual async Task<IEnumerable<dynamic>> QueryAsync(string sql, object param = null)
        {
            return await DbContext.Database.GetDbConnection().QueryAsync(sql,param);
        }


        public virtual IEnumerable<T> Query<T>(string sql, object param = null)
        {
            return DbContext.Database.GetDbConnection().Query<T>(sql, param);
        }

        public virtual async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null)
        {
            return await DbContext.Database.GetDbConnection().QueryAsync<T>(sql, param);
        }

        public virtual int Execute(string sql, object param = null)
        {
            return DbContext.Database.GetDbConnection().Execute(sql, param);
        }

        public virtual async Task<int> ExecuteAsync<T>(string sql, object param = null)
        {
            return await DbContext.Database.GetDbConnection().ExecuteAsync(sql, param);
        }
    }



}
