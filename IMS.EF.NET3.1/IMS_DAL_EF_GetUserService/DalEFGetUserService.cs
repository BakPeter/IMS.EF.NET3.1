using AutoMapper;
using IMS_DAL_GstUserContracts;
using IMS_DTO_GetUser;
using IMS_DTO_Model_User;
using LoggingUtils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ServiceResponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TemplateMethodService;

namespace IMS_DAL_EF_GetUserService
{
    public class DalEFGetUserService : TemplateMethodServiceImp, IDalGetUserService
    {
        private readonly IMapper _mapper;
        private readonly GetUserContext _dbContext;

        public DalEFGetUserService(
            IMapper mapper,
            GetUserContext dbContext,
            ILogger logger) : base(logger)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<ServiceResponse<GetUserResDTO>> GetUser(GetUserReqDTO getUserDto)
        {
            return await TemplateMethod<ServiceResponse<GetUserResDTO>, GetUserReqDTO>(
                getUserDto,
                LogsUtils.GetCurrentAsyncMethodName());
        }

        protected async override Task<object> Execute(object dto)
        {
            var response = new ServiceResponse<GetUserResDTO>();
            var getUserDTO = (GetUserReqDTO)dto;

            var user = await _dbContext.Users.FirstOrDefaultAsync(u =>
               u.Name.ToLower().Equals(getUserDTO.Name.ToLower()) &&
               u.Email.ToLower().Equals(getUserDTO.Email.ToLower()));

            if (user == null)
            {
                response.Message = "User not found.";
                response.Data = new GetUserResDTO ();
            }
            else
            {
                response.Data = new GetUserResDTO { User = _mapper.Map<UserDTO>(user) };
            }

            return response;
        }
    }
}
