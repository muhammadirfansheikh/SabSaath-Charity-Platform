using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabSath.Data.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity FindByID(int id);
        //TEntity FindByID2(int id);
        IEnumerable<TEntity> FindAll();
        //IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        // This method was not in the videos, but I thought it would be useful to add.
        //TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        int Add(TEntity entity);
        //void AddRange(IEnumerable<TEntity> entities);
        int Insert(TEntity entity);

        void Update(TEntity entity);


        void Remove(TEntity entity);
        //void RemoveRange(IEnumerable<TEntity> entities);
    }
}
