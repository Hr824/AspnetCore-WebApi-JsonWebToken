using Microsoft.EntityFrameworkCore;
using WebApiJwt.Models;

namespace WebApiJwt.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Person> Person { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<Activity> Activity { get; set; }
        public DbSet<PersonActivity> PersonActivity { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            base.OnModelCreating(builder);

            //Composite primary key (PersonId, ActivityId) for PersonActivity entity
            builder.Entity<PersonActivity>()
                .HasKey(pa => new { pa.PersonId, pa.ActivityId });
        }
    }
}