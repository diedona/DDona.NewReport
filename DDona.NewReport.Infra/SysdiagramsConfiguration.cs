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
    // sysdiagrams
    public class SysdiagramsConfiguration : EntityTypeConfiguration<Sysdiagrams>
    {
        public SysdiagramsConfiguration()
            : this("dbo")
        {
        }
 
        public SysdiagramsConfiguration(string schema)
        {
            ToTable(schema + ".sysdiagrams");
            HasKey(x => x.DiagramId);

            Property(x => x.Name).HasColumnName("name").IsRequired().HasColumnType("nvarchar").HasMaxLength(128);
            Property(x => x.PrincipalId).HasColumnName("principal_id").IsRequired().HasColumnType("int");
            Property(x => x.DiagramId).HasColumnName("diagram_id").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Version).HasColumnName("version").IsOptional().HasColumnType("int");
            Property(x => x.Definition).HasColumnName("definition").IsOptional().HasColumnType("varbinary");
        }
    }

}
// </auto-generated>
