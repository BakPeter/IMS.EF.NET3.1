using DynamicLoaderService;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TemplateMethodContracts;

namespace TemplateMethodService
{
    public class TemplateMethodParamServiceImpl<TResponse, TDTO>
        : ITemplateMethodParamService<TResponse, TDTO> where TResponse :  class
    {
        protected readonly ILogger _logger;

        public TemplateMethodParamServiceImpl(ILogger logger)
        {
            _logger = logger;
        }

        public Task<TResponse>TemplateMethod(TDTO dto, MethodBase invokeMethod, ITemplateMethodParamService<TResponse, TDTO>.ExecuteMethode f)
        {
            try
            {
                Task<TResponse> retVal = default;

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
