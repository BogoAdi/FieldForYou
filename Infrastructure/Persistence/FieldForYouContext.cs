using Domain;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Persistence
{
    public class FieldForYouContext : DbContext
    {
        public FieldForYouContext(DbContextOptions<FieldForYouContext> dbContextOptions) :base(dbContextOptions)
        {
        }
        public DbSet<SportField> SportFields { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
      /*  protected override void  OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
            .UseSqlServer(@"Server = (localdb)\MSSQLLocalDB; Database = FieldForYou; Trusted_Connection = True;");
        }
      */
    }
}
