using Blazor.Shared.Models;
using Blazor.Shared.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blazor.Server.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentOperationsController : ControllerBase
    {
        private readonly IStudentServices studentServices;
        public StudentOperationsController(IStudentServices _studentServices)
        {
            studentServices = _studentServices;
        }
        [HttpGet]
        [Route("get-students-list")]
        public async Task<IActionResult> GetStudentsList()
        {
            List<StudentEntity> students = new List<StudentEntity>();
            students=studentServices.GetAllStudent().ToList();
            return Ok(students);
        }
    }
}
