using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(STech.UI.Web.Areas.Identity.IdentityHostingStartup))]
namespace STech.UI.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}