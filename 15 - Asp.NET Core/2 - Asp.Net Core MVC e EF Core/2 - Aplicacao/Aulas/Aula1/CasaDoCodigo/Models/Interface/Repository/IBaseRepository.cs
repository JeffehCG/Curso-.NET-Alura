using CasaDoCodigo.Models.Base;
using System;
using System.Collections.Generic;

namespace CasaDoCodigo.Models.Interface.Repository
{
    public interface IBaseRepository<TEntity> where TEntity : BaseModel
    {
        List<TEntity> GetAll();
        TEntity GetByParameter(Func<TEntity, bool> lambdaExpression);
        void Save(TEntity entity);
        void SaveAll(List<TEntity> entity);
        void Updade(TEntity entity);
    }
}