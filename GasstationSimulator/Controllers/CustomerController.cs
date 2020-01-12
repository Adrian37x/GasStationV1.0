using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GasstationSimulator.Models;

namespace GasstationSimulator.Controllers
{
    public class CustomerController : Controller
    {
        public ActionResult Index(int gasPumpIndex = 0)
        {
            // set selected gas pump Index to select the right one in the view
            ViewBag.SelectedGasPumpIndex = gasPumpIndex;

            return View(Context.GetGasStation());
        }

        public ActionResult SelectTap(int gasPumpIndex, int tapIndex)
        {
            // get selected gas pump
            GasPump gasPump = Context.GetGasStation().GetGasPumps()[gasPumpIndex];

            // get requested tap and call 'SelectTap'
            Tap tap = gasPump.GetTaps()[tapIndex];
            gasPump.SelectTap(tap);

            return RedirectToAction("Index", new { gasPumpIndex });
        }
        
        public ActionResult Refuel(int gasPumpIndex, int tapIndex, float liter)
        {
            // get selected gas pump
            GasPump gasPump = Context.GetGasStation().GetGasPumps()[gasPumpIndex];

            // get tap and call 'Fuel'
            Tap tap = gasPump.GetTaps()[tapIndex];
            gasPump.Refuel(tap, liter);

            return RedirectToAction("Index", new { gasPumpIndex });
        }

        public ActionResult Checkout(int gasPumpIndex)
        {
            // get selected gas pump
            GasPump gasPump = Context.GetGasStation().GetGasPumps()[gasPumpIndex];

            // call 'LockFueling'
            gasPump.LockFueling();

            return RedirectToAction("Index", new { gasPumpIndex });
        }

        public ActionResult SelectCashRegister(int gasPumpIndex, int cashRegisterIndex)
        {
            // get requested cash register and select it
            CashRegister cashRegister = Context.GetGasStation().GetCashRegisters()[cashRegisterIndex];
            cashRegister.SetGasPumpIndexOfPayment(gasPumpIndex);

            return RedirectToAction("Index", new { gasPumpIndex });
        }

        public ActionResult InsertMoney(int gasPumpIndex, int cashRegisterIndex, float value)
        {
            // get selected cash register and call 'InsertMoney'
            Context.GetGasStation().GetCashRegisters()[cashRegisterIndex].InsertMoney(value);

            return RedirectToAction("Index", new { gasPumpIndex });
        }

        public ActionResult Pay(int gasPumpIndex, int cashRegisterIndex)
        {
            // get selected gas pump and cash register
            GasPump gasPump = Context.GetGasStation().GetGasPumps()[gasPumpIndex];
            CashRegister cashRegister = Context.GetGasStation().GetCashRegisters()[cashRegisterIndex];

            // call 'AcceptInput' on selected cash register
            cashRegister.AcceptInput(gasPump.GetPaymentAmount());

            return RedirectToAction("Index", new { gasPumpIndex });
        }

        public ActionResult ReleaseGasPump(int gasPumpIndex, int cashRegisterIndex)
        {
            // 
            GasPump gasPump = Context.GetGasStation().GetGasPumps()[gasPumpIndex];
            CashRegister cashRegister = Context.GetGasStation().GetCashRegisters()[cashRegisterIndex];

            gasPump.Clear();
            cashRegister.Clear();

            return RedirectToAction("Index", new { gasPumpIndex });
        }
    }
}