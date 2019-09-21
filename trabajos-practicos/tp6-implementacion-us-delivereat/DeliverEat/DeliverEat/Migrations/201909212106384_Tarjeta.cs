namespace DeliverEat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tarjeta : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tarjetas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Descripcion = c.Boolean(nullable: false),
                        Numero = c.String(),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Vencimiento = c.String(),
                        CvC = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Pagoes", "Efectivo", c => c.Boolean(nullable: false));
            AddColumn("dbo.Pagoes", "Monto", c => c.String());
            AddColumn("dbo.Pagoes", "Tarjeta_Id", c => c.Int());
            CreateIndex("dbo.Pagoes", "Tarjeta_Id");
            AddForeignKey("dbo.Pagoes", "Tarjeta_Id", "dbo.Tarjetas", "Id");
            DropColumn("dbo.Pagoes", "Descripcion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pagoes", "Descripcion", c => c.String());
            DropForeignKey("dbo.Pagoes", "Tarjeta_Id", "dbo.Tarjetas");
            DropIndex("dbo.Pagoes", new[] { "Tarjeta_Id" });
            DropColumn("dbo.Pagoes", "Tarjeta_Id");
            DropColumn("dbo.Pagoes", "Monto");
            DropColumn("dbo.Pagoes", "Efectivo");
            DropTable("dbo.Tarjetas");
        }
    }
}
