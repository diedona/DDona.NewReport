using DDona.NewReport.Web.Models.FakeModel;
using DDona.NewReport.Web.ViewModel;
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

        public JsonResult ReportJson(RelatoroDataTablesViewModel Model)
        {
            DataTableReturn Return = new DataTableReturn();
            Return.draw = Model.draw;
            List<Grupo> Grupos = FakeGrupoData();
            Return.data = FilterData(Grupos, Model).ToArray();

            //RECORDS FILTERED É O TOTAL QUE EXISTIA, COM FILTRO, ANTES DE DARMOS SKIP/TAKE
            Return.recordsFiltered = Grupos.Count();
            Return.recordsTotal = Grupos.Count();

            return Json(Return);
        }

        private List<Grupo> FilterData(List<Grupo> Grupos, RelatoroDataTablesViewModel Model)
        {
            int ColumnIdx = Model.order.FirstOrDefault().column;
            string OrderColumn = Model.columns.ElementAt(ColumnIdx).name;

            return Grupos.Where(x => (Model.Status == null) || Model.Status.Contains(x.Status))
                .Where(x => (string.IsNullOrWhiteSpace(Model.Estado)) || x.Estado.Equals(Model.Estado))
                .OrderBy(x => x.Estado)
                .Skip(Model.start)
                .Take(Model.length)
                .ToList();
        }

        private List<Grupo> FakeGrupoData()
        {
            List<Grupo> Grupos = new List<Grupo>();

            #region GERANDO DADOS FALSOS DE GRUPOS (fixo)
            Grupos.Add(new Grupo() { Id = 1, Estado = "BAIER", Status = 2 });
            Grupos.Add(new Grupo() { Id = 2, Estado = "Kruioa", Status = 2 });
            Grupos.Add(new Grupo() { Id = 3, Estado = "Lkajrto", Status = 1 });
            Grupos.Add(new Grupo() { Id = 4, Estado = "Lotir", Status = 3 });
            Grupos.Add(new Grupo() { Id = 5, Estado = "Jurta", Status = 1 });
            Grupos.Add(new Grupo() { Id = 6, Estado = "Looit", Status = 2 });
            Grupos.Add(new Grupo() { Id = 7, Estado = "Muriar", Status = 1 });
            Grupos.Add(new Grupo() { Id = 8, Estado = "POROT", Status = 3 });
            Grupos.Add(new Grupo() { Id = 9, Estado = "Jraie", Status = 1 });
            Grupos.Add(new Grupo() { Id = 10, Estado = "OKRR", Status = 2 });
            Grupos.Add(new Grupo() { Id = 11, Estado = "Lriai", Status = 2 });
            Grupos.Add(new Grupo() { Id = 12, Estado = "Jurua", Status = 1 });
            Grupos.Add(new Grupo() { Id = 13, Estado = "Klar", Status = 3 });
            #endregion

            return Grupos;
        }
    }
}