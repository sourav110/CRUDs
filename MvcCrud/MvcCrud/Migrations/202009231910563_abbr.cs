namespace MvcCrud.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abbr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Departments", "Abbr", c => c.String(nullable: false));
            AlterColumn("dbo.Departments", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Departments", "Name", c => c.String());
            DropColumn("dbo.Departments", "Abbr");
        }
    }
}
