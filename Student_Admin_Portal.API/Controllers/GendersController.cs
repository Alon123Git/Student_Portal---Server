using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Student_Admin_Portal.API.Models;
using Student_Admin_Portal.API.Repositorues.IRepositories;

namespace Student_Admin_Portal.API.Controllers
{
    [ApiController]
    public class GendersController : Controller
    {
        private readonly IStudentRepository _repo;
        private readonly IMapper _mapper;

        public GendersController(IStudentRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllGenders()
        {
            var genderList = await _repo.GetGendersAsync();

            if (genderList == null || !genderList.Any())
            {
                return NotFound();
            }
            return Ok(_mapper.Map<List<Gender>>(genderList));
        }
    }
}