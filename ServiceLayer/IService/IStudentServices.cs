
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crude.Api.Service.IService
{
    public interface IStudentServices
    {
        Task AddNewStudent(Student student);
        Task Delete(int id);
        Task EditStudent(int id, Student student);
        Task<List<Student>> StudentList();
        Task< List<Student>> GetStudentDetails(int id);
       
    }
}
