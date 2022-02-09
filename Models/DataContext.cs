using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PraxedesBackend.Models
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
                
        public virtual DbSet<Relative> Relatives { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-ARVMMP2\\SQLEXPRESS;Database=PraxedesDb;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Relative>(entity =>
            {
                entity.ToTable("Relative");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.DateOfBirth).HasColumnType("DateOfBirth");
                entity.Property(e => e.RelativeNames).HasColumnName("RelativeNames");
                entity.Property(e => e.RelativeLastNames).HasColumnName("RelativeLastNames");                
                entity.Property(e => e.RelativeGender).HasColumnName("RelativeGender");
                entity.Property(e => e.RelativeDocumentNumber).HasColumnName("RelativeDocumentNumber");
                entity.Property(e => e.InLaw).HasColumnName("InLaw");
                entity.Property(e => e.RelativeAge).HasColumnName("RelativeAge");

                entity.Property(e => e.UserId).HasColumnName("UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Relatives)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FKUserId");
            });

           

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
