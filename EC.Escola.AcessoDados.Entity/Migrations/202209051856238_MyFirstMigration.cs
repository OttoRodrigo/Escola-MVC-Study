namespace EC.Escola.AcessoDados.Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyFirstMigration : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.aluno", newName: "estudante");
            DropPrimaryKey("dbo.estudante");
            AddColumn("dbo.estudante", "id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.estudante", "cep", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.estudante", "id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.estudante");
            AlterColumn("dbo.estudante", "cep", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.estudante", "id");
            AddPrimaryKey("dbo.estudante", "cep");
            RenameTable(name: "dbo.estudante", newName: "aluno");
        }
    }
}
