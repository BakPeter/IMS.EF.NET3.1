using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace LoggerContracts
{
    public interface ILoggerParamService<TResponse, TDTO> where TResponse : class
    {
        public delegate TResponse ExecuteMethod(TDTO dto);

        //public TResponse TemplateMethod(TDTO dto, MethodBase? invokeMethod, ExecuteMethode f)
        //    <TResponse, TDTO> where TResponse : class;

        public TResponse TemplateLoogerMethod(TDTO dto, MethodBase invokeMethod, ExecuteMethod f);
    }
}
