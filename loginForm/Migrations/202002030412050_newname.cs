namespace loginForm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "name");
        }
    }
}
