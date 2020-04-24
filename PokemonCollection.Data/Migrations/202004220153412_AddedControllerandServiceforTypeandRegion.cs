namespace PokemonCollection.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedControllerandServiceforTypeandRegion : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Region", "RegionName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Region", "RegionName", c => c.Int(nullable: false));
        }
    }
}
