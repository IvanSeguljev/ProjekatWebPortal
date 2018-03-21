namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ident : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserRole", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserRole");
        }
    }
}
