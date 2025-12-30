namespace POS_RESTO.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMode { get; set; } // 'cash', 'card', 'cheque'
        public Order OrderDetails { get; set; }
    }
}