using DynamicLoaderService;
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
using TemplateMethodContracts;
using TemplateMethodService;

namespace IMS_Services_RegisterUser
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

            services.AddSingleton<ILogger>(provider => provider.GetRequiredService<ILogger<object>>());
            services.AddSingleton<IConfiguration>(provider => Configuration);
            services.AddSingleton(MappingConfig.RegisterMaps().CreateMapper());

            services.AddScoped(typeof(ITemplateMethodParamService<,>), typeof(TemplateMethodParamServiceImpl<,>));
            services.AddScoped(typeof(IDalRegisterUserService), typeof(DalEFRegisterUserServiceImpl));

            services.AddControllers();
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
