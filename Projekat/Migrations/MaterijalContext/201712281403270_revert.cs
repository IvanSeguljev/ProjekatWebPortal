namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class revert : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PredmetPoNamenis", "namenaId", "dbo.NamenaMaterijalaModels");
            DropForeignKey("dbo.PredmetPoNamenis", "predmetId", "dbo.PredmetModels");
            DropForeignKey("dbo.TipPoNamenis", "namenaId", "dbo.NamenaMaterijalaModels");
            DropForeignKey("dbo.TipPoNamenis", "tipId", "dbo.TipMaterijalModels");
            DropIndex("dbo.PredmetPoNamenis", new[] { "predmetId" });
            DropIndex("dbo.PredmetPoNamenis", new[] { "namenaId" });
            DropIndex("dbo.TipPoNamenis", new[] { "tipId" });
            DropIndex("dbo.TipPoNamenis", new[] { "namenaId" });
            AddColumn("dbo.MaterijalModels", "predmetId", c => c.Int(nullable: false));
            AddColumn("dbo.MaterijalModels", "tipMaterijalId", c => c.Int(nullable: false));
            CreateIndex("dbo.MaterijalModels", "predmetId");
            CreateIndex("dbo.MaterijalModels", "tipMaterijalId");
            AddForeignKey("dbo.MaterijalModels", "predmetId", "dbo.PredmetModels", "predmetId", cascadeDelete: true);
            AddForeignKey("dbo.MaterijalModels", "tipMaterijalId", "dbo.TipMaterijalModels", "tipMaterijalId", cascadeDelete: true);
            DropTable("dbo.PredmetPoNamenis");
            DropTable("dbo.TipPoNamenis");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TipPoNamenis",
                c => new
                    {
                        tipId = c.Int(nullable: false),
                        namenaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.tipId, t.namenaId });
            
            CreateTable(
                "dbo.PredmetPoNamenis",
                c => new
                    {
                        predmetId = c.Int(nullable: false),
                        namenaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.predmetId, t.namenaId });
            
            DropForeignKey("dbo.MaterijalModels", "tipMaterijalId", "dbo.TipMaterijalModels");
            DropForeignKey("dbo.MaterijalModels", "predmetId", "dbo.PredmetModels");
            DropIndex("dbo.MaterijalModels", new[] { "tipMaterijalId" });
            DropIndex("dbo.MaterijalModels", new[] { "predmetId" });
            DropColumn("dbo.MaterijalModels", "tipMaterijalId");
            DropColumn("dbo.MaterijalModels", "predmetId");
            CreateIndex("dbo.TipPoNamenis", "namenaId");
            CreateIndex("dbo.TipPoNamenis", "tipId");
            CreateIndex("dbo.PredmetPoNamenis", "namenaId");
            CreateIndex("dbo.PredmetPoNamenis", "predmetId");
            AddForeignKey("dbo.TipPoNamenis", "tipId", "dbo.TipMaterijalModels", "tipMaterijalId", cascadeDelete: true);
            AddForeignKey("dbo.TipPoNamenis", "namenaId", "dbo.NamenaMaterijalaModels", "namenaMaterijalaId", cascadeDelete: true);
            AddForeignKey("dbo.PredmetPoNamenis", "predmetId", "dbo.PredmetModels", "predmetId", cascadeDelete: true);
            AddForeignKey("dbo.PredmetPoNamenis", "namenaId", "dbo.NamenaMaterijalaModels", "namenaMaterijalaId", cascadeDelete: true);
        }
    }
}
