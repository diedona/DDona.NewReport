using DDona.NewReport.Web.ViewModel.DataTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDona.NewReport.Web.ViewModel
{
    public class RelatoroDataTablesViewModel : DataTablesViewModel
    {
        public int[] Status { get; set; }
        public string Estado { get; set; }
    }
}