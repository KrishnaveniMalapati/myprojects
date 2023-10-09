// <copyright file="CardDetails.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Msys.Payments.Models
{
    using MSys.PaymentGateway.Library.Models;

    /// <summary>
    /// payment related fields.
    /// </summary>
    public class CardDetails
    {
        /// <summary>
        /// Gets or sets the CardNumber.
        /// </summary>
        public string? CardNumber { get; set; }

        /// <summary>
        /// Gets or sets the cardholder's full name.
        /// </summary>
        public string? CardHolderName { get; set; }

        /// <summary>
        /// Gets or sets the date when the card was issued.
        /// </summary>
        public DateTime CardIssueDate { get; set; }

        /// <summary>
        /// Gets or sets the card's Expiration Date in MM/YY format.
        /// </summary>
        public string? ExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets the card's CVV (Card Verification Code).
        /// </summary>
        public string? CVV { get; set; }

        /// <summary>
        /// Gets or sets the card issuer (e.g., bank name).
        /// </summary>
        public string? CardIssuer { get; set; }

        /// <summary>
        /// Gets or sets the billing address associated with the card.
        /// </summary>
        public string? BillingAddress { get; set; }

        /// <summary>
        /// Gets or sets the type of the card (e.g., Visa, MasterCard).
        /// </summary>
        public CardType CardType { get; set; }

        /// <summary>
        /// Gets or sets the current status of the card (e.g., active, suspended, canceled).
        /// </summary>
        public CardStatus Status { get; set; }

        /// <summary>
        /// Gets or sets the phone number associated with the cardholder.
        /// </summary>
        public string? CardHolderPhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the email address associated with the cardholder.
        /// </summary>
        public string CardHolderEmail { get; set; }

        /// <summary>
        /// Gets or sets the limit of the  card.
        /// </summary>
        public decimal CardLimit { get; set; }

        /// <summary>
        /// Gets or sets the available credit remaining on the card.
        /// </summary>
        public decimal AvailableCredit { get; set; }
    }
}
