using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DWS.MovieLibrary.Data.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {

        void Add(T entity);
        void Update(T entity);
        void Delete(string entity);
        void Delete(Expression<Func<T, bool>> where);
        T GetById(string id);
        T Get(Expression<Func<T, bool>> where);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
    }
}
