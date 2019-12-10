namespace Blog6ITN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserAanpassing : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("6ITN1.UserRols", "User_Id", "6ITN1.Users");
            DropForeignKey("6ITN1.UserRols", "Rol_RolId", "6ITN1.Rols");
            DropIndex("6ITN1.UserRols", new[] { "User_Id" });
            DropIndex("6ITN1.UserRols", new[] { "Rol_RolId" });
            AddColumn("6ITN1.Users", "Rol", c => c.String());
            DropTable("6ITN1.Rols");
            DropTable("6ITN1.UserRols");
        }
        
        public override void Down()
        {
            CreateTable(
                "6ITN1.UserRols",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Rol_RolId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Rol_RolId });
            
            CreateTable(
                "6ITN1.Rols",
                c => new
                    {
                        RolId = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                    })
                .PrimaryKey(t => t.RolId);
            
            DropColumn("6ITN1.Users", "Rol");
            CreateIndex("6ITN1.UserRols", "Rol_RolId");
            CreateIndex("6ITN1.UserRols", "User_Id");
            AddForeignKey("6ITN1.UserRols", "Rol_RolId", "6ITN1.Rols", "RolId", cascadeDelete: true);
            AddForeignKey("6ITN1.UserRols", "User_Id", "6ITN1.Users", "Id", cascadeDelete: true);
        }
    }
}
