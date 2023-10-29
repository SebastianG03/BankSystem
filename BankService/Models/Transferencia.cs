using System.ComponentModel.DataAnnotations;

namespace APIBankService.Models
{
    public class Transferencia
    {
        [Key]
        public int IdTransfer { get; set; }
        [Required]
        public int IdAccountSender { get; set; }
        [Required]
        public int IdAccountReceiver { get; set; }
        [Required]
        public float Amount { get; set; }
        [Required]
        public DateTime DateIssue { get; set; }
    }
}
