using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore;

public class OrderContext : DbContext
{
    public OrderContext(DbContextOptions<OrderContext> options) : base(options) { }
    
    public DbSet<Order> Pedidos { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Pagamento> Pagamentos { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>().ToTable("Pedidos");
        modelBuilder.Entity<Endereco>().ToTable("Endereco");
        modelBuilder.Entity<Pagamento>().ToTable("Pagamento");
    modelBuilder.Entity<Pagamento>()
        .Property(p => p.TipoPagamento)
        .HasConversion<string>();
    }
    
    
    
    }