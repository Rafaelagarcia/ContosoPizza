using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore;

public class PizzaContext : DbContext
{
    public PizzaContext(DbContextOptions<PizzaContext> options) : base(options) { }

    public DbSet<Pizza> Pizzas { get; set; } // DbSet para a tabela Pizza
    public DbSet<Order> Pedidos { get; set; }
    public DbSet<Endereco> Enderecos { get; set; }
    public DbSet<Pagamento> Pagamentos { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>().ToTable("Pedidos");
        modelBuilder.Entity<Endereco>().ToTable("Endereco");
        modelBuilder.Entity<Pagamento>().ToTable("Pagamento");

    }

}

