// Classe pour le résumé des paiements

namespace POS_RESTO.Models;

public class PaymentSummary
{
    public int OrderId { get; set; }
    public decimal OrderTotal { get; set; }
    public decimal AmountPaid { get; set; }
    public decimal RemainingAmount { get; set; }
    public bool IsFullyPaid { get; set; }
    public int PaymentCount { get; set; }
    public List<Payment> Payments { get; set; }
            
    public decimal PaymentPercentage => OrderTotal > 0 ? (AmountPaid / OrderTotal) * 100 : 0;
}