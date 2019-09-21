namespace DeliverEat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Domicilio : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Domicilios", "Ciudad", c => c.String());
            AddColumn("dbo.Domicilios", "Calle", c => c.String());
            AddColumn("dbo.Domicilios", "Numero", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Domicilios", "Numero");
            DropColumn("dbo.Domicilios", "Calle");
            DropColumn("dbo.Domicilios", "Ciudad");
        }
    }
}
