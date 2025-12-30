namespace POS_RESTO.Models;

public class Order
{
    public int Id { get; set; }
    public int ClientId { get; set; }
    public int MenuId { get; set; }
    public int Quantity { get; set; }
    public DateTime OrderDate { get; set; }
    public string Status { get; set; } = "en cours";
}