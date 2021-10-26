using IMS_DTO_Token;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS_DTO_RegisterUser
{
    public class RegisterUserResponse
    {
        public int UserId { get; set; }

        public override string ToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
}
