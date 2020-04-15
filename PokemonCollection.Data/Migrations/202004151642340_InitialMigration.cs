namespace PokemonCollection.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pokedex",
                c => new
                    {
                        PokedexID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.PokedexID);
            
            CreateTable(
                "dbo.PokedexEntry",
                c => new
                    {
                        PokedexEntryID = c.Int(nullable: false, identity: true),
                        PokemonID = c.Int(nullable: false),
                        PokedexID = c.Int(nullable: false),
                        DateCaught = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PokedexEntryID)
                .ForeignKey("dbo.Pokedex", t => t.PokedexID, cascadeDelete: true)
                .ForeignKey("dbo.Pokemon", t => t.PokemonID, cascadeDelete: true)
                .Index(t => t.PokemonID)
                .Index(t => t.PokedexID);
            
            CreateTable(
                "dbo.Pokemon",
                c => new
                    {
                        PokemonID = c.Int(nullable: false, identity: true),
                        PokemonName = c.String(nullable: false),
                        RegionID = c.Int(nullable: false),
                        TypeID = c.Int(nullable: false),
                        IsShiny = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PokemonID)
                .ForeignKey("dbo.Region", t => t.RegionID, cascadeDelete: true)
                .ForeignKey("dbo.Type", t => t.TypeID, cascadeDelete: true)
                .Index(t => t.RegionID)
                .Index(t => t.TypeID);
            
            CreateTable(
                "dbo.Region",
                c => new
                    {
                        RegionID = c.Int(nullable: false, identity: true),
                        RegionName = c.String(nullable: false),
                        LocationInRegion = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RegionID);
            
            CreateTable(
                "dbo.Type",
                c => new
                    {
                        TypeID = c.Int(nullable: false, identity: true),
                        TypeName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TypeID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.PokedexEntry", "PokemonID", "dbo.Pokemon");
            DropForeignKey("dbo.Pokemon", "TypeID", "dbo.Type");
            DropForeignKey("dbo.Pokemon", "RegionID", "dbo.Region");
            DropForeignKey("dbo.PokedexEntry", "PokedexID", "dbo.Pokedex");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Pokemon", new[] { "TypeID" });
            DropIndex("dbo.Pokemon", new[] { "RegionID" });
            DropIndex("dbo.PokedexEntry", new[] { "PokedexID" });
            DropIndex("dbo.PokedexEntry", new[] { "PokemonID" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Type");
            DropTable("dbo.Region");
            DropTable("dbo.Pokemon");
            DropTable("dbo.PokedexEntry");
            DropTable("dbo.Pokedex");
        }
    }
}
