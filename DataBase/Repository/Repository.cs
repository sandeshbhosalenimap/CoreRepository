using AutoMapper;

using DataBase.IRepository;
using Microsoft.EntityFrameworkCore;
using Models;
using Octopus.Client.Model.Accounts.Usages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private DataBaseContext _context;
    
        public Repository(DataBaseContext AppDbContext )
        {
            _context = AppDbContext;
            
        }
        public async Task Add(T Entity)
        {
            _context.Set<T>().Add(Entity);
            await _context.SaveChangesAsync();

        }

        public async Task Delete(Expression<Func<T, bool>> experssion)
        {
            var data = _context.Set<T>().Where(experssion).FirstOrDefault();
            _context.Set<T>().Remove((T)data);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> Details(Expression<Func<T, bool>> expression)
        {
          
            var details= await _context.Set<T>().Where(expression).AsNoTracking().ToListAsync();
           

            return details;
        }

        public async Task Edit(int id, T Entity)
        {   
            _context.Set<T>().Update(Entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> AllList()
        {
            var data = await _context.Set<T>().ToListAsync();
            return data;
        }
    }
}
