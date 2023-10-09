// <copyright file="CardService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace MSys.PaymentGateway.Library.Service.Card
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Validation for the cardService.
    /// </summary>
    public class CardService
    {
        private readonly decimal _cardLimit;

        public string CardNumber { get; set; }

        public string CardHolderName { get; set; }

        public DateTime CardIssueDate { get; set; }

        public DateTime CardExpirationDate { get; set; }

        public string CVV { get; set; }

        public string CardIssuer { get; set; }

        public string BillingAddress { get; set; }

        public string Status { get; set; }

        // public string CardType { get; set; }
        public string CardHolderPhoneNumber { get; set; }

        public string CardHolderEmail { get; set; }

        public decimal CardLimit { get; set; }

        public decimal AvailableCredit { get; set; }

        // Constructor to initialize the card object.
        public CardService(string cardNumber, string cardHolderName, DateTime cardIssueDate, DateTime cardExpirationDate,
               string cvv, string cardIssuer, string billingAddress, string status, /* string cardType*/
               string cardHolderPhoneNumber, string cardHolderEmail, decimal cardLimit, decimal availableCredit)
        {
            this.CardNumber = cardNumber;
            CardHolderName = cardHolderName;
            CardIssueDate = cardIssueDate;
            CardExpirationDate = cardExpirationDate;
            CVV = cvv;
            CardIssuer = cardIssuer;
            BillingAddress = billingAddress;
            Status = status;

            // CardType = cardType;
            CardHolderPhoneNumber = cardHolderPhoneNumber;
            this.CardHolderEmail = cardHolderEmail;
            CardLimit = cardLimit;
            AvailableCredit = availableCredit;
        }

        public CardService()
        {
        }

        public enum CardType
        {
            Visa,
            MasterCard,
            AmericanExpress,
            Discover,
            Unknown,
        }

        public class CreditCard
        {
            private readonly CardType MasterCard;

            public string CardNumber { get; set; }

            public CardType Type { get; private set; }

            public CreditCard(string cardNumber)
            {
                CardNumber = cardNumber;

                Type = DetermineCardType(cardNumber);

                // Initialize other properties as needed.
            }

            public CreditCard()
            {
            }

            public CardType DetermineCardType(string cardNumber)
            {
                // Implement logic to determine the card type based on card number prefixes.
                // You can use regular expressions or other methods to identify the card type.
                if (cardNumber.StartsWith("4"))
                {
                    return CardType.Visa;
                }
                else if (cardNumber.StartsWith("5"))
                {
                    return CardType.MasterCard;
                }
                else if (cardNumber.StartsWith("3"))
                {
                    return CardType.AmericanExpress;
                }
                else if (cardNumber.StartsWith("6"))
                {
                    return CardType.Discover;
                }
                else
                {
                    return CardType.Unknown;
                }
            }

        }

        // Business logic method to validate the card number.
        public bool ValidateCardNumber(string validCardNumber)
        {
            // Check if the card number is not null or empty.
            if (string.IsNullOrWhiteSpace(validCardNumber))
            {
                return false;
            }

            // Remove non-digit characters from the card number.
            string cleanCardNumber = Regex.Replace(validCardNumber, "[^0-9]", string.Empty);

            // Check if the cleaned card number has a valid length (typically 13 to 19 digits).
            if (cleanCardNumber.Length < 13 || cleanCardNumber.Length > 19)
            {
                return false;
            }

            // You can implement additional checks like Luhn algorithm validation here.
            return true;
        }

        // Business logic method to validate the cardholder's name.
        public bool ValidateCardHolderName(string validCardHolderName)
        {
            // Check if the cardholder's name is not null or empty.
            if (string.IsNullOrWhiteSpace(validCardHolderName))
            {
                return false;
            }

            // Check if the cardholder's name contains only valid characters (letters and spaces).
            if (!Regex.IsMatch(validCardHolderName, @"^[a-zA-Z\s]*$"))
            {
                return false;
            }

            // Check if the cardholder's name has a length between 5 and 15 characters.
            if (validCardHolderName.Length < 5 || validCardHolderName.Length > 15)
            {
                return false;
            }

            return true;
        }

        public bool IsCardValid()
        {
            // Check if the card is issued in the past or today.
            DateTime currentDate = DateTime.Today;

            return CardIssueDate.Date <= currentDate.Date;
        }

        public bool IsCardExpired()
        {
            // Check if the card has expired based on its expiration date and the current date.
            DateTime currentDate = DateTime.Today;
            return CardExpirationDate.Date < currentDate.Date;
        }

        public bool VerifyCVV(string inputCVV)
        {
            // Check if the provided CVV matches the card's CVV.
            return string.Equals(inputCVV, CVV, StringComparison.Ordinal);
        }

        public void ActivateCard()
        {
            // Activate the card.
            Status = "Active";
        }

        public void DeactivateCard()
        {
            // Deactivate the card.
            Status = "Canceled";
        }

        public bool IsValidPhoneNumber(string validPhoneNumber)
        {
            // Define a regular expression pattern for a valid phone number.
            // This is a simplified example; you can modify it to match your specific format requirements.
            string phoneNumberPattern = @"^\d{10}$"; // Assumes a 10-digit phone number.

            // Check if the provided phone number matches the pattern.
            return Regex.IsMatch(validPhoneNumber, phoneNumberPattern);
        }

        public bool IsValidEmail(string validEmail)
        {
            // Define a regular expression pattern for a valid email address ending with @gmail.com.
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@gmail\.com$";

            // Check if the provided email matches the pattern.
            return Regex.IsMatch(validEmail, emailPattern);
        }

        public bool IsValidCardLimit(decimal limit)
        {
            // Validate if the card limit is within a valid range.
            return limit >= 0 && limit <= 500000;
        }
    }
}
