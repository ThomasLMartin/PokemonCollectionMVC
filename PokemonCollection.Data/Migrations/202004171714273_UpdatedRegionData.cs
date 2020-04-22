namespace PokemonCollection.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedRegionData : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Region", "RegionName", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Region", "RegionName", c => c.String(nullable: false));
        }
    }
}
