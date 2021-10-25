using LoggerContracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace LoggerService
{
    public class LoggerParamServiceImpl<TResponse, TDTO>
        : ILoggerParamService<TResponse, TDTO> where TResponse : class
    {
        private readonly ILogger _logger;

        public LoggerParamServiceImpl(ILogger logger)
        {
            _logger = logger;
        }

        public TResponse TemplateLoogerMethod(TDTO dto, MethodBase invokeMethod, ILoggerParamService<TResponse, TDTO>.ExecuteMethod f)
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
                retVal = f(dto);
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
    }
}
