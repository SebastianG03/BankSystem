using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace APIBankService.Models
{
    public class BankAccount
    {
        [Key]
        public int IdAccount { get; set; }
        [Required]
        public int IdUser { get; set; }
        [Required]
        public int AccountNumber { get; set; }
        [Required]
        public float AccountAmount { get; set; }

        
        
    }
}
