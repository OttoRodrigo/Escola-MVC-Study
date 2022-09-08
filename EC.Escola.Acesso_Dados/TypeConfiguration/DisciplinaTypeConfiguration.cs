using EC.Comum.Entity;
using EC.Escola.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.Escola.Acesso_Dados.TypeConfiguration
{
    class DisciplinaTypeConfiguration : ECEntityAbstractConfig<disciplina>
    {
        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.id)
                .IsRequired()
                .HasColumnName("id");

            Property(p => p.nome)
                .IsRequired()
                .HasColumnName("nome");
        }

        protected override void ConfigurarChavePrimaria()
        {
            HasKey(p => p.id);
        }

        protected override void ConfigurarChavesEstrangeiras()
        {

        }

        protected override void ConfigurarNomeTabela()
        {
            ToTable("disciplina");
        }
    }
}
