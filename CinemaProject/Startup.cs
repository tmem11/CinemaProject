using CinemaProject.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.Owin;
using Owin;


[assembly: OwinStartupAttribute(typeof(CinemaProject.Startup))]
namespace CinemaProject
{
    public partial class Startup
    {
         ApplicationDbContext db = new ApplicationDbContext();

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRole();
            CreateAdmin();
        }
        public void createRole()
        {
            var manger = new Microsoft.AspNet.Identity.RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            IdentityRole role = new IdentityRole();
            if (!manger.RoleExists("Admin"))
            {
                role.Name = "Admin";
                manger.Create(role);
            }
            if (!manger.RoleExists("User"))
            {
                role.Name = "User";
                manger.Create(role);
            }
        }
        public void CreateAdmin()
        {
           
           var userManger = new Microsoft.AspNet.Identity.UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            var user = new ApplicationUser();
            user.Email = "tmem.nsasra@gmail.com";
            user.UserName = "Admin";
            var isUserExist = userManger.Create(user, "123456");
            if (isUserExist.Succeeded)
            {
                userManger.AddToRole(user.Id, "Admin");
            }


            


        }
    }
     
}
