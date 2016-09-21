namespace NutriVaSe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Paciente : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pacientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Apellido = c.String(nullable: false),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Sexo = c.String(nullable: false),
                        Ocupacion = c.String(),
                        Telefono = c.String(),
                        Email = c.String(),
                        Direccion = c.String(),
                        GrupoSanguineo = c.String(),
                        Alergias = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pacientes");
        }
    }
}
