namespace Sampe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sampe240320181034 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Usuarios", "Login", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuarios", "Login", c => c.Int(nullable: false));
        }
    }
}
