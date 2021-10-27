using IMS_DAL_GstUserContracts;
using IMS_DTO_GetUser;
using LoggingUtils;
using Microsoft.AspNetCore.Mvc;
using ServiceResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemplateMethodContracts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserWebApiTesting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetUserController : ControllerBase
    {
        private readonly IDalGetUserService _getUserService;
        private readonly ITemplateMethodParamService<ServiceResponse<GetUserResDTO>, GetUserReqDTO> _templateLoggingService;

        public GetUserController(
            IDalGetUserService registerService,
            ITemplateMethodParamService<ServiceResponse<GetUserResDTO>, GetUserReqDTO> templateLoggingService)
        {
            _getUserService = registerService;
            _templateLoggingService = templateLoggingService;
        }
        // GET: api/<GetUserController>
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<GetUserResDTO>>> Get(GetUserReqDTO reqDTO)
        {
            var response = await _templateLoggingService.TemplateMethod(
                reqDTO,
                LogsUtils.GetCurrentAsyncMethodName(),
                _getUserService.GetUser);

            return Ok(response);
        }
    }
}
