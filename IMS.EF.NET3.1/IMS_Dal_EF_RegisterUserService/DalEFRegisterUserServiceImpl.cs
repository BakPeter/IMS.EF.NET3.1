using AutoMapper;
using DynamicLoaderService;
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
    [LoaderAttribute(typeof(IDalRegisterUserService), typeof(DalEFRegisterUserServiceImpl), Policy.Scoped)]
    public class DalEFRegisterUserServiceImpl : TemplateMethodServiceImp, IDalRegisterUserService
    {
        private readonly RegisterUserContext _DbContext;
        private readonly IMapper _mapper;

        public DalEFRegisterUserServiceImpl(
            RegisterUserContext dbContext, 
            ILogger<DalEFRegisterUserServiceImpl> looger,
            IMapper mapper) : base(looger)
        {
            _DbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<RegisterUserResDTO>> RegisterUser(RegisterUserReqDTO userDto)
        {          
            var response =  await TemplateMethod<ServiceResponse<RegisterUserResDTO>, RegisterUserReqDTO>(userDto, LogsUtils.GetCurrentAsyncMethodName());
            
            return response;
        }

        protected async override Task<object> Execute(object dto)
        {
            var response = new ServiceResponse<RegisterUserResDTO>();
            var userDto = (RegisterUserReqDTO)dto;

            CreatePasswordHash(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);

            var user = _mapper.Map<User>(userDto);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            //var user = new User
            //{
            //    Name = userDto.Name,
            //    Email = userDto.Email,
            //    PasswordHash = passwordHash,
            //    PasswordSalt = passwordSalt
            //};

            _DbContext.Users.Add(user);
            await _DbContext.SaveChangesAsync();

            response.Data = new RegisterUserResDTO { UserId = user.Id };
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