using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace players.Models
{
    public partial class playersContext : DbContext
    {
        public playersContext()
        {
        }

        public playersContext(DbContextOptions<playersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Jugadore> Jugadores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server= JDS-LAPTOP ;Database=players;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Jugadore>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("jugadores");

                entity.Property(e => e.Edad).HasColumnName("edad");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Nick)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nick");

                entity.Property(e => e.Pais)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pais");

                entity.Property(e => e.Wins).HasColumnName("wins");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
