namespace CareExchangeAPI.Models;

public class ClientPayment
{
   
    public int Id { get; set; }
    public int ClienPaytId { get; set; }
    public int CPShiftId { get; set; }
    public string? InvoiceNumber { get; set; }
    public decimal AmountCharged { get; set; }
    public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

    public string? PaymentMethod { get; set; }
    public string? StripeTransactionID { get; set; }

    // Navigation properties
    public virtual CareHomeClient Client { get; set; } = null!;
    public virtual Shift Shift { get; set; } = null!;
}