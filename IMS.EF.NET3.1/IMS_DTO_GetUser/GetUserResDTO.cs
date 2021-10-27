using IMS_DTO_Model_User;
using IMS_Model_User;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS_DTO_GetUser
{
    public class GetUserResDTO
    {
        public UserDTO User { get; set; }
        public bool UserExists
        {
            get
            {
                return User != null;
            }
        }

        public override string ToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
}
