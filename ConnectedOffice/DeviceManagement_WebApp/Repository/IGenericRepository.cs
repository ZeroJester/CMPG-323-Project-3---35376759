using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        //Get’s the entity By Id.
        T GetById(Guid id);



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
        void RemoveRange(IEnumerable<T> entities);
    }

}
