using IMS_Model_User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IMS_DAL_EF_GetUserService
{
    public class GetUserContext : DbContext
    {
        public GetUserContext (DbContextOptions<GetUserContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }

    public class DesignTimeContextFactory : IDesignTimeDbContextFactory<GetUserContext>
    {
        public GetUserContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = GetConfiguration();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            //var connectionString = RegisterUserContext.ConnectionSettings.ConnectionString;

            var builder = new DbContextOptionsBuilder<GetUserContext>();
            builder.UseSqlServer(connectionString);
            return new GetUserContext(builder.Options);
        }

        private IConfigurationRoot GetConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@Directory.GetCurrentDirectory() + "/../UserWebApiTesting/appsettings.json")
                .Build();
        }
    }
}
