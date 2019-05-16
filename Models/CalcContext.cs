using System.Data.Entity;
using Calc.Models.FluentAPI;


namespace Calc.Models
{
    public class CalcContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public CalcContext() : base("name=CalcContext")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ClienteMap());
            modelBuilder.Configurations.Add(new TipoDespesaMap());
            modelBuilder.Configurations.Add(new DespesaMap());
            modelBuilder.Configurations.Add(new ListaReceitaMap());
            modelBuilder.Configurations.Add(new ReceitaMap());


            base.OnModelCreating(modelBuilder);
        }


        public System.Data.Entity.DbSet<Calc.Models.Classes.Cliente> Clientes { get; set; }
        public System.Data.Entity.DbSet<Calc.Models.Classes.Despesa> Despesas { get; set; }
        public System.Data.Entity.DbSet<Calc.Models.Classes.TipoDespesa> TipoDespesas { get; set; }
        public System.Data.Entity.DbSet<Calc.Models.Classes.Receita> Receitas { get; set; }
        public System.Data.Entity.DbSet<Calc.Models.Classes.ListaReceita> ListaReceitas { get; set; }
    }
}
