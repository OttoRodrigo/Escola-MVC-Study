using EC.Escola.Acesso_Dados.TypeConfiguration;
using EC.Escola.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.Escola.Acesso_Dados.Context
{
    public class EscolaDbContext : DbContext
    {
        public DbSet<aluno> estudantes { get; set; }
        public DbSet<disciplina> disciplinas { get; set; }
        public DbSet<registroNotas> registroNotas { get; set; }

        public EscolaDbContext()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AlunoTypeConfiguration());
            modelBuilder.Configurations.Add(new DisciplinaTypeConfiguration());
            modelBuilder.Configurations.Add(new RegistroNotasTypeConfiguration());
        }
    }
}
