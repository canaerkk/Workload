using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Workload.Models;

namespace Workload.Controllers
{
    public abstract class BaseController : Controller
    {
        protected WorkloadEntities1 db = new WorkloadEntities1();
    }
}