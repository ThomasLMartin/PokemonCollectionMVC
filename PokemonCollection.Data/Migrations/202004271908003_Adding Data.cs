namespace PokemonCollection.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingData : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Region", "RegionName", c => c.String(nullable: false));
            AlterColumn("dbo.Region", "LocationInRegion", c => c.String(nullable: false));
            AlterColumn("dbo.Type", "TypeName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Type", "TypeName", c => c.String());
            AlterColumn("dbo.Region", "LocationInRegion", c => c.String());
            AlterColumn("dbo.Region", "RegionName", c => c.String());
        }
    }
}
