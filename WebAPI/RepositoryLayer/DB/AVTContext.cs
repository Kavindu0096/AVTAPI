using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace RepositoryLayer.DB
{
    public partial class AVTContext : DbContext
    {
        public IConfiguration Configuration { get; }
        public AVTContext()
        {
        }

        public AVTContext(DbContextOptions<AVTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAircraft> TblAircrafts { get; set; }
        public virtual DbSet<TblAircraftSighting> TblAircraftSightings { get; set; }
        public virtual DbSet<TblUser> TblUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connection = Configuration.GetConnectionString("DefaultConnection");
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection
                //string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection
                //strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<TblAircraft>(entity =>
            {
                entity.HasKey(e => e.AircraftId);

                entity.ToTable("TBL_Aircraft");

                entity.Property(e => e.AircraftId).HasColumnName("Aircraft_ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.Make).HasMaxLength(128);

                entity.Property(e => e.Model).HasMaxLength(128);

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.Registration).HasMaxLength(8);
            });

            modelBuilder.Entity<TblAircraftSighting>(entity =>
            {
                entity.ToTable("TBL_Aircraft_Sighting");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AircraftId).HasColumnName("Aircraft_ID");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.Location).HasMaxLength(225);

                entity.Property(e => e.Make).HasMaxLength(128);

                entity.Property(e => e.Model).HasMaxLength(128);

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.Registration).HasMaxLength(8);

                entity.Property(e => e.SightingAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Uimage).HasColumnName("UImage");
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("TBL_User");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeletedAt).HasColumnType("datetime");

                entity.Property(e => e.ModifiedAt).HasColumnType("datetime");

                entity.Property(e => e.UserCode)
                    .HasMaxLength(10)
                    .HasColumnName("User_Code")
                    .IsFixedLength(true);

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .HasColumnName("User_Name")
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
