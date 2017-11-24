namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class namenaMaterijala : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NamenaMaterijalaModels",
                c => new
                    {
                        namenaMaterijalaId = c.Int(nullable: false, identity: true),
                        namenaMaterijalaNaziv = c.String(),
                    })
                .PrimaryKey(t => t.namenaMaterijalaId);
            
            AddColumn("dbo.MaterijalModels", "namenaMaterijalaId", c => c.Int(nullable: false));
            CreateIndex("dbo.MaterijalModels", "namenaMaterijalaId");
            AddForeignKey("dbo.MaterijalModels", "namenaMaterijalaId", "dbo.NamenaMaterijalaModels", "namenaMaterijalaId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MaterijalModels", "namenaMaterijalaId", "dbo.NamenaMaterijalaModels");
            DropIndex("dbo.MaterijalModels", new[] { "namenaMaterijalaId" });
            DropColumn("dbo.MaterijalModels", "namenaMaterijalaId");
            DropTable("dbo.NamenaMaterijalaModels");
        }
    }
}
