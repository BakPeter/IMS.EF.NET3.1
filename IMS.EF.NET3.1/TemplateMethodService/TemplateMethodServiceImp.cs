using LoggingUtils;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TemplateMethodContracts;

namespace TemplateMethodService
{
    abstract public class TemplateMethodServiceImp
    {
        protected readonly ILogger _logger;

        protected TemplateMethodServiceImp(ILogger logger)
        {
            _logger = logger;
        }

        protected async Task<TResponse> TemplateMethod<TResponse, TDTO>(TDTO dto, string invokedMethodName) where TResponse : class
        {
            //var methodeName = GetCurrentMethod();
            var methodeName = LogsUtils.GetCurrentAsyncMethodName();

            try
            {
                //Task<TResponse> retVal = default;

                if (invokedMethodName != null)
                    _logger.LogInformation("Begin Method : {0} => {1}", invokedMethodName, methodeName);
                else
                    _logger.LogInformation("Begin Method : {0}", methodeName);

                _logger.LogInformation("Parameters:{0}", dto.ToString());
                #region ConcreteImplementation
                TResponse retVal =  await Execute(dto) as TResponse;
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
                if (invokedMethodName != null)
                    _logger.LogInformation("End Method : {0} => {1}", invokedMethodName, methodeName);
                else
                    _logger.LogInformation("EndMethod : {0}", methodeName);
            }
        }

        abstract protected Task<object> Execute(object dto);
    }
}
