using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task Add(T Entity);
        Task Delete(Expression<Func<T, bool>> experssion);
        Task Edit(int id, T Entity);
        Task<List<T>> AllList();
        Task<List<T>> Details(Expression<Func<T, bool>> experssion);
    }
}
