using CasaDoCodigo.Models.Base;
using System;
using System.Collections.Generic;

namespace CasaDoCodigo.Models.Interface.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : BaseModel
    {
        List<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity GetByParameter(Func<TEntity, bool> lambdaExpression);
        void Remove(TEntity entity);
        void Save(TEntity entity);
        void SaveAll(List<TEntity> entity);
        void Updade(TEntity entity);
    }
}