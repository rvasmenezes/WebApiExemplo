using Lider.DPVAT.APIModelo.Domain.Interfaces;
using Lider.DPVAT.APIModelo.Domain.Interfaces.Repository;
using Lider.DPVAT.APIModelo.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace Lider.DPVAT.APIModelo.Domain.Services
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repositorioBase;

        public ServiceBase(IRepositoryBase<TEntity> repositorioBase)
        {
            _repositorioBase = repositorioBase;
        }

        /// <summary>
        /// Metodo adiciona a entidade informada.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>retorna a entidade</returns>
        public TEntity Add(TEntity obj)
        {
            return _repositorioBase.Add(obj);
        }

        public void AddRange(List<TEntity> obj)
        {
            _repositorioBase.AddRange(obj);
        }

        public void AddRange(TEntity[] obj)
        {
            _repositorioBase.AddRange(obj);
        }
        public void AddRangeDefault(List<TEntity> obj)
        {
            _repositorioBase.AddRangeDefault(obj);
        }

        public void AddRangeDefault(TEntity[] obj)
        {
            _repositorioBase.AddRangeDefault(obj);
        }

        public void UpdateRange(List<TEntity> obj)
        {
            _repositorioBase.UpdateRange(obj);

        }
        public void UpdateRangeDefault(List<TEntity> obj)
        {
            _repositorioBase.UpdateRangeDefault(obj);

        }

        public void DeleteRange(List<TEntity> obj)
        {
            _repositorioBase.DeleteRange(obj);

        }

        public void Update(TEntity obj)
        {
            _repositorioBase.Update(obj);

        }

        public List<TEntity> GetAllAsNoTracking()
        {
            return _repositorioBase.GetAllAsNoTracking().ToList();
        }

        public TEntity GetById(int id)
        {
            return _repositorioBase.GetById(id);
        }

        public void Delete(Guid id)
        {
            _repositorioBase.Delete(id);
        }

        public void Delete(int id)
        {
            _repositorioBase.Delete(id);
        }

        public void Delete(TEntity entity)
        {
            _repositorioBase.Delete(entity);
        }

        public void DeleteBatch(Expression<Func<TEntity, bool>> filterExpression)
        {
            _repositorioBase.DeleteBatch(filterExpression);
        }

        public List<TEntity> GetAll()
        {
            return _repositorioBase.GetAll().ToList();
        }

        public List<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool @readonly = true, IList<string> eagerLoads = null, int take = 0)
        {
            return _repositorioBase.Find(predicate).ToList();
        }

        public void UpdateBatch(Expression<Func<TEntity, bool>> filterExpression, Expression<Func<TEntity, TEntity>> updateExpression)
        {
            _repositorioBase.UpdateBatch(filterExpression, updateExpression);
        }

        public TEntity GetById(Guid id)
        {
            return _repositorioBase.GetById(id);
        }
        
        public List<TEntity> GetBy(Expression<Func<TEntity, bool>> predicate)
        {
            return _repositorioBase.GetBy(predicate).ToList();
        }
        public int CountEntidade()
        {
            return _repositorioBase.GetAllAsNoTracking().Count();
        }

        public void SaveChange()
        {
            _repositorioBase.SaveChange();
        }
    }
}
