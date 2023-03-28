using AutoMapper;
using Student_Admin_Portal.API.Models;
using Student_Admin_Portal.API.Models.DTO;

namespace Student_Admin_Portal.API.Profiles.AfterMaps
{
    public class UpdateStudentRequestAfterMap : IMappingAction<UpdateStudentRequestDTO, Student>
    {
        public void Process(UpdateStudentRequestDTO source, Student destination, ResolutionContext context)
        {
            destination.Address = new Address
            {
                PhysicalAddress = source.PhysicalAddress,
                PostalAddress = source.PostalAddress
            };
        }
    }
}