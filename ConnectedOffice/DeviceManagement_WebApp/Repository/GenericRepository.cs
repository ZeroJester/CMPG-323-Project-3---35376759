//Marcel Joubert - 35376759//

using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ConnectedOfficeContext _context;
        public GenericRepository(ConnectedOfficeContext context)
        {
            _context = context;
        }


        //Implementation for the generic Create method//
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }


        //Implementation for the generic AddRange method//
        public void AddRange(IEnumerable<T> entities)
        {
            _context.Set<T>().AddRange(entities);
            _context.SaveChanges();
        }


        //Implementation for the generic Find method//
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }


        //Implementation for the generic Index method//
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }


        //Implementation for the generic Details method//
        public T GetById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }


        //Implementation for the Delete method//
        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }


        //Implementation for the RemoveRange  method//
        public void RemoveRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
            _context.SaveChanges();
        }


        //Implementation for Edit method//
        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }


        //Return a selected device with its correlated device ID and category ID//
        public Object ReturnDevices()
        {
            var data = _context.Device.Include(d => d.Category).Include(d => d.Zone);
            return data;
        }


        //Return a list of all zone IDs//
        public SelectList ReturnZoneList()
        {
            var data = new SelectList(_context.Zone, "ZoneId", "ZoneId");
            return data;

        }


        //Return a list of all category IDs
        public SelectList ReturnCategoryList()
        {
            var data = new SelectList(_context.Category, "CategoryId", "CategoryId");
            return data;
        }


        //Return the selected device's category ID//
        public Category ReturnCatId(Guid id)
        {
            Category categoryId = _context.Category.Find(id);
            return categoryId;

        }


        //Return the selected device's zone ID//
        public Zone ReturnZoneId(Guid id)
        {
            Zone zoneId = _context.Zone.Find(id);
            return zoneId;
        }
    }
}
