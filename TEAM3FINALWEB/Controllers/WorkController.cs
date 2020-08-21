using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TEAM3FINALWEB.DAC;

namespace TEAM3FINALWEB.Controllers
{
    public class WorkController : Controller
    {
        // GET: Work
        public ActionResult Index()
        {
            WorkDAC dac = new WorkDAC();
            ViewBag.PQ = dac.GetProductQTYBYFclt();
            ViewBag.fcount = dac.GetCountFcltWork();
            ViewBag.Icount = dac.GetCountInstack();
            ViewBag.ItemCount = dac.GetCountITEM();
            return View();
        }
    }
}