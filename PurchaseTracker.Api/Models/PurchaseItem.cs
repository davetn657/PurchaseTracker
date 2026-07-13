using System.ComponentModel.DataAnnotations.Schema;

namespace PurchaseTracker.Api.Models;

public class PurchaseItem
{
    public int Id { get; set; }
    public string ItemName { get; set; } = string.Empty;
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public DateTime PurchaseDate { get; set; } = DateTime.Now;
    public string PaymentStatus { get; set; } = "Paid";
    [Column(TypeName = "decimal(18, 2)")]
    public decimal PaymentPrice { get; set; }

}