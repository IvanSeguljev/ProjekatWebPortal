namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dodavanjeTipaMaterijala : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TipMaterijalModels",
                c => new
                    {
                        tipMaterijalId = c.Int(nullable: false, identity: true),
                        nazivTipMaterijal = c.String(),
                    })
                .PrimaryKey(t => t.tipMaterijalId);
            
            AddColumn("dbo.MaterijalModels", "tipMaterijalId", c => c.Int(nullable: false));
            CreateIndex("dbo.MaterijalModels", "tipMaterijalId");
            AddForeignKey("dbo.MaterijalModels", "tipMaterijalId", "dbo.TipMaterijalModels", "tipMaterijalId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MaterijalModels", "tipMaterijalId", "dbo.TipMaterijalModels");
            DropIndex("dbo.MaterijalModels", new[] { "tipMaterijalId" });
            DropColumn("dbo.MaterijalModels", "tipMaterijalId");
            DropTable("dbo.TipMaterijalModels");
        }
    }
}
