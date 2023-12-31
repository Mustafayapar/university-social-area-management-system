﻿using DataAccessLayer.Absract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class, new()
    {
        Context _context= new Context();

        DbSet<T> _object;    

        public GenericRepository() 
        {
           _object = _context.Set<T>();
        }


        //****************  
        public void Insert(T obj)
        {
            var addedEntity = _context.Entry(obj);
            addedEntity.State = EntityState.Added;
            //_object.Add(obj);    Solid prensiplerine uygun düzenlendi
            _context.SaveChanges();
        }
        public void Delete(T obj)
        {
            var deletedEntity = _context.Entry(obj);
            deletedEntity.State = EntityState.Deleted;  
            //_object.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(T obj)
        {
            var updatedEntity = _context.Entry(obj);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public List<T> List()
        {

            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();  
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.SingleOrDefault(filter); 
        }
    }
}
