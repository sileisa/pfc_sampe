namespace Sampe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sampe230320182212 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Maquinas", "NomeMaquina", c => c.String(nullable: false));
            AlterColumn("dbo.Cargoes", "NomeCargo", c => c.String(nullable: false));
            AlterColumn("dbo.Moldes", "NomeMolde", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Moldes", "NomeMolde", c => c.String());
            AlterColumn("dbo.Cargoes", "NomeCargo", c => c.String());
            AlterColumn("dbo.Maquinas", "NomeMaquina", c => c.String());
        }
    }
}
