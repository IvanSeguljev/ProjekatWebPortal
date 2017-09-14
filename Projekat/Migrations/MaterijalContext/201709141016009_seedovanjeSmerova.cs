namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedovanjeSmerova : DbMigration
    {
        public override void Up()
        {
            Sql(@"
SET IDENTITY_INSERT [dbo].[SmerModels] ON
INSERT INTO [dbo].[SmerModels] ([smerId], [smerNaziv], [smerOpis]) VALUES (3, N'Elektrotehničar informacionih tehnologija', N'ITHS-ov programerski smer')
INSERT INTO [dbo].[SmerModels] ([smerId], [smerNaziv], [smerOpis]) VALUES (4, N'Elektrotehničar multimedija', N'ITHS-ov multimedijski smer')
SET IDENTITY_INSERT [dbo].[SmerModels] OFF
");
        }
        
        public override void Down()
        {
        }
    }
}
