using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Student_Admin_Portal.API.Models;
using Student_Admin_Portal.API.Models.DTO;
using Student_Admin_Portal.API.Repositories.IRepositories;
using Student_Admin_Portal.API.Repositorues.IRepositories;

namespace Student_Admin_Portal.API.Controllers
{
    [ApiController]
    public class StudentsController : Controller
    {
        private readonly IStudentRepository _studentRepo;
        private readonly IImageRepository _imageRepo;
        private readonly IMapper _mapper;

        public StudentsController(IStudentRepository studentReop, IMapper mapper, IImageRepository imageRepo)
        {
            _studentRepo = studentReop;
            _imageRepo = imageRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _studentRepo.GetStudentsAsync();

            return Ok(_mapper.Map<List<Student>>(students));
        }

        [HttpGet]
        [Route("[controller]/{studentId:guid}"), ActionName("GetStudentsAsync")]
        public async Task<IActionResult> GetStudentsAsync([FromRoute] Guid studentId)
        {
            // fetch student details
            var student = await _studentRepo.GetStudentAsync(studentId);

            // return student
            if (student == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Student>(student));
        }

        [HttpPut]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> UpdateStudentAsync([FromRoute] Guid studentId, [FromBody] UpdateStudentRequestDTO request)
        {
            if (await _studentRepo.Exists(studentId))
            {
                var updatedStudent = await _studentRepo.UpdateStudent(studentId, _mapper.Map<Student>(request));

                if (updatedStudent != null)
                {
                    return Ok(_mapper.Map<StudentDTO>(updatedStudent));
                }
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("[controller]/{studentId:guid}")]
        public async Task<IActionResult> DeleteStudentAsync([FromRoute] Guid studentId)
        {
            if (await _studentRepo.Exists(studentId))
            {
                var student = await _studentRepo.DeleteStudentAsync(studentId);
                return Ok(_mapper.Map<Student>(student));
            }

            return NotFound();
        }

        [HttpPost]
        [Route("[controller]/Add")]
        public async Task<IActionResult> AddStudentsync([FromBody] AddStudentRequestDTO request)
        {
            var student = await _studentRepo.AddStudent(_mapper.Map<Student>(request));
            return CreatedAtAction(nameof(GetStudentsAsync), new { studentId = student.Id },
                _mapper.Map<StudentDTO>(student));
        }

        [HttpPost]
        [Route("[controller]/{studentId:guid}/upload-image")]
        public async Task<IActionResult> UploadImage([FromRoute] Guid studentId, IFormFile profileImage)
        {
            var validExtention = new List<string>()
            {
                ".jpeg",
                ".png",
                ".gif",
                ".jpg"
            };

            if (profileImage != null && profileImage.Length > 0)
            {
                var extention = Path.GetExtension(profileImage.FileName);
                if (validExtention.Contains(extention))
                {
                    if (await _studentRepo.Exists(studentId))
                    {
                        var fileName = Guid.NewGuid() + Path.GetExtension(profileImage.FileName);

                        var fileImagePath = await _imageRepo.Upload(profileImage, fileName);

                        if (await _studentRepo.UpdateProfileImage(studentId, fileImagePath))
                        {
                            return Ok(fileImagePath);
                        }

                        return StatusCode(StatusCodes.Status500InternalServerError, "Error uploading image");
                    }
                }

                return BadRequest("This is not a valid image format");
            }

            return NotFound();
        }
    }
}