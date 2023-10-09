// <copyright file="CardStatus.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MSys.PaymentGateway.Library.Models
{
    /// <summary>
    /// Represents the status of a credit or debit card.
    /// </summary>
    public enum CardStatus
    {
        /// <summary>
        /// Represents a Active.
        /// </summary>
        Active,

        /// <summary>
        /// Represents a Suspended.
        /// </summary>
        Suspended,

        /// <summary>
        /// Represents a Canceled.
        /// </summary>
        Canceled,

        /// <summary>
        /// Represents a Expired.
        /// </summary>
        Expired,
    }
}