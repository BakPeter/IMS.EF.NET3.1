using IMS_DAL_RegisterUser;
using IMS_DTO_RegisterUser;
using IMS_Model_User;
using LoggingUtils;
using Microsoft.Extensions.Logging;
using ServiceResponse;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TemplateMethodService;

namespace IMS_Dal_EF_RegisterUserService
{
    public class DalEFRegisterUserServiceImpl : TemplateMethodServiceImp, IDalRegisterUserService
    {
        private readonly RegisterUserContext _DbContext;

        public DalEFRegisterUserServiceImpl(
            RegisterUserContext dbContext, 
            ILogger<DalEFRegisterUserServiceImpl> looger) : base(looger)
        {
            _DbContext = dbContext;
        }

        public async Task<ServiceResponse<RegisterUserResponse>> RegisterUser(RegisterUserDTO userDto)
        {          
            var response =  await TemplateMethod<ServiceResponse<RegisterUserResponse>, RegisterUserDTO>(userDto, LogsUtils.GetCurrentAsyncMethodName());
            
            return response;
        }

        protected async override Task<object> Execute(object dto)
        {
            var response = new ServiceResponse<RegisterUserResponse>();
            var userDto = (RegisterUserDTO)dto;

            //check if user exists
            if (false)
            {
                response.Succsees = false;
                response.Message = "User already exists";
                return response;
            }

            CreatePasswordHash(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = new User
            {
                Name = userDto.UserName,
                Email = userDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            _DbContext.Users.Add(user);
            await _DbContext.SaveChangesAsync();

            response.Data = new RegisterUserResponse { UserId = user.Id };
            return response;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}