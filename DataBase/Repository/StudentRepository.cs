
using DataBase.IRepository;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Repository
{
    public class StudentRepository : Repository<Student> , IStudentRepository 
    {
        private DataBaseContext _context;
        public StudentRepository(DataBaseContext repositoryContext) : base(repositoryContext)
        {
            _context= repositoryContext;
        }

        public async Task< Student> GetStudentBYaName(string name)
        {
           var data = await _context.Students.SingleOrDefaultAsync(s => s.Name == name);
            return data;
            
        }
    }
}
