using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using Projekat.Models;

[assembly: OwinStartupAttribute(typeof(Projekat.Startup))]
namespace Projekat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            napraviRole();
        }

        private void napraviRole()
        {

            MaterijalContext context = new MaterijalContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists("Administrator"))
            {
                var role = new IdentityRole();
                role.Name = "Administrator";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Urednik"))
            {
                var role = new IdentityRole();
                role.Name = "Urednik";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Profesor"))
            {
                var role = new IdentityRole();
                role.Name = "Profesor";
                roleManager.Create(role);
            }
            if (!roleManager.RoleExists("Učenik"))
            {
                var role = new IdentityRole();
                role.Name = "Učenik";
                roleManager.Create(role);
            }
        }
    }
}
