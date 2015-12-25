// <auto-generated>
// ReSharper disable RedundantUsingDirective
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable RedundantNameQualifier
// TargetFrameworkVersion = 4.51
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Entity.ModelConfiguration;
using System.Threading;
using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption;

namespace DDona.NewReport.Infra
{
    // Tamanho
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.16.1.0")]
    public class Tamanho
    {
        public int Id { get; set; } // Id (Primary key)
        public int Ordem { get; set; } // Ordem
        public string Nome { get; set; } // Nome

        // Reverse navigation
        public virtual ICollection<Grade> Grade { get; set; } // Grade.FK_Grade_Tamanho
        
        public Tamanho()
        {
            Grade = new List<Grade>();
        }
    }

}
// </auto-generated>