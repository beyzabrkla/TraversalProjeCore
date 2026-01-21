using Microsoft.EntityFrameworkCore;

namespace SiganlRApi.DAL
{
    public class Context :DbContext
    {
        public Context(DbContextOptions<Context> options):base(options)
        {
            
        }

        public DbSet<Visitor> Visitors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Visitor>().ToTable("Visitors");
            // Sütun isimlerini veritabanındaki (pgAdmin'de görünen) haliyle eşleyin
            modelBuilder.Entity<Visitor>().Property(v => v.VisitorId).HasColumnName("VisitorId");
            modelBuilder.Entity<Visitor>().Property(v => v.City).HasColumnName("City");
            modelBuilder.Entity<Visitor>().Property(v => v.CityVisitCount).HasColumnName("CityVisitCount");
            modelBuilder.Entity<Visitor>().Property(v => v.VisitDate).HasColumnName("VisitDate");
        }
    }


}
