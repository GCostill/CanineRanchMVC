using CanineRanch.Services;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CanineRanch.WebMVC.Startup))]
namespace CanineRanch.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            var svc = new RoleService();
            svc.CreateAdmin();
            svc.MakeMyUserAdmin();
        }
    }
}
