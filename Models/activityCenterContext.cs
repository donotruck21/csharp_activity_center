using Microsoft.EntityFrameworkCore;
namespace activityCenter.Models
{
    public class activityCenterContext : DbContext
    {
        public activityCenterContext(DbContextOptions<activityCenterContext> options) : base(options)
        { }
 
        public DbSet<User> Users { get; set; }
        public DbSet<JoinedUser> JoinedUsers { get; set; }
        public DbSet<Activity> Activities { get; set; }
    }
}