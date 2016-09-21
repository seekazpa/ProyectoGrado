namespace NutriVaSe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Menu : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PadreId = c.Int(nullable: false),
                        Nombre = c.String(nullable: false),
                        Descripcion = c.String(nullable: false),
                        Accion = c.String(),
                        Controlador = c.String(),
                        Estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Menus");
        }
    }
}
