namespace codeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.ClienteId);
            
            CreateTable(
                "dbo.LineaPedidoes",
                c => new
                    {
                        LineaPedidoId = c.Int(nullable: false, identity: true),
                        PedidoId = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                        Unidades = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LineaPedidoId);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        ProductoId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        Precio = c.Int(nullable: false),
                        LineaPedido_LineaPedidoId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductoId)
                .ForeignKey("dbo.LineaPedidoes", t => t.LineaPedido_LineaPedidoId)
                .Index(t => t.LineaPedido_LineaPedidoId);
            
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        PedidoId = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PedidoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productoes", "LineaPedido_LineaPedidoId", "dbo.LineaPedidoes");
            DropIndex("dbo.Productoes", new[] { "LineaPedido_LineaPedidoId" });
            DropTable("dbo.Pedidoes");
            DropTable("dbo.Productoes");
            DropTable("dbo.LineaPedidoes");
            DropTable("dbo.Clientes");
        }
    }
}
