using Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlueStone_Admin.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
       
        public DbSet<ToDoContext> ToDoItems { get; set; }
        public DbSet<HomeContext> HomeModel { get; set; }
        public DbSet<UserReport> UserReport { get; set; }
        public DbSet<Profile> Profile { get; set; }
    }
}
