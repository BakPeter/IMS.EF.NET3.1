using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace LoggerService
{
    abstract public class LoggerTemplateMethodeServiceImpl
    {
        private readonly ILogger _logger;

        public LoggerTemplateMethodeServiceImpl(ILogger logger)
        {
            _logger = logger;
        }


        protected TResponse TemplateMethod<TResponse, TDTO>(TDTO dto, MethodBase invokeMethod) where TResponse : class
        {
            try
            {
                TResponse retVal = default;

                if (invokeMethod != null)
                    _logger.LogInformation("Begin Method : {0} => {1}", invokeMethod.Name, MethodBase.GetCurrentMethod().Name);
                else
                    _logger.LogInformation("Begin Method : {0}", MethodBase.GetCurrentMethod().Name);

                _logger.LogInformation("Parameters:{0}", dto.ToString());
                #region ConcreteImplementation
                retVal = Execute(dto) as TResponse;
                _logger.LogInformation("RetVal:{0}", retVal.ToString());
                return retVal;
                #endregion
            }
            catch (Exception ex)
            {
                _logger.LogError("Error: {0}, Stack Trace : {1}", ex.Message, ex.StackTrace);
                throw (ex);
            }
            finally
            {
                if (invokeMethod != null)
                    _logger.LogInformation("End Method : {0} => {1}", invokeMethod.Name, MethodBase.GetCurrentMethod().Name);
                else
                    _logger.LogInformation("EndMethod : {0}", MethodBase.GetCurrentMethod().Name);
            }
        }

        abstract protected object Execute(object dto);
    }
}
