// <copyright file="CustomerDetails.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MSys.PaymentGateway.Library.Models
{
    /// <summary>
    /// Customer related fields.
    /// </summary>
    public class CustomerDetails
    {
        /// <summary
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the Email.
        /// </summary>
        public string? Email { get; set; }
    }
}
