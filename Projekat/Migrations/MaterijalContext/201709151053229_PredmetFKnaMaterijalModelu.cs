namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PredmetFKnaMaterijalModelu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MaterijalModels", "predmetId", c => c.Int(nullable: false));
            CreateIndex("dbo.MaterijalModels", "predmetId");
            AddForeignKey("dbo.MaterijalModels", "predmetId", "dbo.PredmetModels", "predmetId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MaterijalModels", "predmetId", "dbo.PredmetModels");
            DropIndex("dbo.MaterijalModels", new[] { "predmetId" });
            DropColumn("dbo.MaterijalModels", "predmetId");
        }
    }
}
