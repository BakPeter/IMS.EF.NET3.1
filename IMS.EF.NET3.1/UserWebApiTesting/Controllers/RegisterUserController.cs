using IMS_DAL_RegisterUser;
using IMS_DTO_RegisterUser;
using Microsoft.AspNetCore.Mvc;
using ServiceResponse;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserWebApiTesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterUserController : ControllerBase
    {
        private readonly IDalRegisterUserService _registerService;

        public RegisterUserController(IDalRegisterUserService registerService)
        {
            _registerService = registerService;
        }

        // POST api/<RegisterUserController>
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<RegisterUserResponse>>> Post([FromBody] RegisterUserDTO user)
        {
            var response =  await _registerService.RegisterUser(user);
            
            return Ok(response);
        }
    }
}
