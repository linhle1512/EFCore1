using EFcore.DTOs;
using EFcore.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFcore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public IEnumerable<GetStudentResponse> GetAll()
        {
            return _studentService.GetAll();
        }

        [HttpGet("get-a-student/{id}")]
        public GetStudentResponse? GetById(int id)
        {
            return _studentService.GetById(id);
        }

        [HttpPost("new-student")]
        public AddStudentResponse? Add([FromBody] AddStudentRequest requestModel)
        {
            return _studentService.Create(requestModel);
        }

        [HttpPut("edit-student/{id}")]
        public UpdateStudentResponse? Update(int id, [FromBody] UpdateStudentRequest requestModel)
        {
            return _studentService.Update(id, requestModel);
        }

        [HttpDelete("remove/{id}")]
        public bool Delete(int id)
        {
            return _studentService.Delete(id);
        }
    }
}