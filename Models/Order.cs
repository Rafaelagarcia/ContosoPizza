namespace ContosoPizza.Models;

public class Order
{

    public int Id { get; set; }
    public int PizzaId { get; set; }
    public string Whatsapp { get; set; }
    public string Nome { get; set; }

    
    public Endereco Endereco { get; set; }
    public Pagamento Pagamento { get; set; }

}