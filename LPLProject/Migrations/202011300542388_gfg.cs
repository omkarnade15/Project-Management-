namespace LPLProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gfg : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "first_Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Employees", "last_Name", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Employees", "Username", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Username", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "last_Name", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "first_Name", c => c.String(nullable: false));
        }
    }
}
