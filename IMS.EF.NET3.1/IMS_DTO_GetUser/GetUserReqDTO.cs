using System;
using System.Collections.Generic;
using System.Text;

namespace IMS_DTO_GetUser
{
    public class GetUserReqDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {

            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
}
