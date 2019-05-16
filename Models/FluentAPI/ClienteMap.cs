using Calc.Models.Classes;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;


namespace Calc.Models.FluentAPI
{
    public class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        public ClienteMap()
        {
            ToTable("TB_CLIENTE");

            HasKey(c => c.Id)
                .Property(c => c.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(c => c.Nome).HasMaxLength(255).IsRequired().HasColumnType("Varchar");
            Property(c => c.DataAniversario).IsRequired().HasColumnType("DateTime");
            Property(c => c.Email).IsRequired().HasColumnType("Varchar");
            Ignore(c => c.ConfirmarEmail);

        }
    }
}