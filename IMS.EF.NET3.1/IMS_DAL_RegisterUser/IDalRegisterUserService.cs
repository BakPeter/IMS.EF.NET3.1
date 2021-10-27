using IMS_DTO_RegisterUser;
using ServiceResponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMS_DAL_RegisterUser
{
    public interface IDalRegisterUserService
    {
        Task<ServiceResponse<RegisterUserResDTO>> RegisterUser(RegisterUserReqDTO user);
    }
}
