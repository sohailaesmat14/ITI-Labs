using AutoMapper;
using WebApiLab3.Models; 
using WebApiLab3.DTOs;   

namespace WebApiLab3.Mapping
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