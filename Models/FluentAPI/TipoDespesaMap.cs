using Calc.Models.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Calc.Models.FluentAPI
{
    public class TipoDespesaMap : EntityTypeConfiguration<TipoDespesa>
    {
        public TipoDespesaMap()
        {
            ToTable("TB_TIPO_DESPESA");
            HasKey(tp => tp.Id).
                Property(tp => tp.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(tp => tp.Nome).HasMaxLength(255).IsRequired().HasColumnType("Varchar");
            Property(tp => tp.Situacao).IsRequired().HasColumnType("bit");
        }
    }
}