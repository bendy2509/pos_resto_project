namespace POS_RESTO.Models;

public class CartItem
{
    public Menu Menu { get; set; }
    public int Quantity { get; set; }
    
    public decimal Subtotal => Menu.UnitPrice * Quantity;
    
    public override string ToString()
    {
        return $"{Menu.Name} x{Quantity} - {Subtotal:N0} HTG";
    }
}