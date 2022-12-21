
using AuthenticationMicroservice.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationMicroservice.Context
    {
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {

            }

            public DbSet<UserDetail> Userdetails{ get; set; }

           
        }
    }


