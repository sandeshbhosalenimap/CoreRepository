using Crude.Api.Service.IService;
using DataBase.IRepository;
using Models;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crude.Api.Service.Service
{
    public class StudentServices : IStudentServices
    {
        private IStudentRepository _studentRepository;
        public StudentServices(IStudentRepository student)
        {
            _studentRepository = student;
        }
        public async Task AddNewStudent(Student student)
        {
            await _studentRepository.Add(student);
        }

        public async Task Delete(int id)
        {
            await _studentRepository.Delete(x => x.Id == id);
        }

        public async Task EditStudent(int id, Student student)
        {
            await _studentRepository.Edit(id, student);
        }

      

        public async Task<List<Student>> GetStudentDetails(int id)
        {
            return await _studentRepository.Details(x => x.Id == id);
        }

        public async Task<List<Student>> StudentList()
        {
           return await  _studentRepository.AllList();
        }
    }
}
