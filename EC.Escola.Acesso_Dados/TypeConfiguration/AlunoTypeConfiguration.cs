using EC.Comum.Entity;
using EC.Escola.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.Escola.Acesso_Dados.TypeConfiguration
{
    class AlunoTypeConfiguration : ECEntityAbstractConfig<aluno>
    {
        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.id)
                .IsRequired()
                .HasColumnName("id");

            Property(p => p.cpf)
                .IsRequired()
                .HasColumnName("cpf");

            Property(p => p.nome)
                .IsRequired()
                .HasColumnName("nome");

            Property(p => p.cep)
                .IsRequired()
                .HasColumnName("cep");

            Property(p => p.numero)
                .IsRequired()
                .HasColumnName("numero");

            Property(p => p.complemento)
                .IsOptional()
                .HasColumnName("complemento");
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
            ToTable("aluno");
        }
    }
}
