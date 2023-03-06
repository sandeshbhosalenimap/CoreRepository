using AutoMapper;
using Crude.Models.ModelDTO;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crude.Models
{
    public class DTO : AutoMapper.Profile
    {
      
        public DTO()
        {
             CreateMap<Student, StudentDTO>().ReverseMap();
        }
    }
}
