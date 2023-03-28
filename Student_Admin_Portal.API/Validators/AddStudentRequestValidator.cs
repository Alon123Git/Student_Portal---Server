using FluentValidation;
using Student_Admin_Portal.API.Models.DTO;
using Student_Admin_Portal.API.Repositorues.IRepositories;

namespace Student_Admin_Portal.API.Validators
{
    public class AddStudentRequestValidator : AbstractValidator<AddStudentRequestDTO>
    {
        public AddStudentRequestValidator(IStudentRepository studentRepo)
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.DateOfBirth).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Mobile).GreaterThan(99999).LessThan(10000000000);
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.GenderId).NotEmpty().Must(id =>
            {
                var gender = studentRepo.GetGendersAsync().Result.ToList()
                .FirstOrDefault(x => x.Id == id);

                if (gender != null)
                {
                    return true;
                }

                return false;
            }).WithMessage("Please select a valid gender");
            RuleFor(x => x.PostalAddress).NotEmpty();
            RuleFor(x => x.PhysicalAddress).NotEmpty();
        }
    }
}