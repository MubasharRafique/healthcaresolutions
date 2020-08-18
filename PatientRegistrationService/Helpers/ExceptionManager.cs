using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRegistrationService.Helpers
{
    public static class ExceptionManager
    {
        private static string exceptionChainStr = "";
        public static string GetExceptionStackTrace(Exception ex)
        {
            if (ex.InnerException == null)
            {
                return exceptionChainStr + "\n" + ex.Message;
            }
            else
            {
                return GetExceptionStackTrace(ex.InnerException);
            }

        }
    }
}
