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
    [GeneratedCodeAttribute("EF.Reverse.POCO.Generator", "2.16.1.0")]
    public class FakeNewReportDB : INewReportDB
    {
        public DbSet<Cor> Cor { get; set; }
        public DbSet<Grade> Grade { get; set; }
        public DbSet<Loja> Loja { get; set; }
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Sysdiagrams> Sysdiagrams { get; set; }
        public DbSet<Tamanho> Tamanho { get; set; }

        public FakeNewReportDB()
        {
            Cor = new FakeDbSet<Cor>();
            Grade = new FakeDbSet<Grade>();
            Loja = new FakeDbSet<Loja>();
            Marca = new FakeDbSet<Marca>();
            Produto = new FakeDbSet<Produto>();
            Sysdiagrams = new FakeDbSet<Sysdiagrams>();
            Tamanho = new FakeDbSet<Tamanho>();
        }
        
        public int SaveChangesCount { get; private set; } 
        public int SaveChanges()
        {
            ++SaveChangesCount;
            return 1;
        }

        public System.Threading.Tasks.Task<int> SaveChangesAsync()
        {
            ++SaveChangesCount;
            return System.Threading.Tasks.Task<int>.Factory.StartNew(() => 1);
        }

        public System.Threading.Tasks.Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            ++SaveChangesCount;
            return System.Threading.Tasks.Task<int>.Factory.StartNew(() => 1, cancellationToken);
        }

        protected virtual void Dispose(bool disposing)
        {
        }
        
        public void Dispose()
        {
            Dispose(true);
        }
        
        // Stored Procedures
    }
}
// </auto-generated>