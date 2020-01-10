using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GasstationSimulator.Models;

namespace GasstationSimulator.Controllers
{
    public class SupervisorController : Controller
    {
        public ActionResult Index()
        {
            return View(Context.GetGasStation());
        }
    }
}