using IMS_Model_User;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS_Model_Toeken
{
    public class Token
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public override string ToString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
}
