namespace NutriVaSe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Antropometrico : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Antropometricoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PacienteId = c.Int(nullable: false),
                        PesoActual = c.Double(nullable: false),
                        Talla = c.Double(nullable: false),
                        CircuCintura = c.Double(nullable: false),
                        CircuCadera = c.Double(nullable: false),
                        PeriCuello = c.Double(nullable: false),
                        CircuCarpo = c.Double(nullable: false),
                        PeriBicep = c.Double(nullable: false),
                        PliegueTri = c.Double(nullable: false),
                        PliegueBi = c.Double(nullable: false),
                        PliegueSupra = c.Double(nullable: false),
                        PliegueSube = c.Double(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pacientes", t => t.PacienteId, cascadeDelete: true)
                .Index(t => t.PacienteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Antropometricoes", "PacienteId", "dbo.Pacientes");
            DropIndex("dbo.Antropometricoes", new[] { "PacienteId" });
            DropTable("dbo.Antropometricoes");
        }
    }
}
