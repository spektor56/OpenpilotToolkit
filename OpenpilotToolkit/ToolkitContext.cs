using Microsoft.EntityFrameworkCore;
using OpenpilotToolkit.Models;

namespace OpenpilotToolkit
{
    public class ToolkitContext : DbContext
    {
        public DbSet<OpenpilotDevice> Devices { get; set; }

        // The following configures EF to create a Sqlite database file as `C:\blogging.db`.
        // For Mac or Linux, change this to `/tmp/blogging.db` or any other absolute path.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=toolkit.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
    }



}
