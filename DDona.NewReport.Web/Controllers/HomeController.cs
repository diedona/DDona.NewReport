﻿using DDona.NewReport.Web.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace DDona.NewReport.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Report()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Report(ReportSearchViewModel Model)
        {
            return PartialView("ReportGroups");
        }

        [HttpPost]
        public ActionResult ReportGroupData(ReportGroupSearchDataViewModel Model)
        {
            //throw new Exception("a");
            Thread.Sleep(TimeSpan.FromSeconds(5));
            return PartialView("ReportGroupData", Model);
        }
    }
}