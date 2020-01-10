using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GasstationSimulator.Models;

namespace GasstationSimulator.Controllers
{
    public class FuelController : Controller
    {
        public ActionResult Index(int gasPumpIndex = 0)
        {
            List<GasPump> gasPumps = Context.GetGasStation().GetGasPumps();
            ViewBag.SelectedGasPumpIndex = gasPumpIndex;

            return View(gasPumps);
        }

        public ActionResult SelectTap(int gasPumpIndex, int tapIndex)
        {
            List<GasPump> gasPumps = Context.GetGasStation().GetGasPumps();

            Tap tap = gasPumps[gasPumpIndex].GetTaps()[tapIndex];
            gasPumps[gasPumpIndex].SelectTap(tap);

            return RedirectToAction("Index", new { gasPumpIndex });
        }
        
        [HttpPost]
        public ActionResult Fuel(int gasPumpIndex, int tapIndex, float liter)
        {
            GasPump gasPump = Context.GetGasStation().GetGasPumps()[gasPumpIndex];
            Tap tap = gasPump.GetTaps()[tapIndex];
            gasPump.Fuel(tap, liter);

            return RedirectToAction("Index", new { gasPumpIndex });
        }
    }
}