namespace LPLProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ok : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "first_Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "first_Name", c => c.String(nullable: false, maxLength: 20));
        }
    }
}
