namespace NutriVaSe.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using NutriVaSe.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NutriVaSe.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NutriVaSe.Models.ApplicationDbContext context)
        {
            //Crear si no existe Rol Administrador
            if (!context.Roles.Any(r => r.Name == "Administrador"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Administrador" };

                manager.Create(role);
            }

            //Crear Usuario
            if (!context.Users.Any(u => u.Email == "seekazpa@gmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { Email = "seekazpa@gmail.com", UserName = "seekazpa@gmail.com", Nombre = "Sebastian", Apellido = "Kaslauskaz" };

                manager.Create(user, "Nutrivase0@");
                //Delegador Administrador a usuario
                manager.AddToRole(user.Id, "Administrador");
            }

        }
    }
}
