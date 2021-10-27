using IMS_DTO_GetUser;
using ServiceResponse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IMS_DAL_GstUserContracts
{
    public interface IDalGetUserService
    {
        Task<ServiceResponse<GetUserResDTO>> GetUser(GetUserReqDTO getUserDto);
    }
}
