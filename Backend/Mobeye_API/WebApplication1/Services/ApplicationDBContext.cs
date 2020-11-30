using Microsoft.EntityFrameworkCore;
using Mobeye_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobeye_API.Services
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }
        public DbSet<Alarm> Alarms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AccountUser> AccountUsers { get; set; }
        public DbSet<CallKeyUser> CallKeyUsers { get; set; }
        public DbSet<ContactUser> ContactUsers { get; set; }
    }
}
