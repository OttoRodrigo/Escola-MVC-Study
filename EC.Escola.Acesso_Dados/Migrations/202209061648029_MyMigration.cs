namespace EC.Escola.Acesso_Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.aluno",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        cpf = c.Long(nullable: false),
                        nome = c.String(nullable: false),
                        cep = c.Int(nullable: false),
                        numero = c.Int(nullable: false),
                        complemento = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.aluno");
        }
    }
}
