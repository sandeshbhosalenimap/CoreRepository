using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crude.Models.DTO
{
    public  class ApplicationProfile : AutoMapper.Profile
    {
        public ApplicationProfile() 
        { 
            CreateMap<Student , StudentDTO>().ReverseMap();
        }
    }
}
