namespace ContosoPizza.Models;
public class Pagamento
{
    public int Id{get;set;}
    public TipoPagamento TipoPagamento { get; set; } // Ex: "Cartão", "Dinheiro", "Transferência"
    public decimal Valor { get; set; }
    public string Status { get; set; } // Ex: "Pendente", "Confirmado", "Cancelado"
}
