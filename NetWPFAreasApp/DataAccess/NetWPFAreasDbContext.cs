using NetWPFAreasApp.Models;
using System.Data.Entity;

namespace NetWPFAreasApp.DataAccess
{
    public class NetWPFAreasDbContext : DbContext
    {
        public NetWPFAreasDbContext() : base("name=NetWPFAreasDb")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<UserArea> UserAreas { get; set; }
    }
}
