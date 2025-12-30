namespace POS_RESTO.Models
{
    public class Menu
    {
        public int MenuId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int StockQuantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }
    }
}