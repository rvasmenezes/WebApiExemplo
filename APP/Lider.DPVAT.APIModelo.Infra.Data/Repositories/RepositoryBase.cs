
using EFCore.BulkExtensions;
using Lider.DPVAT.APIModelo.Domain.Interfaces.Repository;
using Lider.DPVAT.APIModelo.Infra.Data.Context;
using Lider.DPVAT.APIModelo.Infra.Data.UnityOfWorks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Transactions;
using Z.EntityFramework.Plus;

namespace Lider.DPVAT.APIModelo.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly IUnitOfWork _unitOfWork;

        public RepositoryBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public virtual TEntity Add(TEntity obj)
        {
            var objreturn = _unitOfWork.Context.Set<TEntity>().Add(obj);
            return objreturn.Entity;
        }


        public void AddRange(List<TEntity> obj)
        {
            _unitOfWork.Context.BulkInsert(obj, new BulkConfig { UseTempDB = false });
        }
        public void AddRange(TEntity[] obj)
        {
            _unitOfWork.Context.BulkInsert(obj, new BulkConfig { UseTempDB = false });
        }

        public void AddRangeDefault(List<TEntity> obj)
        {
            _unitOfWork.Context.AddRange(obj);
        }
        public void AddRangeDefault(TEntity[] obj)
        {
            _unitOfWork.Context.AddRange(obj);
        }

        public void Update(TEntity obj)
        {
            _unitOfWork.Context.ChangeTracker.AutoDetectChangesEnabled = false;
            _unitOfWork.Context.Set<TEntity>().Update(obj);
        }

        public void UpdateRange(List<TEntity> obj)
        {
            _unitOfWork.Context.BulkUpdate(obj, new BulkConfig { UseTempDB = false });
        }
        public void UpdateRangeDefault(List<TEntity> obj)
        {
            _unitOfWork.Context.UpdateRange(obj);
        }

        public void DeleteRange(List<TEntity> obj)
        {
            _unitOfWork.Context.BulkDelete(obj, new BulkConfig { UseTempDB = false });
        }
        public void Delete(Guid id)
        {
            _unitOfWork.Context.Set<TEntity>().Remove(GetById(id));
        }
        public void Delete(int id)
        {
            _unitOfWork.Context.Set<TEntity>().Remove(GetById(id));
        }

        public void Delete(TEntity entity)
        {
            _unitOfWork.Context.Set<TEntity>().Remove(entity);
        }

        public IQueryable<TEntity> GetAll()
        {
            using (var tran = new TransactionScope(TransactionScopeOption.Suppress, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                return _unitOfWork.Context.Set<TEntity>().AsQueryable();
            }
        }

        public IQueryable<TEntity> GetAllAsNoTracking()
        {
            using (var tran = new TransactionScope(TransactionScopeOption.Suppress, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                return _unitOfWork.Context.Set<TEntity>().AsNoTracking();
            }
        }

        public TEntity GetById(Guid id)
        {
            using (var tran = new TransactionScope(TransactionScopeOption.Suppress, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                var entity = _unitOfWork.Context.Set<TEntity>().Find(id);
                return entity;
            }
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, Boolean @readonly = true, IList<string> eagerLoads = null, int take = 0)
        {
            var q = _unitOfWork.Context.Set<TEntity>().Where(predicate);

            if (eagerLoads != null)
            {
                foreach (String eager in eagerLoads)
                {
                    q = q.Include(eager);
                }
            }

            if (take > 0)
            {
                q = q.Take(take);
            }

            if (@readonly)
            {
                using (var tran = new TransactionScope(TransactionScopeOption.Suppress, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    _unitOfWork.Context.Database.SetCommandTimeout(1000);

                    var result = q.AsNoTracking();

                    return result;
                }
            }
            else
            {
                var result = q.AsQueryable();

                foreach (var item in result)
                {
                    _unitOfWork.Context.Entry<TEntity>(item).Reload();
                }

                return result;
            }
        }

        public void UpdateBatch(Expression<Func<TEntity, bool>> filterExpression, Expression<Func<TEntity, TEntity>> updateExpression)
        {
            _unitOfWork.Context.ChangeTracker.AutoDetectChangesEnabled = false;
            _unitOfWork.Context.Set<TEntity>()
              .Where(filterExpression)
              .Update(updateExpression);
        }

        public void DeleteBatch(Expression<Func<TEntity, bool>> filterExpression)
        {
            _unitOfWork.Context.Set<TEntity>()
              .Where(filterExpression)
              .Delete();
        }

        public TEntity GetById(int id)
        {
            using (var tran = new TransactionScope(TransactionScopeOption.Suppress, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                var entity = _unitOfWork.Context.Set<TEntity>().Find(id);
                return entity;
            }
        }

        public IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate)
        {
            using (var tran = new TransactionScope(TransactionScopeOption.Suppress, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                return _unitOfWork.Context.Set<TEntity>().Where(predicate);
            }
        }


        public void SaveChange()
        {
            _unitOfWork.Context.SaveChanges();
        }

        
    }
}
