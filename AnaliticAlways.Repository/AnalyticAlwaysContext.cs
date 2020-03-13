using AnaliticAlways.Repository.Entity;
using Microsoft.EntityFrameworkCore;

namespace AnaliticAlways.Repository
{
    public partial class AnalyticAlwaysContext : DbContext
    {
        public AnalyticAlwaysContext()
        {
        }

        public AnalyticAlwaysContext(DbContextOptions<AnalyticAlwaysContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Stock> Stock { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=AnalyticAlways;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Stock>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.PointOfSale)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Product)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
