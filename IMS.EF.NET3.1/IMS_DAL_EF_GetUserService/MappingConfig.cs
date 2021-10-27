using AutoMapper;
using IMS_DTO_GetUser;
using IMS_DTO_Model_User;
using IMS_Model_User;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS_DAL_EF_GetUserService
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<User, UserDTO>();
            });

            return mappingConfig;
        }
    }
}
