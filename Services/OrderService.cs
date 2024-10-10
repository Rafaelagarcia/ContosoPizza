using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Services;

public class OrderService
{

    private readonly OrderContext _context;

    public OrderService(OrderContext context)
    {
        _context = context;
    }

    public List<Order> GetAll() {
        return _context.Pedidos.Include(p => p.Endereco) // Inclui Endereco
        .Include(o => o.Pagamento) // Inclui Pagamento
        .ToList();
    
    }

    public Order? Get(int Id) => _context.Pedidos.Include(e => e.Endereco)
    .Include(p => p.Pagamento)
    .FirstOrDefault(i => i.Id == Id);


      public void Add(Order order)
    {
        _context.Pedidos.Add(order);
        _context.SaveChanges();
    }

    public void Delete(int Id) { 

         var pedido =  Get(Id);
         if(pedido is null)
            return;

        _context.Pedidos.Remove(pedido);
        _context.SaveChanges();
    }

    public void Update(Order order){
       var existingOrder = Get(order.Id);
        if (existingOrder is null)
            return;

        // Atualiza as propriedades desejadas
        existingOrder.Pagamento = order.Pagamento;
        existingOrder.Nome = existingOrder.Nome;
        existingOrder.Endereco = existingOrder.Endereco;
        existingOrder.PizzaId = existingOrder.PizzaId;
        existingOrder.Whatsapp = existingOrder.Whatsapp;

        _context.SaveChanges();
    }







}