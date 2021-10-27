using AutoMapper;
using IMS_DTO_RegisterUser;
using IMS_Model_User;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS_Dal_EF_RegisterUserService
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<RegisterUserReqDTO, User>();
            });

            return mappingConfig;
        }
    }
}
