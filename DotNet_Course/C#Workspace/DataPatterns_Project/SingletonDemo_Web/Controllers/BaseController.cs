using Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SingletonDemo_Web.Controllers
{
    public class BaseController : Controller
    {
        private ILogger _ILogger;
        public BaseController()
        {
            _ILogger = Log.GetInstance;
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            _ILogger.LogException(filterContext.Exception.Message);
            filterContext.ExceptionHandled = true;
            this.View("Error").ExecuteResult(this.ControllerContext);
        }

      
    }
}