using IMS_Model_User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserWebApiTesting.Data
{
    public class IMS_UserContext : DbContext
    {
        public IMS_UserContext(DbContextOptions<IMS_UserContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}