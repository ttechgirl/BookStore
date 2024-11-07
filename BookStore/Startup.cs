using DbUp;
using DbUp.Engine.Output;
using DbUp.Helpers;
using Serilog;

namespace BookStore
{
    public static partial class Startup
    {
        public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddRouting(routeOptions =>
            {
                routeOptions.LowercaseUrls = true;
            });

            builder.Services.AddControllersWithViews();
            return builder;
        }

    }
}
