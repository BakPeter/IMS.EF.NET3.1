using IMS_Model_Toeken;
using IMS_Model_User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TokenWebApiTokenTesting.Data
{
    //public class TokenContext : DbContext
    //{
    //    public TokenContext(DbContextOptions<TokenContext> options) : base(options) { }

    //    public DbSet<Token> Token{ get; set; }
    //}

    public class TokenContext : DbContext
    {
        public TokenContext(DbContextOptions<TokenContext> options) : base(options) { }

        public DbSet<Token> Token { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
