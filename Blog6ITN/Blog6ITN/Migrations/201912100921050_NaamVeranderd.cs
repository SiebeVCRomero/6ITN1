namespace Blog6ITN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NaamVeranderd : DbMigration
    {
        public override void Up()
        {
            AddColumn("6ITN1.Nieuws", "Titel", c => c.String());
            DropColumn("6ITN1.Nieuws", "Naam");
        }
        
        public override void Down()
        {
            AddColumn("6ITN1.Nieuws", "Naam", c => c.String());
            DropColumn("6ITN1.Nieuws", "Titel");
        }
    }
}
