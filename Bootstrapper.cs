using WoWMountAndPetCreator.Pages;
using Stylet;
using StyletIoC;
using Microsoft.Extensions.DependencyInjection;
using WoWMountAndPetCreator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace WoWMountAndPetCreator
{
    public class Bootstrapper : MicrosoftDependencyInjectionBootstrapper<ShellViewModel>
    {
        protected override void ConfigureIoC(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();

            services.AddTransient<ShellView>();
            services.AddTransient<ShellViewModel>();

            services.AddTransient<TaskbarView>();
            services.AddTransient<TaskbarViewModel>();

            services.AddTransient<MountTabView>();
            services.AddTransient<MountTabViewModel>();

            services.AddDbContext<ApplicationDbContext>(options => options.UseMySql(
                configuration.GetConnectionString("db"),
                new MySqlServerVersion(new Version(8, 0, 25))
            ));          
        }
    }
}
