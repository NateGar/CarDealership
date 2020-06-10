using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Capstone_5_CarDealership.Models
{
    public partial class GCCarDbContext : DbContext
    {
        public GCCarDbContext()
        {
        }

        public GCCarDbContext(DbContextOptions<GCCarDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cars> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=GCCarDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cars>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Color)
                    .HasColumnName("color")
                    .HasMaxLength(50);

                entity.Property(e => e.Make)
                    .IsRequired()
                    .HasColumnName("make")
                    .HasMaxLength(50);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasColumnName("model")
                    .HasMaxLength(50);

                entity.Property(e => e.Year)
                    .IsRequired()
                    .HasColumnName("year")
                    .HasMaxLength(4);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
