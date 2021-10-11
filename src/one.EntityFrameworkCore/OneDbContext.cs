using Microsoft.EntityFrameworkCore;
using one.Domain;

namespace one.EntityFrameworkCore
{
    public class OneDbContext : DbContext
    {
        public OneDbContext(DbContextOptions<OneDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigurePersonTable();
        }
    }
}