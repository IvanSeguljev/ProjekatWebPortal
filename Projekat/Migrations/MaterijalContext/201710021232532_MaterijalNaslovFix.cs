namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaterijalNaslovFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MaterijalModels", "materijalNaslov", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MaterijalModels", "materijalNaslov");
        }
    }
}
