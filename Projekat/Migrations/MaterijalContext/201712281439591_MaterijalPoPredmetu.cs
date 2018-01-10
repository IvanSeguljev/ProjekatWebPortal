namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MaterijalPoPredmetu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MaterijalPoPredmetus",
                c => new
                    {
                        materijalId = c.Int(nullable: false),
                        predmetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.materijalId, t.predmetId })
                .ForeignKey("dbo.MaterijalModels", t => t.materijalId, cascadeDelete: true)
                .ForeignKey("dbo.PredmetModels", t => t.predmetId, cascadeDelete: true)
                .Index(t => t.materijalId)
                .Index(t => t.predmetId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MaterijalPoPredmetus", "predmetId", "dbo.PredmetModels");
            DropForeignKey("dbo.MaterijalPoPredmetus", "materijalId", "dbo.MaterijalModels");
            DropIndex("dbo.MaterijalPoPredmetus", new[] { "predmetId" });
            DropIndex("dbo.MaterijalPoPredmetus", new[] { "materijalId" });
            DropTable("dbo.MaterijalPoPredmetus");
        }
    }
}
