using System;
using System.Collections.Generic;
using System.Text;

namespace IMS_DTO_Token
{
    public class TokenDTO
    {
        public string Value { get; set; }

        public override string ToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
}
