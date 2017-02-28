using Microsoft.EntityFrameworkCore;
namespace activityCenter.Models
{
    public class activityCenterContext : DbContext
    {
        public activityCenterContext(DbContextOptions<activityCenterContext> options) : base(options)
        { }
 
        public DbSet<User> Users { get; set; }
    }
}