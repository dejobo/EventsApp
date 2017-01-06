using System.Data.Entity;

namespace EventsApp.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext()
            : base("AppDbContext")
        {
            //this.Configuration.ProxyCreationEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>()
            //    .HasMany(u => u.Events)
            //    .WithMany(e => e.Users)
            //    .Map(x =>
            //    {
            //        x.ToTable("EventUsers");
            //        x.MapLeftKey("UserId");
            //        x.MapRightKey("EventId");
            //    });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Session> Sessions { get; set; }
        //public DbSet<EventUsers> EventUsers { get; set; }


        public void SetModified(object entity)
        {
            Entry(entity).State = EntityState.Modified;
        }

        public void SetAdd(object entity)
        {
            Entry(entity).State = EntityState.Added;
        }
    }
}