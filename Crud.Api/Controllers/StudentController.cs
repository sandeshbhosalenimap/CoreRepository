
using AutoMapper;
using Crude.Api.Service.IService;
using Crude.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Crude.Api.Controllers
{

    [Route("Student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private  readonly _studentService;
        private readonly IMapper _mapper;
        public StudentController(IStudentServices studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;   
        }

        [HttpGet("StudentList")]
        public async Task<IActionResult> StudentList()
        {
            var data = await _studentService.StudentList();
            if(data == null)
            {
                throw new ArgumentNullException(nameof(data));  
            }
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID([FromRoute] int id)
        {
            var student = await _studentService.GetStudentDetails(id);
            var DTOModel = _mapper.Map<IEnumerable<StudentDTO>>(student);
                return Ok(DTOModel);     
        }

        [HttpPut("UpdateStudent")]
        public async Task<IActionResult> Edit( [FromBody] Student student)
        {
            await _studentService.EditStudent(id, student);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            await _studentService.Delete(id);
            return Ok();
        }

        [HttpPost("AddStudent")]
        public async Task<IActionResult> Create([FromBody] Student student)
        {
            await _studentService.AddNewStudent(student);
            return Ok();
        }

    }
}
