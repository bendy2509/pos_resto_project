namespace POS_RESTO.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal => Quantity * UnitPrice;
        public DateTime OrderDate { get; set; }
        public string Status { get; set; } // 'en cours', 'terminee', 'annulee'
    }
}