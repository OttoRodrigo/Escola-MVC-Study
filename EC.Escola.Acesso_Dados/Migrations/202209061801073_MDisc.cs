namespace EC.Escola.Acesso_Dados.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MDisc : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.disciplina",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.disciplina");
        }
    }
}
