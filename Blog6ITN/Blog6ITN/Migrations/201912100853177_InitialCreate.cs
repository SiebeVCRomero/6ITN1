namespace Blog6ITN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "6ITN1.Gips",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                        Intro = c.String(),
                        LaatseAanpassing = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "6ITN1.Nieuws",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                        Inhoud = c.String(),
                        PublicatieDatum = c.DateTime(nullable: false),
                        Auteur = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("6ITN1.Nieuws");
            DropTable("6ITN1.Gips");
        }
    }
}
