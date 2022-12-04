using System.Threading;

[assembly: HostingStartup(typeof(Cedekap.Web.Areas.Identity.IdentityHostingStartup))]

namespace Cedekap.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}
