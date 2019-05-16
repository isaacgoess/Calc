using Calc.Models.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Calc.Models.FluentAPI
{
    public class ListaReceitaMap : EntityTypeConfiguration<ListaReceita>
    {
        public ListaReceitaMap()
        {
            ToTable("TB_LISTA_RECEITA");
            HasKey(tipo => tipo.Id).
                    Property(receita => receita.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(tipo => tipo.Nome).HasMaxLength(255).IsRequired().HasColumnType("Varchar");
        }
    }

}