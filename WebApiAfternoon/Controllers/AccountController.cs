using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiAfternoon.Dtos;
using WebApiAfternoon.Repositories.Abstract;

namespace WebApiAfternoon.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IConfiguration _configuration;

        public AccountController(IStudentRepository studentRepository, IConfiguration configuration)
        {
            _studentRepository = studentRepository;
            _configuration = configuration;
        }

        [HttpPost("SignIn")]
        public async Task<ActionResult<string>> Post([FromBody]SignInDto dto)
        {
            var student = await _studentRepository.Get(s => s.Username == dto.Username && s.Password == dto.Password);
            if (student != null)
            {

            }
            return "";
        }   
    }
}
