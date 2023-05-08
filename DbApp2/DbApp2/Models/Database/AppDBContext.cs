//using System;
//using System.Collections.Generic;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata;

//namespace DbApp2.Models.Database
//{
//    public partial class AppDBContext : DbContext
//    {
//        public AppDBContext()
//        {
//        }

//        public AppDBContext(DbContextOptions<AppDBContext> options)
//            : base(options)
//        {
//        }

//        public virtual DbSet<Manager> Managers { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//                IConfigurationRoot configuration = new ConfigurationBuilder()
//                    .SetBasePath(Directory.GetCurrentDirectory())
//                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();
//                optionsBuilder.UseSqlServer(configuration.GetConnectionString("AppData"));
//            }
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.Entity<Manager>(entity =>
//            {
//                entity.Property(e => e.Id).ValueGeneratedNever();

//                entity.Property(e => e.FirstName)
//                    .HasMaxLength(80)
//                    .IsUnicode(false)
//                    .HasColumnName("first_name")
//                    .IsFixedLength();

//                entity.Property(e => e.LastName)
//                    .HasMaxLength(80)
//                    .IsUnicode(false)
//                    .HasColumnName("last_name")
//                    .IsFixedLength();

//                entity.Property(e => e.Salary).HasColumnName("salary");
//            });

//            OnModelCreatingPartial(modelBuilder);
//        }

//        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//    }
//}
