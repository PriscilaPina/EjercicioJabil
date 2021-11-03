using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace JabilEjercicio.Models
{
    public partial class MaterialsContext : DbContext
    {
        public MaterialsContext()
        {
        }

        public MaterialsContext(DbContextOptions<MaterialsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<PartNumber> PartNumbers { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=DESKTOP-ANJP8ML\\SQLEXPRESS;Initial Catalog=Materials;Integrated Security=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Building>(entity =>
            {
                entity.HasKey(e => e.Pkbuilding)
                    .HasName("Buildings_PKBuilding");

                entity.Property(e => e.Pkbuilding).HasColumnName("PKBuilding");

                entity.Property(e => e.Building1)
                    .HasMaxLength(4000)
                    .IsUnicode(false)
                    .HasColumnName("Building");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.Pkcustomer)
                    .HasName("Customers_PKCustomer");

                entity.Property(e => e.Pkcustomer).HasColumnName("PKCustomer");

                entity.Property(e => e.Customer1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Customer");

                entity.Property(e => e.Fkbuilding).HasColumnName("FKBuilding");

                entity.Property(e => e.Prefix)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkbuildingNavigation)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.Fkbuilding)
                    .HasConstraintName("FKBuilding");
            });

            modelBuilder.Entity<PartNumber>(entity =>
            {
                entity.HasKey(e => e.PkpartNumber)
                    .HasName("PartNumbers_PKPartNumber");

                entity.Property(e => e.PkpartNumber).HasColumnName("PKPartNumber");

                entity.Property(e => e.Fkcustomer).HasColumnName("FKCustomer");

                entity.Property(e => e.PartNumber1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PartNumber");

                entity.HasOne(d => d.FkcustomerNavigation)
                    .WithMany(p => p.PartNumbers)
                    .HasForeignKey(d => d.Fkcustomer)
                    .HasConstraintName("FKCustomer");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
