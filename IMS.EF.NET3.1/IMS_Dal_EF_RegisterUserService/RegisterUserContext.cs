using IMS_Model_User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IMS_Dal_EF_RegisterUserService
{
    public class RegisterUserContext : DbContext
    {
        public RegisterUserContext(DbContextOptions<RegisterUserContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        //public class ConnectionSettings
        //{
        //    public static string ConnectionString { get; private set; }
        //        = "Server=PETER-PC\\SQLEXPRESS; Database=_IMS_EF_User_DB_Dll_Test; Trusted_Connection=true;";
        //}
    }


    public class DesignTimeContextFactory : IDesignTimeDbContextFactory<RegisterUserContext>
    {
        public RegisterUserContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = GetConfiguration();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            //var connectionString = RegisterUserContext.ConnectionSettings.ConnectionString;

            var builder = new DbContextOptionsBuilder<RegisterUserContext>();
            builder.UseSqlServer(connectionString);
            return new RegisterUserContext(builder.Options);
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
