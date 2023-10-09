// <copyright file="CardType.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MSys.PaymentGateway.Library.Models
{
    /// <summary>
    /// Represents the type of a credit or debit card.
    /// </summary>
    public enum CardType
    {
        /// <summary>
        /// Represents a Visa.
        /// </summary>
        Visa,

        /// <summary>
        /// Represents a MasterCard.
        /// </summary>
        MasterCard,

        /// <summary>
        /// Represents a AmericanExpress.
        /// </summary>
        AmericanExpress,

        /// <summary>
        /// Represents a Discover.
        /// </summary>
        Discover,
    }
}