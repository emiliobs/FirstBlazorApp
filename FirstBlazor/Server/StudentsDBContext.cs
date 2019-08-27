using System;
using FirstBlazor.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FirstBlazor.Server
{
    public partial class StudentsDBContext : DbContext
    {
        public StudentsDBContext()
        {
        }

        public StudentsDBContext(DbContextOptions<StudentsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<StudentMasters> StudentMasters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=StudentsDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<StudentMasters>(entity =>
            {
                entity.HasKey(e => e.StdId)
                    .HasName("PK__StudentM__55DCAE3FA5E6FDFD");

                entity.Property(e => e.StdId).HasColumnName("StdID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StdName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
        }
    }
}
