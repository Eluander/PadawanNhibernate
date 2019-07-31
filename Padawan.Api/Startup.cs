using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Padawan.Domain.Handlers;
using Padawan.Domain.Repositories;
using Padawan.Infra.Context;
using Padawan.Infra.Repositories;
using Padawan.Infra.Transations;
using Padawan.Shared;
using System.IO;

namespace Padawan.Api
{
    public class Startup
    {
        public static IConfigurationRoot Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
            AppSettings.ConnectionString = $"{Configuration["connectionString"]}";

            services.AddMvc();
            services.AddCors();

            services.Configure<IISOptions>(o =>
            {
                o.ForwardClientCertificate = false;
            });

            services.AddResponseCompression();

            services.AddSingleton(PadawanNHibernateHelper.SessionFactory());

            services.AddTransient<IUow, Uow>();

            services.AddTransient<IAccountRepository, AccountRepository>();

            services.AddTransient<AccountHandler, AccountHandler>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) { app.UseDeveloperExceptionPage(); }

            app.UseCors(x => {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });

            app.UseResponseCompression();

            app.UseMvc();
        }
    }
}
