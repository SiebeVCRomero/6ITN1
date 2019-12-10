namespace Blog6ITN.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AanpassingModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("6ITN1.Gips", "Uitvoerders", c => c.String());
            AddColumn("6ITN1.Gips", "PersoonLaatsteAanpassing", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("6ITN1.Gips", "PersoonLaatsteAanpassing");
            DropColumn("6ITN1.Gips", "Uitvoerders");
        }
    }
}
