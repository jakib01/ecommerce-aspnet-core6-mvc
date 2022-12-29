using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Models;

public partial class EcommerceDotnetCoreDibboContext : DbContext
{
    public EcommerceDotnetCoreDibboContext()
    {
    }

    public EcommerceDotnetCoreDibboContext(DbContextOptions<EcommerceDotnetCoreDibboContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategoryMapping> ProductCategoryMappings { get; set; }

    public virtual DbSet<ProductImage> ProductImages { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserProfile> UserProfiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=JULKERNIENAKIB;Database=ecommerce_dotnet_core_dibbo;User Id=sa; Password=Tcl142536;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.Property(e => e.BrandId).HasColumnName("BrandID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.ImageUrl).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Cart>(entity =>
        {
            entity.Property(e => e.CartId).HasColumnName("CartID");
            entity.Property(e => e.Color)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.IpAddress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProdictSize)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ProductQuantity).HasDefaultValueSql("((1))");
            entity.Property(e => e.ProductUnit)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Order).WithMany(p => p.Carts)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Carts__OrderI__3F4668f44");

            entity.HasOne(d => d.Product).WithMany(p => p.Carts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Carts__ProductI__3F466844");

            entity.HasOne(d => d.User).WithMany(p => p.Carts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Carts__UserI__3F4668f44");
        });



        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.HasKey(e => e.ProfileId);

            entity.ToTable("UserProfile");

            entity.Property(e => e.ProfileId).HasColumnName("ProfileID");

            entity.Property(e => e.Address).HasColumnType("text");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");

            entity.Property(e => e.DateOfBirth).HasColumnType("date");

            entity.Property(e => e.DeletedDate).HasColumnType("datetime");

            entity.Property(e => e.EmailVerifiedAt).HasColumnType("datetime");

            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

            entity.Property(e => e.IsEmailVerified).HasDefaultValueSql("((0))");

            entity.Property(e => e.NidNo)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.Property(e => e.Photo)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

            entity.Property(e => e.ShippingAddress).HasColumnType("text");

            entity.Property(e => e.TinNo)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.Property(e => e.UserType)
                .HasMaxLength(255)
                .IsUnicode(false)
                .IsFixedLength();

            entity.Property(e => e.VerifiedDate).HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.UserProfiles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserProfiles__UserI__3F4668f44");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.ImageUrl).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.IpAddress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Message).HasColumnType("text");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ShippingAddress).HasColumnType("text");
            entity.Property(e => e.TransactionId)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Payment).WithMany(p => p.Orders)
                .HasForeignKey(d => d.PaymentId)
                .HasConstraintName("FK__Orders__PaymentI__3F466844");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Orders__UserI__3F466844");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Image)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PaymentNo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Priority).HasDefaultValueSql("((1))");
            entity.Property(e => e.ShortName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TransectionType)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(e => e.Color)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.ProductCode).HasMaxLength(50);
            entity.Property(e => e.Quantity).HasMaxLength(255);
            entity.Property(e => e.Size)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Slug).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(50);
            entity.Property(e => e.Unit).HasMaxLength(255);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Brand).WithMany(p => p.Products)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Products__BrandI__3F466844");
        });

        modelBuilder.Entity<ProductCategoryMapping>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Category).WithMany(p => p.ProductCategoryMappings)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductCa__Categ__4E88ABD4");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductCategoryMappings)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductCa__Produ__4F7CD00D");
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.ImageUrl).HasMaxLength(255);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductImages)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ProductIm__Produ__52593CB8");
        });

        modelBuilder.Entity<Setting>(entity =>
        {
            entity.Property(e => e.SettingId).HasColumnName("SettingID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("PhoneNO");
            entity.Property(e => e.ShippingCost).HasDefaultValueSql("((100))");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.PhoneNo, "AK_PhoneNo").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            //entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.EmailVerifiedAt)
                .IsRowVersion()
                .IsConcurrencyToken()
                .HasColumnName("emailVerifiedAt");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.IsAdmin)
                .HasDefaultValueSql("((0))")
                .HasColumnName("isAdmin");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RememberToken)
                .HasMaxLength(100)
                .IsUnicode(false);
            //entity.Property(e => e.ShippingAddress).HasColumnType("text");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
