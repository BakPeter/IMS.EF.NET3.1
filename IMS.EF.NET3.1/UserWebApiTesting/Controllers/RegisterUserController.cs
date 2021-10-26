using IMS_DAL_RegisterUser;
using IMS_DTO_RegisterUser;
using LoggingUtils;
using Microsoft.AspNetCore.Mvc;
using ServiceResponse;
using System.Threading.Tasks;
using TemplateMethodContracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserWebApiTesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterUserController : ControllerBase
    {
        private readonly IDalRegisterUserService _registerService;
        private readonly ITemplateMethodParamService<ServiceResponse<RegisterUserResponse>, RegisterUserDTO> _templateLoggingService;

        public RegisterUserController(
            IDalRegisterUserService registerService,
            ITemplateMethodParamService<ServiceResponse<RegisterUserResponse>, RegisterUserDTO> templateLoggingService)
        {
            _registerService = registerService;
            _templateLoggingService = templateLoggingService;
        }

        // POST api/<RegisterUserController>
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<RegisterUserResponse>>> Post([FromBody] RegisterUserDTO user)
        {
            //var response =  await _registerService.RegisterUser(user);
            var response = await _templateLoggingService.TemplateMethod(
                user,
                LogsUtils.GetCurrentAsyncMethodName(),
                _registerService.RegisterUser);

            return Ok(response);
        }
    }
}