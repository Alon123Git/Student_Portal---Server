using AutoMapper;
using Student_Admin_Portal.API.Models;
using Student_Admin_Portal.API.Models.DTO;

namespace Student_Admin_Portal.API.Profiles.AfterMaps
{
    public class AddStudentRequestAfterMap : IMappingAction<AddStudentRequestDTO, Student>
    {
        public void Process(AddStudentRequestDTO source, Student destination, ResolutionContext context)
        {
            destination.Id = Guid.NewGuid();
            destination.Address = new Address()
            {
                Id = Guid.NewGuid(),
                PhysicalAddress = source.PhysicalAddress,
                PostalAddress = source.PostalAddress
            };
        }
    }
}
