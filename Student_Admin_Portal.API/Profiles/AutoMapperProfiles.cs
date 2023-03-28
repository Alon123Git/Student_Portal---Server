using AutoMapper;
using Student_Admin_Portal.API.Models;
using Student_Admin_Portal.API.Models.DTO;
using Student_Admin_Portal.API.Profiles.AfterMaps;

namespace Student_Admin_Portal.API.Profiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Student, StudentDTO>().ReverseMap();
            CreateMap<Gender, GenderDTO>().ReverseMap();
            CreateMap<Address, AddressDTO>().ReverseMap();

            CreateMap<UpdateStudentRequestDTO, Student>().AfterMap<UpdateStudentRequestAfterMap>();
            CreateMap<AddStudentRequestDTO, Student>()
                .AfterMap<AddStudentRequestAfterMap>();
        }
    }
}