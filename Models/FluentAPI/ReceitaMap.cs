﻿using Calc.Models.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Calc.Models.FluentAPI
{
    public class ReceitaMap : EntityTypeConfiguration<Receita>
    {
        public ReceitaMap()
        {
            ToTable("TB_RECEITA");
            HasKey(receita => receita.ID).
                Property(receita => receita.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(receita => receita.Descricao).HasMaxLength(255).IsOptional().HasColumnType("Varchar");
            Property(receita => receita.Observacao).HasMaxLength(255).IsOptional().HasColumnType("Varchar");
            Property(receita => receita.DataRecebimento).IsRequired().HasColumnType("Datetime2");
            Property(receita => receita.TipoReceita).IsRequired();
            Property(receita => receita.FormaRecebimento).IsRequired();
            Property(receita => receita.Valor).IsRequired().HasColumnType("Float");
            Property(receita => receita.SaldoReceita).IsRequired().HasColumnType("Float");
            Property(receita => receita.NumeroParcelas).IsRequired();
            Property(receita => receita.PrimeiraDataVencimento).IsRequired().HasColumnType("Datetime2");
        }
    }
}