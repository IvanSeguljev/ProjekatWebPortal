namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class materijalpotipu : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MaterijalModels", "predmetId", "dbo.PredmetModels");
            DropForeignKey("dbo.MaterijalModels", "tipMaterijalId", "dbo.TipMaterijalModels");
            DropIndex("dbo.MaterijalModels", new[] { "predmetId" });
            DropIndex("dbo.MaterijalModels", new[] { "tipMaterijalId" });
            CreateTable(
                "dbo.MaterijalPoTipus",
                c => new
                    {
                        materijalId = c.Int(nullable: false),
                        tipMaterijalaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.materijalId, t.tipMaterijalaId })
                .ForeignKey("dbo.MaterijalModels", t => t.materijalId, cascadeDelete: true)
                .ForeignKey("dbo.TipMaterijalModels", t => t.tipMaterijalaId, cascadeDelete: true)
                .Index(t => t.materijalId)
                .Index(t => t.tipMaterijalaId);
            
            DropColumn("dbo.MaterijalModels", "predmetId");
            DropColumn("dbo.MaterijalModels", "tipMaterijalId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MaterijalModels", "tipMaterijalId", c => c.Int(nullable: false));
            AddColumn("dbo.MaterijalModels", "predmetId", c => c.Int(nullable: false));
            DropForeignKey("dbo.MaterijalPoTipus", "tipMaterijalaId", "dbo.TipMaterijalModels");
            DropForeignKey("dbo.MaterijalPoTipus", "materijalId", "dbo.MaterijalModels");
            DropIndex("dbo.MaterijalPoTipus", new[] { "tipMaterijalaId" });
            DropIndex("dbo.MaterijalPoTipus", new[] { "materijalId" });
            DropTable("dbo.MaterijalPoTipus");
            CreateIndex("dbo.MaterijalModels", "tipMaterijalId");
            CreateIndex("dbo.MaterijalModels", "predmetId");
            AddForeignKey("dbo.MaterijalModels", "tipMaterijalId", "dbo.TipMaterijalModels", "tipMaterijalId", cascadeDelete: true);
            AddForeignKey("dbo.MaterijalModels", "predmetId", "dbo.PredmetModels", "predmetId", cascadeDelete: true);
        }
    }
}
