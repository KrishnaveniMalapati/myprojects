using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPaymentIntegration.Models
{
	public class OrderEntity
	{
		public int Id { get; set; }

		public string CustomerName { get; set; }

		public string Email { get; set; }

		public string Mobile { get; set; }

		public double TotalAmount { get; set; }

        [Required]
        [RegularExpression(@"^\d{16}$", ErrorMessage = "Please enter a valid 16-digit card number.")]
        public string CardNumber { get; set; }

        [Required]
        [RegularExpression(@"^\d{3}$", ErrorMessage = "Please enter a valid 3-digit CVV.")]
        public string CVV { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ExpirationDate { get; set; }

        [NotMapped]
		public string TransactionId { get; set; }

		public string OrderId { get; set; }
	}
}
