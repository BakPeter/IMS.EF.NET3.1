using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace LoggingUtils
{
    public class LogsUtils
    {
        public static string GetCurrentAsyncMethodName([CallerMemberName] string callerName = "", [CallerFilePath] string path = "")
        {
            var splited = path.Split("\\");
            var splited2 = splited[splited.Length - 1].Split(".");
            var controllerName = splited2[0];

            return controllerName + " - " + callerName;
        }

        //public static string GetControllerName([CallerFilePath] string path = "")
        //{
        //    var splited = path.Split("\\");
        //    var splited2 = splited[splited.Length - 1].Split(".");
        //    var controllerName = splited2[0];
        //    return controllerName;
        //}
    }
}
