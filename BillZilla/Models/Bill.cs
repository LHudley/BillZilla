using System.ComponentModel.DataAnnotations;

namespace BillZilla.Models
{
    public class Bill
    {
       
        public int ID { get; set; }
        
        public decimal Value { get; set; }

        [Required]
        public required string? Description { get; set; }
        
    }
}
