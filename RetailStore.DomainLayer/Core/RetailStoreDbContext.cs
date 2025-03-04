using RetailStore.DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace RetailStore.DomainLayer.Core
{
    public class RetailStoreDbContext(DbContextOptions<RetailStoreDbContext> options) : DbContext(options)
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
        public DbSet<DeliveryDetail> DeliveryDetails { get; set; }
        public DbSet<DeliveryStatus> DeliveryStatuses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Refer to DB tables
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Customer>().ToTable("Customers");
            modelBuilder.Entity<Delivery>().ToTable("Deliveries");
            modelBuilder.Entity<DeliveryDetail>().ToTable("DeliveryDetails");
            modelBuilder.Entity<DeliveryStatus>().ToTable("DeliveryStatuses");
            modelBuilder.Entity<Order>().ToTable("Orders");
            modelBuilder.Entity<OrderItem>().ToTable("OrderItems");
            modelBuilder.Entity<Payment>().ToTable("Payments");
            modelBuilder.Entity<PaymentMethod>().ToTable("PaymentMethods");

            // Declare special DB fields
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("DECIMAL(18, 5)");
            modelBuilder.Entity<Order>()
                .Property(p => p.TotalAmount)
                .HasColumnType("DECIMAL(18, 5)");
            modelBuilder.Entity<OrderItem>()
                .Property(p => p.SubTotal)
                .HasColumnType("DECIMAL(18, 5)");

            // One-to-Many: Customer > Orders
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

            // One-to-Many: Order > OrderItems
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId);

            // One-to-Many: OrderItem > Product
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(oi => oi.ProductId);

            // One-to-One: Order > Payment
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Payment)
                .WithOne(p => p.Order)
                .HasForeignKey<Payment>(p => p.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-One: Order > Delivery
            modelBuilder.Entity<Order>()
                .HasOne(o => o.Delivery)
                .WithOne(d => d.Order)
                .HasForeignKey<Delivery>(d => d.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            // One-to-Many: PaymentMethod > Payments
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.PaymentMethod)
                .WithMany(pm => pm.Payments)
                .HasForeignKey(p => p.PaymentMethodId);

            // One-to-Many: Delivery > DeliveryDetails
            modelBuilder.Entity<DeliveryDetail>()
                .HasOne(dd => dd.Delivery)
                .WithMany(d => d.DeliveryDetails)
                .HasForeignKey(dd => dd.DeliveryId);

            // One-to-Many: DeliveryStatus > DeliveryDetails
            modelBuilder.Entity<DeliveryDetail>()
                .HasOne(dd => dd.DeliveryStatus)
                .WithMany(ds => ds.DeliveryDetails)
                .HasForeignKey(dd => dd.DeliveryStatusId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
