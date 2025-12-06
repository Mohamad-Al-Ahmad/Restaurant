using Microsoft.EntityFrameworkCore;
using Restaurant.Domain.Models;

namespace Restaurant.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<User>()
                .Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("varchar(150)");

            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");

            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .IsRequired()
                .HasColumnType("varchar(25)")
                .HasConversion<string>();

            modelBuilder.Entity<User>()
                .Property(u => u.CreatedAt)
                .IsRequired()
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<User>()
                .Property(u => u.UpdatedAt)
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAddOrUpdate();

            ///////////////category////////////////
            modelBuilder.Entity<Category>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            modelBuilder.Entity<Category>()
                .Property(c => c.Description)
                .HasMaxLength(500)
                .HasColumnType("varchar(500)");

            modelBuilder.Entity<Category>()
                .Property(c => c.ImageUrl)
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");

            modelBuilder.Entity<Category>()
                .Property(c => c.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            modelBuilder.Entity<Category>()
                .Property(c => c.CreatedAt)
                .IsRequired()
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()");

            //////////////////product/////////////////
            modelBuilder.Entity<Product>()
                .HasKey(p => p.Id);

            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            modelBuilder.Entity<Product>()
                .Property(p => p.Description)
                .HasMaxLength(500)
                .HasColumnType("varchar(500)");

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .IsRequired()
                .HasPrecision(10, 2)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Product>()
                .Property(p => p.ImageUrl)
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");

            modelBuilder.Entity<Product>()
                .Property(p => p.IsAvailable)
                .IsRequired()
                .HasDefaultValue(true);

            modelBuilder.Entity<Product>()
                .Property(p => p.CreatedAt)
                .IsRequired()
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Product>()
                .HasOne<Category>()
                .WithMany()
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            ////////////////Order////////////
            modelBuilder.Entity<Order>()
                .HasKey(o => o.Id);

            modelBuilder.Entity<Order>()
                .Property(o => o.CustomerName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnType("varchar(100)");

            modelBuilder.Entity<Order>()
                .Property(o => o.CustomerPhone)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)");

            modelBuilder.Entity<Order>()
                .Property(o => o.CustomerAddress)
                .HasMaxLength(255)
                .HasColumnType("varchar(255)");

            modelBuilder.Entity<Order>()
                .Property(o => o.TotalAmount)
                .IsRequired()
                .HasPrecision(15, 2)
                .HasColumnType("decimal(15,2)");

            modelBuilder.Entity<Order>()
                .Property(o => o.Notes)
                .HasMaxLength(500)
                .HasColumnType("varchar(500)");

            modelBuilder.Entity<Order>()
                .Property(o => o.PaymentMethod)
                .IsRequired()
                .HasConversion<string>();

            modelBuilder.Entity<Order>()
                .Property(o => o.CreatedAt)
                .IsRequired()
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Order>()
                .Property(o => o.UpdatedAt)
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()")
                .ValueGeneratedOnAddOrUpdate();

            ///////////////OrderItem////////////
            modelBuilder.Entity<OrderItem>()
                .HasKey(o => o.Id);

            modelBuilder.Entity<OrderItem>()
                .Property(o => o.Quantity)
                .IsRequired();

            modelBuilder.Entity<OrderItem>()
                .Property(o => o.UnitPrice)
                .IsRequired()
                .HasPrecision(10, 2)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<OrderItem>()
                .Property(o => o.Subtotal)
                .IsRequired()
                .HasPrecision(10, 2)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<OrderItem>()
                .HasOne<Order>()
                .WithMany()
                .HasForeignKey(o => o.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<OrderItem>()
                .HasOne<Product>()
                .WithMany()
                .HasForeignKey(o => o.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            /////////////Notification//////////////
            modelBuilder.Entity<Notification>()
                .HasKey(n => n.Id);

            modelBuilder.Entity<Notification>()
                .Property(n => n.Title)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnType("varchar(150)");

            modelBuilder.Entity<Notification>()
                .Property(n => n.Message)
                .IsRequired()
                .HasMaxLength(500)
                .HasColumnType("varchar(500)");

            modelBuilder.Entity<Notification>()
                .Property(n => n.Type)
                .IsRequired()
                .HasConversion<string>();

            modelBuilder.Entity<Notification>()
                .Property(n => n.IsRead)
                .IsRequired()
                .HasDefaultValue(false);

            modelBuilder.Entity<Notification>()
                .Property(n => n.CreatedAt)
                .IsRequired()
                .HasColumnType("datetime")
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
