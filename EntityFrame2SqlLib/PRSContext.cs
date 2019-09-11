using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EntityFrame2SqlLib
{
    public partial class PRSContext : DbContext
    {
        //Default constructor
        public PRSContext()
        {
        }
        //Constructor with one parameter
        public PRSContext(DbContextOptions<PRSContext> options)
            : base(options)
        {
        }
        //Communicating with database through these collections
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Request> Request { get; set; }
        public virtual DbSet<RequestLine> RequestLine { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Vendor> Vendor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
                optionsBuilder.UseSqlServer("server=localhost\\sqlexpress;database=PRS;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.PartNbr)
                    .HasName("UQ__Product__DAFC0C1E7BBAA66A")
                    .IsUnique();

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.VendorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product__VendorI__5441852A");
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.Property(e => e.DeliveryMode).HasDefaultValueSql("('Pickup')");

                entity.Property(e => e.Status).HasDefaultValueSql("('NEW')");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Request)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Request__UserId__59FA5E80");
            });

            modelBuilder.Entity<RequestLine>(entity =>
            {
                entity.Property(e => e.Quantity).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.RequestLine)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__RequestLi__Produ__70DDC3D8");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.RequestLine)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK__RequestLi__Reque__6FE99F9F");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Username)
                    .HasName("UQ__Fire__536C85E4EEB4E608")
                    .IsUnique();

                entity.Property(e => e.IsAdmin).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsReviewer).HasDefaultValueSql("((1))");

                entity.Property(e => e.Username).IsUnicode(false);
            });



            //Fluent API
            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.HasIndex(e => e.Code)
                    .HasName("UQ__Vendor__A25C5AA7F5589ECB")
                    .IsUnique();

                entity.Property(e => e.City).HasDefaultValueSql("('Cincinnati')");

                entity.Property(e => e.State).HasDefaultValueSql("('OH')");
            });
        }
    }
}
