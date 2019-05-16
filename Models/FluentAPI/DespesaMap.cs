using Calc.Models.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Calc.Models.FluentAPI
{
    public class DespesaMap : EntityTypeConfiguration<Despesa>
    {
        public DespesaMap()
        {
            ToTable("TB_DESPESA");
            HasKey(d => d.Id).
                Property(d => d.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired<TipoDespesa>(d => d.TipoDespesa).WithMany(tp => tp.ListaDespesa).HasForeignKey(tp => tp.TipoDespesaId);

            Property(d => d.Descricao).HasMaxLength(255).IsRequired().HasColumnType("Varchar");
            Property(despesa => despesa.Caracteristica).IsRequired().HasColumnType("int");
            Property(despesa => despesa.Situacao).IsRequired().HasColumnType("bit");
            Property(despesa => despesa.SaldoDespesa).IsRequired().HasColumnType("float");

        }
    }
}