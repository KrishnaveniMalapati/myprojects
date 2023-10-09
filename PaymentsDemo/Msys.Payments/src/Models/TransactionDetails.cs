// <copyright file="TransactionDetails.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MSys.PaymentGateway.Library.Models
{
    /// <summary>
    /// Represents an individual transaction made with the card.
    /// </summary>
    public class TransactionDetails
    {
        /// <summary>
        /// Gets or sets the unique identifier for the transaction.
        /// </summary>
        public Guid TransactionId { get; set; }

        /// <summary>
        /// Gets or sets the date and time of the transaction.
        /// </summary>
        public DateTime TransactionDate { get; set; }

        /// <summary>
        /// Gets or sets the transaction amount.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the name of the merchant where the transaction occurred.
        /// </summary>
        public string MerchantName { get; set; }

        /// <summary>
        /// Gets or sets the location (e.g., city) of the merchant where the transaction occurred.
        /// </summary>
        public string MerchantLocation { get; set; }

        /// <summary>
        /// Gets or sets the category or type of the transaction (e.g., groceries, entertainment).
        /// </summary>
        public string TransactionCategory { get; set; }

        /// <summary>
        /// Gets or sets a note or description associated with the transaction.
        /// </summary>
        public string TransactionNote { get; set; }

        /// <summary>
        /// Gets or sets the currency code (e.g., USD, EUR) for the transaction amount.
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the type of the transaction (e.g., purchase, withdrawal).
        /// </summary>
        public TransactionType Type { get; set; }
    }
}
