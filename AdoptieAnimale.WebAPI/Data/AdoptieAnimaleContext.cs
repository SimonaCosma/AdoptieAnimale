using Microsoft.EntityFrameworkCore;
using AdoptieAnimale.WebAPI.Models;

namespace AdoptieAnimale.WebAPI.Data
{
    public class AdoptieAnimaleContext : DbContext
    {
        public AdoptieAnimaleContext(DbContextOptions<AdoptieAnimaleContext> options)
            : base(options)
        {
        }

        // DbSet pentru fiecare entitate (tabel)
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Shelter> Shelters { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<AdoptionRequest> AdoptionRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurare relații
            modelBuilder.Entity<Animal>()
                .HasOne(a => a.Category)
                .WithMany(c => c.Animals)
                .HasForeignKey(a => a.CategoryID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Animal>()
                .HasOne(a => a.Shelter)
                .WithMany(s => s.Animals)
                .HasForeignKey(a => a.ShelterID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AdoptionRequest>()
                .HasOne(ar => ar.Animal)
                .WithMany(a => a.AdoptionRequests)
                .HasForeignKey(ar => ar.AnimalID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AdoptionRequest>()
                .HasOne(ar => ar.Member)
                .WithMany(m => m.AdoptionRequests)
                .HasForeignKey(ar => ar.MemberID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}