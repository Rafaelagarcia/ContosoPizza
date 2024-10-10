using ContosoPizza.Models;

namespace ContosoPizza.Services;

public class PizzaService
{
    private readonly PizzaContext _context;

    public PizzaService(PizzaContext context)
    {
        _context = context;
    }
    public List<Pizza> GetAll() => _context.Pizzas.ToList();

    static int nextId = 3;

    public Pizza? Get(int id) => _context.Pizzas.FirstOrDefault(p => p.Id == id);
    public void Add(Pizza pizza)
    {
        _context.Pizzas.Add(pizza);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var pizza = Get(id);
        if (pizza is null)
            return;

        _context.Pizzas.Remove(pizza);
        _context.SaveChanges();
    }

    public void Update(Pizza pizza)
    {
        var existingPizza = Get(pizza.Id);
        if (existingPizza is null)
            return;

        // Atualiza as propriedades desejadas
        existingPizza.Name = pizza.Name;
        existingPizza.IsGlutenFree = pizza.IsGlutenFree;

        _context.SaveChanges();
    }
}
