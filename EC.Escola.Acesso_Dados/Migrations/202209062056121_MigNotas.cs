namespace EC.Escola.Acesso_Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigNotas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.registroNotas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        aluno = c.Int(nullable: false),
                        disciplina = c.Int(nullable: false),
                        nota1 = c.Decimal(precision: 18, scale: 2),
                        nota2 = c.Decimal(precision: 18, scale: 2),
                        nota3 = c.Decimal(precision: 18, scale: 2),
                        nota4 = c.Decimal(precision: 18, scale: 2),
                        media = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.aluno", t => t.aluno, cascadeDelete: true)
                .ForeignKey("dbo.disciplina", t => t.disciplina, cascadeDelete: true)
                .Index(t => t.aluno)
                .Index(t => t.disciplina);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.registroNotas", "disciplina", "dbo.disciplina");
            DropForeignKey("dbo.registroNotas", "aluno", "dbo.aluno");
            DropIndex("dbo.registroNotas", new[] { "disciplina" });
            DropIndex("dbo.registroNotas", new[] { "aluno" });
            DropTable("dbo.registroNotas");
        }
    }
}
