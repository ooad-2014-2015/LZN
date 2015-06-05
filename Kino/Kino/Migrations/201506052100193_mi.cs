namespace Kino.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mi : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Sala", newName: "Sale");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Sale", newName: "Sala");
        }
    }
}
