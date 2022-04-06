namespace LPLProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gfgf : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Password", c => c.String());
        }
    }
}
