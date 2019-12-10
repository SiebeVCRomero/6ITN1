namespace Blog6ITN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UsersEnRollen : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "6ITN1.Rols",
                c => new
                    {
                        RolId = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                    })
                .PrimaryKey(t => t.RolId);
            
            CreateTable(
                "6ITN1.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Voornaam = c.String(),
                        Familienaam = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "6ITN1.UserRols",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Rol_RolId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Rol_RolId })
                .ForeignKey("6ITN1.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("6ITN1.Rols", t => t.Rol_RolId, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Rol_RolId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("6ITN1.UserRols", "Rol_RolId", "6ITN1.Rols");
            DropForeignKey("6ITN1.UserRols", "User_Id", "6ITN1.Users");
            DropIndex("6ITN1.UserRols", new[] { "Rol_RolId" });
            DropIndex("6ITN1.UserRols", new[] { "User_Id" });
            DropTable("6ITN1.UserRols");
            DropTable("6ITN1.Users");
            DropTable("6ITN1.Rols");
        }
    }
}
