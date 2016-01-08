using DDona.NewReport.Web.ViewModel.DataTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DDona.NewReport.Web.Controllers
{
    public class DataTableController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult ReportJson(DataTablesViewModel Model)
        {
            return Json(null);
        }
    }
}