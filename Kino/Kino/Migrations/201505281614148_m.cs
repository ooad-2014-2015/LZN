namespace Kino.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Film", "Glumci", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Film", "Glumci");
        }
    }
}
