using System.ComponentModel.DataAnnotations;

namespace apiDeneme.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        public string MusteriName { get; set; }
        public string? InvoiceType { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public int? Price { get; set; }


    }
}
