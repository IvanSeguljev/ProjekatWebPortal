namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class commitfetchingdbupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MaterijalPoTipus", "materijalId", "dbo.MaterijalModels");
            DropForeignKey("dbo.MaterijalPoTipus", "tipMaterijalaId", "dbo.TipMaterijalModels");
            DropForeignKey("dbo.MaterijalPoPredmetus", "materijalId", "dbo.MaterijalModels");
            DropForeignKey("dbo.MaterijalPoPredmetus", "predmetId", "dbo.PredmetModels");
            DropIndex("dbo.MaterijalPoTipus", new[] { "materijalId" });
            DropIndex("dbo.MaterijalPoTipus", new[] { "tipMaterijalaId" });
            DropIndex("dbo.MaterijalPoPredmetus", new[] { "materijalId" });
            DropIndex("dbo.MaterijalPoPredmetus", new[] { "predmetId" });
            AddColumn("dbo.MaterijalModels", "predmetId", c => c.Int(nullable: false));
            AddColumn("dbo.MaterijalModels", "tipMaterijalId", c => c.Int(nullable: false));
            CreateIndex("dbo.MaterijalModels", "predmetId");
            CreateIndex("dbo.MaterijalModels", "tipMaterijalId");
            AddForeignKey("dbo.MaterijalModels", "predmetId", "dbo.PredmetModels", "predmetId", cascadeDelete: true);
            AddForeignKey("dbo.MaterijalModels", "tipMaterijalId", "dbo.TipMaterijalModels", "tipMaterijalId", cascadeDelete: true);
            DropTable("dbo.MaterijalPoTipus");
            DropTable("dbo.MaterijalPoPredmetus");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MaterijalPoPredmetus",
                c => new
                    {
                        materijalId = c.Int(nullable: false),
                        predmetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.materijalId, t.predmetId });
            
            CreateTable(
                "dbo.MaterijalPoTipus",
                c => new
                    {
                        materijalId = c.Int(nullable: false),
                        tipMaterijalaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.materijalId, t.tipMaterijalaId });
            
            DropForeignKey("dbo.MaterijalModels", "tipMaterijalId", "dbo.TipMaterijalModels");
            DropForeignKey("dbo.MaterijalModels", "predmetId", "dbo.PredmetModels");
            DropIndex("dbo.MaterijalModels", new[] { "tipMaterijalId" });
            DropIndex("dbo.MaterijalModels", new[] { "predmetId" });
            DropColumn("dbo.MaterijalModels", "tipMaterijalId");
            DropColumn("dbo.MaterijalModels", "predmetId");
            CreateIndex("dbo.MaterijalPoPredmetus", "predmetId");
            CreateIndex("dbo.MaterijalPoPredmetus", "materijalId");
            CreateIndex("dbo.MaterijalPoTipus", "tipMaterijalaId");
            CreateIndex("dbo.MaterijalPoTipus", "materijalId");
            AddForeignKey("dbo.MaterijalPoPredmetus", "predmetId", "dbo.PredmetModels", "predmetId", cascadeDelete: true);
            AddForeignKey("dbo.MaterijalPoPredmetus", "materijalId", "dbo.MaterijalModels", "materijalId", cascadeDelete: true);
            AddForeignKey("dbo.MaterijalPoTipus", "tipMaterijalaId", "dbo.TipMaterijalModels", "tipMaterijalId", cascadeDelete: true);
            AddForeignKey("dbo.MaterijalPoTipus", "materijalId", "dbo.MaterijalModels", "materijalId", cascadeDelete: true);
        }
    }
}
