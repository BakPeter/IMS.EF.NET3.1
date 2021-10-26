using IMS_Dal_EF_RegisterUserService;
using IMS_DAL_RegisterUser;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TemplateMethodContracts;
using TemplateMethodService;
using UserWebApiTesting.Data;

namespace UserWebApiTesting
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<RegisterUserContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //services.AddDbContext<RegisterUserContext>(options =>
            //    options.UseSqlServer(RegisterUserContext.ConnectionSettings.ConnectionString));

            services.AddControllers();

            services.AddSingleton<ILogger>(provider => provider.GetRequiredService<ILogger<object>>());
            services.AddScoped(typeof(IDalRegisterUserService), typeof(DalEFRegisterUserServiceImpl));
            services.AddScoped(typeof(ITemplateMethodParamService<,>), typeof(TemplateMethodParamServiceImpl<,>));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            loggerFactory.AddLog4Net();
        }
    }
}
