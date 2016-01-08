using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDona.NewReport.Web.ViewModel.DataTables
{
    public class DataTablesViewModel
    {
        public int draw { get; set; }
        public List<DataTableColumn> columns { get; set; }
        public List<DataTableOrder> order { get; set; }
        public int start { get; set; }
        public int length { get; set; }
        public DataTableSearch search { get; set; }
    }
}