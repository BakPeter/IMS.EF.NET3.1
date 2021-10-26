using System;
using System.Reflection;
using System.Threading.Tasks;

namespace TemplateMethodContracts
{
    public interface ITemplateMethodParamService<TResponse, TDTO> where TResponse : class
    {
        public delegate Task<TResponse> ExecuteMethode(TDTO dto);


        //public TResponse TemplateMethod(TDTO dto, MethodBase? invokeMethod, ExecuteMethode f)
        //    <TResponse, TDTO> where TResponse : class;
        public Task<TResponse> TemplateMethod(
            TDTO dto,
            MethodBase? invokeMethod,
            ExecuteMethode f);
    }
}
