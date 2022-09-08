using EC.Escola.AcessoDados.Entity.TypeConfiguration;
using EC.Escola.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.Escola.AcessoDados.Entity.Context
{
    public class EscolaDbContext : DbContext
    {
        public DbSet<aluno> estudantes { get; set; }

        public EscolaDbContext()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AlunoTypeConfiguration());
        }
    }
}
