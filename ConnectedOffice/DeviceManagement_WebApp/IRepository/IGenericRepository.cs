using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.IRepository
{
    public interface IGenericRepository<T> where T : class
    {

        Task<IEnumerable<T>> All();
        Task<T> GetById(Guid id);
        Task<bool> Add(T entity);
        Task<bool> Delete(Guid id);
        Task<bool> Upsert(T entity);







        /*
        //Get’s the entity By Id.
        T GetById(int id);

        // Get’s all the Record.
        IEnumerable<T> GetAll();

        //Finds a set of record that matches the passed expression.
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);

        //Adds a new record to the context
        void Add(T entity);

        //Add a list of records
        void AddRange(IEnumerable<T> entities);

        //Removes a record from the context
        void Remove(T entity);

        //Removes a list of records.
        void RemoveRange(IEnumerable<T> entities);*/
    }

}
