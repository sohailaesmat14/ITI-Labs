using AutoMapper;
using WebApiLab2.Models; 
using WebApiLab2.DTOs;   

namespace WebApiLab2.Mapping
{    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentDTO>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Dept.DeptName))

                .ForMember(dest => dest.SupervisorName, opt => opt.MapFrom(src => src.StSuperNavigation.StFname));

            CreateMap<Department, DepartmentDTO>()
                .ForMember(dest => dest.StudentCount, opt => opt.MapFrom(src => src.Students.Count));
        }
    }
}