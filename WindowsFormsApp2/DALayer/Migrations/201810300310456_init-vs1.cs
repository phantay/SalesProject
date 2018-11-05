namespace DALayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initvs1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "Email", c => c.String());
            AddColumn("dbo.Employees", "Gender", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Gender");
            DropColumn("dbo.Employees", "Email");
        }
    }
}
