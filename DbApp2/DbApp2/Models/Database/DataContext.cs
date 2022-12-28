using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DbApp2.Models.Database
{
    public partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Reservation> Reservations { get; set; } = null!;
        public virtual DbSet<Section> Sections { get; set; } = null!;
        public virtual DbSet<Series> Series { get; set; } = null!;
        public virtual DbSet<Sold> Solds { get; set; } = null!;
        public virtual DbSet<Waste> Wastes { get; set; } = null!;
        public virtual DbSet<Worker> Workers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("AppData"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.DeliveryDate)
                    .HasColumnType("date")
                    .HasColumnName("delivery_date");

                entity.Property(e => e.ExpirationDate)
                    .HasColumnType("date")
                    .HasColumnName("expiration_date");

                entity.Property(e => e.Name)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("_name")
                    .IsFixedLength();

                entity.Property(e => e.Place)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("place")
                    .IsFixedLength();

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Series)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("series")
                    .IsFixedLength();

                entity.HasOne(d => d.NameNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Name)
                    .HasConstraintName("FK__Products___name__30F848ED");

                entity.HasOne(d => d.PlaceNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.Place)
                    .HasConstraintName("FK__Products__place__31EC6D26");
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LastName)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("last_name")
                    .IsFixedLength();

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.ReceptionDate)
                    .HasColumnType("date")
                    .HasColumnName("reception_date");

                entity.Property(e => e.Status)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("status")
                    .IsFixedLength();

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Reservati__produ__300424B4");
            });

            modelBuilder.Entity<Section>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK__Section__019A50BEEDB732F0");

                entity.ToTable("Section");

                entity.Property(e => e.Name)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("_name")
                    .IsFixedLength();

                entity.Property(e => e.ManagerId).HasColumnName("manager_id");

                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.Sections)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK__Section__manager__2D27B809");
            });

            modelBuilder.Entity<Series>(entity =>
            {
                entity.HasKey(e => e.Name)
                    .HasName("PK__Series__019A50BE74082A9A");

                entity.Property(e => e.Name)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("_name")
                    .IsFixedLength();

                entity.Property(e => e.Code).HasColumnName("_code");
            });

            modelBuilder.Entity<Sold>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Sold");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("product_name")
                    .IsFixedLength();

                entity.Property(e => e.Value).HasColumnName("_value");

                entity.HasOne(d => d.ProductNameNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ProductName)
                    .HasConstraintName("FK__Sold__product_na__2F10007B");
            });

            modelBuilder.Entity<Waste>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Waste");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("product_name")
                    .IsFixedLength();

                entity.Property(e => e.Value).HasColumnName("_value");

                entity.HasOne(d => d.ProductNameNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.ProductName)
                    .HasConstraintName("FK__Waste__product_n__2E1BDC42");
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("first_name")
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("last_name")
                    .IsFixedLength();

                entity.Property(e => e.ManagerId).HasColumnName("manager_id");

                entity.Property(e => e.Salary).HasColumnName("salary");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
