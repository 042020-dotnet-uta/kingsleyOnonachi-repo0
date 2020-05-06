using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Proj0.Models
{
    public partial class project0Context : DbContext
    {
        public project0Context()
        {
        }

        public project0Context(DbContextOptions<project0Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<Defaultstore> Defaultstore { get; set; }
        public virtual DbSet<Inventory> Inventory { get; set; }
        public virtual DbSet<Orderlist> Orderlist { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Store> Store { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL("server=127.0.0.1;port=3306;user=root;password=NowAndNever12;database=project0;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customers>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PRIMARY");

                entity.ToTable("customers");

                entity.Property(e => e.CustomerId).HasColumnName("customerId");

                entity.Property(e => e.CityAddress)
                    .HasColumnName("cityAddress")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CountryAddress)
                    .IsRequired()
                    .HasColumnName("countryAddress")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("firstName")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasColumnName("lastName")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.PassWord)
                    .IsRequired()
                    .HasColumnName("pass_word")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.RegDate).HasColumnName("regDate");

                entity.Property(e => e.StateAddress)
                    .IsRequired()
                    .HasColumnName("stateAddress")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StreetAddress)
                    .HasColumnName("streetAddress")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("userName")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Defaultstore>(entity =>
            {
                entity.HasKey(e => new { e.DefaultStoreId })
                    .HasName("PRIMARY");
                entity.ToTable("defaultstore");

                entity.HasIndex(e => e.UserId)
                    .HasName("userId");

                entity.HasIndex(e => e.StoreId)
                    .HasName("storeId");

                entity.Property(e => e.DefaultStoreId).HasColumnName("defaultStoreId");

                entity.Property(e => e.RegDate).HasColumnName("regDate");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.Property(e => e.StoreId).HasColumnName("storeId");

                entity.HasOne(d => d.DefaultStore)
                    .WithOne(p => p.Defaultstore)
                    .HasForeignKey<Defaultstore>(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("defaultstore_ibfk_2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Defaultstore)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("defaultstore_ibfk_1");
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasKey(e => new { e.InventoryId })
                    .HasName("PRIMARY");

                entity.ToTable("inventory");

                entity.HasIndex(e => e.ProductId)
                    .HasName("productId_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.StoreId)
                    .HasName("inventory_ibfk_1");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.StoreId).HasColumnName("storeId");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ListPrice)
                    .HasColumnName("listPrice")
                    .HasColumnType("double(10,2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Quantity).HasColumnName("quantity");
                entity.Property(e => e.InventoryId).HasColumnName("inventroyId");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Inventory)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("inventory_ibfk_1");
            });

            modelBuilder.Entity<Orderlist>(entity =>
            {
                entity.ToTable("orderlist");

                entity.HasIndex(e => e.OrderId)
                    .HasName("orderId");

                entity.HasIndex(e => e.ProductId)
                    .HasName("productId");

                entity.Property(e => e.OrderlistId).HasColumnName("orderlistId");

                entity.Property(e => e.OrderDate).HasColumnName("orderDate");

                entity.Property(e => e.OrderId).HasColumnName("orderId");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Orderlist)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("orderlist_ibfk_1");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Orderlist)
                    .HasPrincipalKey(p => p.ProductId)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("orderlist_ibfk_2");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PRIMARY");

                entity.ToTable("orders");

                entity.HasIndex(e => e.UserId)
                    .HasName("userId");

                entity.Property(e => e.OrderId).HasColumnName("orderId");

                entity.Property(e => e.OrderDate).HasColumnName("orderDate");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("orders_ibfk_1");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("store");


                entity.Property(e => e.StoreId).HasColumnName("storeId");

                entity.Property(e => e.CityAddress)
                    .HasColumnName("cityAddress")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CountryAddress)
                    .IsRequired()
                    .HasColumnName("countryAddress")
                    .HasMaxLength(30)
                    .IsUnicode(false);


                entity.Property(e => e.StateAddress)
                    .IsRequired()
                    .HasColumnName("stateAddress")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StreetAddress)
                    .HasColumnName("streetAddress")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                /*entity.HasOne(d => d.Product)
                    .WithMany(p => p.StoreNavigation)
                    .HasPrincipalKey(p => p.ProductId)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("store_ibfk_1");*/
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
