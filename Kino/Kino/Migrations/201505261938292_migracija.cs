namespace Kino.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracija : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Film", "KorisnikId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Film", "KorisnikId");
        }
    }
}
