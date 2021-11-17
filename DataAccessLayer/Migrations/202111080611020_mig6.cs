namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig6 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Contacts", "Message", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "Message", c => c.String(maxLength: 50));
            AlterColumn("dbo.Contacts", "Name", c => c.String());
        }
    }
}
