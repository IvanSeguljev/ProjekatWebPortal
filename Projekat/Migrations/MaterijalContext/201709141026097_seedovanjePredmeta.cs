namespace Projekat.Migrations.MaterijalContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedovanjePredmeta : DbMigration
    {
        public override void Up()
        {
            Sql(@"SET IDENTITY_INSERT [dbo].[PredmetModels] ON
INSERT INTO [dbo].[PredmetModels] ([predmetId], [predmetNaziv], [predmetOpis]) VALUES (1, N'Predmet1', N'opis')
INSERT INTO [dbo].[PredmetModels] ([predmetId], [predmetNaziv], [predmetOpis]) VALUES (2, N'Predmet1', N'Predmet')
INSERT INTO [dbo].[PredmetModels] ([predmetId], [predmetNaziv], [predmetOpis]) VALUES (3, N'Predmet2', N'Predmet2')
INSERT INTO [dbo].[PredmetModels] ([predmetId], [predmetNaziv], [predmetOpis]) VALUES (4, N'Predmet3', N'Predmet3')
INSERT INTO [dbo].[PredmetModels] ([predmetId], [predmetNaziv], [predmetOpis]) VALUES (5, N'Programiranje', N'Programiranje u c jeziku')
INSERT INTO [dbo].[PredmetModels] ([predmetId], [predmetNaziv], [predmetOpis]) VALUES (6, N'Baze podataka', N' Transact sql')
INSERT INTO [dbo].[PredmetModels] ([predmetId], [predmetNaziv], [predmetOpis]) VALUES (7, N'Matematika', N'...Matematika?')
SET IDENTITY_INSERT [dbo].[PredmetModels] OFF
");
            Sql(@"
INSERT INTO [dbo].[PremetPoSmerus] ([predmetId], [smerId]) VALUES (5, 3)
INSERT INTO [dbo].[PremetPoSmerus] ([predmetId], [smerId]) VALUES (6, 3)
INSERT INTO [dbo].[PremetPoSmerus] ([predmetId], [smerId]) VALUES (7, 3)
INSERT INTO [dbo].[PremetPoSmerus] ([predmetId], [smerId]) VALUES (2, 4)
INSERT INTO [dbo].[PremetPoSmerus] ([predmetId], [smerId]) VALUES (3, 4)
INSERT INTO [dbo].[PremetPoSmerus] ([predmetId], [smerId]) VALUES (4, 4)

");
        }
        
        public override void Down()
        {
        }
    }
}
