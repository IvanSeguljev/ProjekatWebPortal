namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodajSmerPredmetPredmetPoSmeru : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PremetPoSmerus",
                c => new
                    {
                        predmetId = c.Int(nullable: false),
                        smerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.predmetId, t.smerId })
                .ForeignKey("dbo.PredmetModels", t => t.predmetId, cascadeDelete: true)
                .ForeignKey("dbo.SmerModels", t => t.smerId, cascadeDelete: true)
                .Index(t => t.predmetId)
                .Index(t => t.smerId);
            
            CreateTable(
                "dbo.SmerModels",
                c => new
                    {
                        smerId = c.Int(nullable: false, identity: true),
                        smerNaziv = c.String(),
                        smerOpis = c.String(),
                    })
                .PrimaryKey(t => t.smerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PremetPoSmerus", "smerId", "dbo.SmerModels");
            DropForeignKey("dbo.PremetPoSmerus", "predmetId", "dbo.PredmetModels");
            DropIndex("dbo.PremetPoSmerus", new[] { "smerId" });
            DropIndex("dbo.PremetPoSmerus", new[] { "predmetId" });
            DropTable("dbo.SmerModels");
            DropTable("dbo.PremetPoSmerus");
        }
    }
}
