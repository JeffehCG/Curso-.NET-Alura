using CasaDoCodigo.Models.Base;
using CasaDoCodigo.Models.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseModel
    {
        protected readonly ApplicationContext context;

        public BaseRepository(ApplicationContext context)
        {
            this.context = context;
        }

        public void SaveAll(List<TEntity> entity)
        {
            context.Set<TEntity>().AddRange(entity);
            context.SaveChanges();
        }

        public List<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public TEntity GetByParameter(Func<TEntity, bool> lambdaExpression)
        {
            return context.Set<TEntity>().Where(lambdaExpression).FirstOrDefault();
        }

        public void Save(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }

        public void Updade(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            context.SaveChanges();
        }
    }
}
