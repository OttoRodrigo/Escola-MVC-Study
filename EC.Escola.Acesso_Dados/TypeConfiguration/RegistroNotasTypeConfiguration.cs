using EC.Comum.Entity;
using EC.Escola.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.Escola.Acesso_Dados.TypeConfiguration
{
    class RegistroNotasTypeConfiguration : ECEntityAbstractConfig<registroNotas>
    {
        protected override void ConfigurarCamposTabela()
        {
            Property(p => p.id)
                .IsRequired()
                .HasColumnName("id");

            Property(p => p.idAluno)
                .IsRequired()
                .HasColumnName("aluno");

            Property(p => p.idDisciplina)
                .IsRequired()
                .HasColumnName("disciplina");

            Property(p => p.nota1)
                .IsOptional()
                .HasColumnName("nota1");

            Property(p => p.nota2)
                .IsOptional()
                .HasColumnName("nota2");

            Property(p => p.nota3)
                .IsOptional()
                .HasColumnName("nota3");

            Property(p => p.nota4)
                .IsOptional()
                .HasColumnName("nota4");

            Property(p => p.media)
                .IsOptional()
                .HasColumnName("media");
        }

        protected override void ConfigurarChavePrimaria()
        {
            HasKey(p => p.id);
        }

        protected override void ConfigurarChavesEstrangeiras()
        {
            HasRequired(p => p.aluno)
                .WithMany(p => p.registroNotas)
                .HasForeignKey(fk => fk.idAluno);

            HasRequired(p => p.disciplina)
                .WithMany(p => p.registroNotas)
                .HasForeignKey(fk => fk.idDisciplina);
        }

        protected override void ConfigurarNomeTabela()
        {
            ToTable("registroNotas");
        }
    }
}
