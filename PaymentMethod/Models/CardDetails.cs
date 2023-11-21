using System.ComponentModel.DataAnnotations;

namespace PaymentMethod.Models
{
    public class CardDetails
    {
        [Required]
        [RegularExpression(@"^\d{16}$", ErrorMessage = "Please enter a valid 16-digit card number.")]
        public string CardNumber { get; set; }

        [Required]
        [RegularExpression(@"^\d{2}$", ErrorMessage = "Please enter a valid 2-digit expiration month.")]
        public string ExpirationMonth { get; set; }

        [Required]
        [RegularExpression(@"^\d{2}$", ErrorMessage = "Please enter a valid 2-digit expiration year.")]
        public string ExpirationYear { get; set; }

        [Required]
        [RegularExpression(@"^\d{3}$", ErrorMessage = "Please enter a valid 3-digit CVV.")]
        public string CVV { get; set; }
    }
}
