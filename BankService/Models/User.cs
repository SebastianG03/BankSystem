using System.ComponentModel.DataAnnotations;

namespace APIBankService.Models
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }

        [Required]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        [Required]
        [MinLength(10)]
        public string Phone { get; set; }

        [Required]
        [MinLength(4)]
        public string Role { get; set; }
        [Required]
        public string DNI { get; set; }
    }

}
