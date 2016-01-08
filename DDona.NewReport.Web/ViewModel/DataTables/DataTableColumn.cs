using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDona.NewReport.Web.ViewModel.DataTables
{
    public class DataTableColumn
    {
        public string data { get; set; }
        public string name { get; set; }
        public bool searchable { get; set; }
        public bool orderable { get; set; }
        public DataTableSearch search { get; set; }
    }
}