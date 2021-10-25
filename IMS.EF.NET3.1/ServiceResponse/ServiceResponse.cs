using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceResponse
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public bool Succsees { get; set; } = true;
        public string Message { get; set; } = null;
    }
}
