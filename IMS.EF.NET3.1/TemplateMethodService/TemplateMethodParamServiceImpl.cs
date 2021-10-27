using DynamicLoaderService;
using LoggingUtils;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TemplateMethodContracts;

namespace TemplateMethodService
{
    [LoaderAttribute(typeof(ITemplateMethodParamService<,>), typeof(TemplateMethodParamServiceImpl<,>), Policy.Scoped)]
    public class TemplateMethodParamServiceImpl<TResponse, TDTO>
        : ITemplateMethodParamService<TResponse, TDTO> where TResponse : class where TDTO : class
    {
        protected readonly ILogger _logger;

        public TemplateMethodParamServiceImpl(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> TemplateMethod(TDTO dto, string invokeMethodName, ITemplateMethodParamService<TResponse, TDTO>.ExecuteMethod f)
        {
            var methodName = LogsUtils.GetCurrentAsyncMethodName();

            try
            {
                if (invokeMethodName != null)
                    _logger.LogInformation("Begin Method : {0} => {1}", invokeMethodName, methodName);
                else
                    _logger.LogInformation("Begin Method : {0}", methodName);

                _logger.LogInformation("Parameters:{0}", dto.ToString());
                #region ConcreteImplementation
                TResponse retVal = await f(dto);
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
                if (invokeMethodName != null)
                    _logger.LogInformation("End Method : {0} => {1}", invokeMethodName, methodName);
                else
                    _logger.LogInformation("EndMethod : {0}", methodName);
            }
        }
    }
}
