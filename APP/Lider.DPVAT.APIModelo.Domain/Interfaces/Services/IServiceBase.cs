﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Lider.DPVAT.APIModelo.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        TEntity Add(TEntity obj);
        void AddRange(List<TEntity> obj);
        void AddRange(TEntity[] obj);
        void AddRangeDefault(List<TEntity> obj);
        void AddRangeDefault(TEntity[] obj);
        void UpdateRange(List<TEntity> obj);
        void UpdateRangeDefault(List<TEntity> obj);
        void DeleteRange(List<TEntity> entity);
        void Delete(Guid id);
        void Delete(int id);
        void Delete(TEntity entity);
        void DeleteBatch(Expression<Func<TEntity, bool>> filterExpression);
        List<TEntity> GetAll();
        List<TEntity> Find(Expression<Func<TEntity, Boolean>> predicate, Boolean @readonly = true, IList<String> eagerLoads = null, int take = 0);
        List<TEntity> GetAllAsNoTracking();
        TEntity GetById(int id);
        TEntity GetById(Guid id);    
        List<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate);
        void Update(TEntity obj);
        void UpdateBatch(Expression<Func<TEntity, bool>> filterExpression, Expression<Func<TEntity, TEntity>> updateExpression);
        int CountEntidade();
        void SaveChange();
    }

}
