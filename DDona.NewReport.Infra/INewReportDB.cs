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
    public interface INewReportDB : IDisposable
    {
        DbSet<Cor> Cor { get; set; } // Cor
        DbSet<Grade> Grade { get; set; } // Grade
        DbSet<Loja> Loja { get; set; } // Loja
        DbSet<Marca> Marca { get; set; } // Marca
        DbSet<Produto> Produto { get; set; } // Produto
        DbSet<Sysdiagrams> Sysdiagrams { get; set; } // sysdiagrams
        DbSet<Tamanho> Tamanho { get; set; } // Tamanho

        int SaveChanges();
        System.Threading.Tasks.Task<int> SaveChangesAsync();
        System.Threading.Tasks.Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
        // Stored Procedures
    }

}
// </auto-generated>
