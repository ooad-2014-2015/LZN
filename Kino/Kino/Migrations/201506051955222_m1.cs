namespace Kino.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Racun", "VrijemeNarudzbe", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Racun", "VrijemeNarudzbe", c => c.String());
        }
    }
}
