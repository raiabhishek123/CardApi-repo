using System.ComponentModel.DataAnnotations;

namespace CardServiceApi.Models
{
    public class Card
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string CardHolderName { get; set; }

        [Required]
        public int ExpiryMonth { get; set; }

        [Required]
        public int ExpiryYear { get; set; } 
        [Required]
        public int CCV { get; set; }


    }
}
