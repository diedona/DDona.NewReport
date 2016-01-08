using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDona.NewReport.Web.Models.FakeModel
{
    public class Grupo
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public string Estado { get; set; }
        public List<Item> Itens { get; set; }

        public Grupo()
        {
            Itens = new List<Item>();
        }
    }
}