namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reseedPKValues : DbMigration
    {
        public override void Up()
        {
            Sql("DBCC CHECKIDENT('MaterijalModels', RESEED, 0)");
        }
        
        public override void Down()
        {
        }
    }
}
