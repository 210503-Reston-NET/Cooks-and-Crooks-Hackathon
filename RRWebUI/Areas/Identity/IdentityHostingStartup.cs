using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RRDL;
using RRModels;

[assembly: HostingStartup(typeof(RRWebUI.Areas.Identity.IdentityHostingStartup))]
namespace RRWebUI.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDefaultIdentity<Customer>()
                    .AddEntityFrameworkStores<RestaurantDBContext>()
                    .AddDefaultUI()
                    .AddDefaultTokenProviders();
            });
        }
    }
}