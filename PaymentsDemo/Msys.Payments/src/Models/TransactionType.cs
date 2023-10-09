// <copyright file="TransactionType.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MSys.PaymentGateway.Library.Models
{
    /// <summary>
    /// Represents the type of a card transaction.
    /// </summary>
    public class TransactionType
    {
        /// <summary>
        /// Represents the type of a card transaction.
        /// </summary>
        public enum TransactionType1
        {
            /// <summary>
            /// Represents a Purchase.
            /// </summary>
            Purchase,

            /// <summary>
            /// Represents a CashWithdrawl.
            /// </summary>
            CashWithdrawal,

            /// <summary>
            /// Represents a Paymentt.
            /// </summary>
            Payment,

            /// <summary>
            /// Represents a Refund.
            /// </summary>
            Refund,
        }
    }
}