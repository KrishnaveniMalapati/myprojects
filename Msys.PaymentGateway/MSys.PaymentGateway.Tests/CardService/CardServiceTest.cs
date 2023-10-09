using MSys.PaymentGateway.Library.Service.Card;

namespace MSys.PaymentGateway.Tests
{
    //public class CardServiceTest
    //{
    //    [SetUp]
    //    public void Setup()
    //    {
    //    }

    //    [Test]
    //    public void Test1()
    //    {
    //        Assert.Pass();
    //    }

    //}
    [TestFixture]
    public class CardServiceTest
    {
        public CardService cardService;

        [SetUp]
        public void Setup()
        {
            // Initialize the CardService class before each test.
           cardService = new CardService();
        }

        
        [Test]
        public void ValidateCardNumber_ValidCard_ReturnsTrue()
        {
            // Arrange
            string validCardNumber = "1234-5678-9012-3456"; // Replace with a valid card number.

            // Act
            bool result = cardService.ValidateCardNumber(validCardNumber);

            // Assert
            Assert.IsTrue(result);
        }
        [Test]
        public void ValidateCardNumber_NullCard_ReturnsFalse()
        {
            // Arrange
            string nullCardNumber = null;

            // Act
            bool result = cardService.ValidateCardNumber(nullCardNumber);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ValidateCardNumber_EmptyCard_ReturnsFalse()
        {
            // Arrange
            string emptyCardNumber = string.Empty;

            // Act
            bool result = cardService.ValidateCardNumber(emptyCardNumber);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ValidateCardNumber_InvalidLengthCard_ReturnsFalse()
        {
            // Arrange
            string invalidLengthCardNumber = "123"; // Invalid length, should be between 13 and 19 digits.

            // Act
            bool result = cardService.ValidateCardNumber(invalidLengthCardNumber);

            // Assert
            Assert.IsFalse(result);
        }

        // Add more test cases for other scenarios, such as card numbers with non-digit characters or testing against the Luhn algorithm.

        [Test]
        public void ValidateCardHolderName_ValidName_ReturnsTrue()
        {
            // Arrange
            string validCardHolderName = "John Smith"; // A valid cardholder name.

            // Act
            bool result = cardService.ValidateCardHolderName(validCardHolderName);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void ValidateCardHolderName_NullName_ReturnsFalse()
        {
            // Arrange
            string nullCardHolderName = null;

            // Act
            bool result = cardService.ValidateCardHolderName(nullCardHolderName);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ValidateCardHolderName_EmptyName_ReturnsFalse()
        {
            // Arrange
            string emptyCardHolderName = "";

            // Act
            bool result = cardService.ValidateCardHolderName(emptyCardHolderName);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ValidateCardHolderName_InvalidCharacters_ReturnsFalse()
        {
            // Arrange
            string invalidCardHolderName = "John S#ith"; // Contains invalid characters.

            // Act
            bool result = cardService.ValidateCardHolderName(invalidCardHolderName);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ValidateCardHolderName_NameTooShort_ReturnsFalse()
        {
            // Arrange
            string shortCardHolderName = "Ana"; // Name is too short (less than 5 characters).

            // Act
            bool result = cardService.ValidateCardHolderName(shortCardHolderName);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ValidateCardHolderName_NameTooLong_ReturnsFalse()
        {
            // Arrange
            string longCardHolderName = "Elizabeth Montgomery"; // Name is too long (more than 15 characters).

            // Act
            bool result = cardService.ValidateCardHolderName(longCardHolderName);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void ValidateCardHolderName_ValidNameWithSpaces_ReturnsFalse()
        {
            // Arrange
            string validCardHolderName = "Alice Johnson Smith"; // A valid cardholder name with spaces.

            // Act
            bool result = cardService.ValidateCardHolderName(validCardHolderName);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsCardValid_CardIssuedToday_ReturnsTrue()
        {
            // Arrange
            DateTime today = DateTime.Today;
            cardService.CardIssueDate = today; // Set the card issue date to today.

            // Act
            bool result = cardService.IsCardValid();

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsCardValid_CardIssuedInThePast_ReturnsTrue()
        {
            // Arrange
            DateTime pastDate = DateTime.Today.AddDays(-1); // One day in the past.
            cardService.CardIssueDate = pastDate; // Set the card issue date to the past.

            // Act
            bool result = cardService.IsCardValid();

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsCardValid_CardIssuedInTheFuture_ReturnsFalse()
        {
            // Arrange
            DateTime futureDate = DateTime.Today.AddDays(1); // One day in the future.
            cardService.CardIssueDate = futureDate; // Set the card issue date to the future.

            // Act
            bool result = cardService.IsCardValid();

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsCardValid_CardIssuedWithSameDate_ReturnsTrue()
        {
            // Arrange
            DateTime today = DateTime.Today;
            cardService.CardIssueDate = today; // Set the card issue date to today.

            // Act
            bool result = cardService.IsCardValid();

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsCardExpired_CardNotExpired_ReturnsFalse()
        {
            // Arrange
            DateTime currentDate = DateTime.Today;
            DateTime futureExpirationDate = currentDate.AddMonths(6); // Set the expiration date 6 months in the future.
            cardService.CardExpirationDate = futureExpirationDate;

            // Act
            bool result = cardService.IsCardExpired();

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsCardExpired_CardExpired_ReturnsTrue()
        {
            // Arrange
            DateTime currentDate = DateTime.Today;
            DateTime pastExpirationDate = currentDate.AddMonths(-1); // Set the expiration date 1 month in the past.
            cardService.CardExpirationDate = pastExpirationDate;

            // Act
            bool result = cardService.IsCardExpired();

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsCardExpired_CardExpiresToday_ReturnsFalse()
        {
            // Arrange
            DateTime currentDate = DateTime.Today;
            cardService.CardExpirationDate = currentDate; // Set the expiration date to today.

            // Act
            bool result = cardService.IsCardExpired();

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsCardExpired_CardExpiresTomorrow_ReturnsFalse()
        {
            // Arrange
            DateTime currentDate = DateTime.Today;
            DateTime tomorrowExpirationDate = currentDate.AddDays(1); // Set the expiration date to tomorrow.
            cardService.CardExpirationDate = tomorrowExpirationDate;

            // Act
            bool result = cardService.IsCardExpired();

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void VerifyCVV_MatchingCVV_ReturnsTrue()
        {
            // Arrange
            string cardCVV = "123"; // Replace with the actual CVV.
            string inputCVV = "123"; // Same CVV for verification.

            // Act
            cardService.CVV = cardCVV; // Set the card's CVV.
            bool result = cardService.VerifyCVV(inputCVV);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void VerifyCVV_NonMatchingCVV_ReturnsFalse()
        {
            // Arrange
            string cardCVV = "123"; // Replace with the actual CVV.
            string inputCVV = "456"; // Different CVV for verification.

            // Act
            cardService.CVV = cardCVV; // Set the card's CVV.
            bool result = cardService.VerifyCVV(inputCVV);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void VerifyCVV_NullInputCVV_ReturnsFalse()
        {
            // Arrange
            string cardCVV = "123"; // Replace with the actual CVV.
            string inputCVV = null; // Null input CVV.

            // Act
            cardService.CVV = cardCVV; // Set the card's CVV.
            bool result = cardService.VerifyCVV(inputCVV);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void VerifyCVV_EmptyInputCVV_ReturnsFalse()
        {
            // Arrange
            string cardCVV = "123"; // Replace with the actual CVV.
            string inputCVV = ""; // Empty input CVV.

            // Act
            cardService.CVV = cardCVV; // Set the card's CVV.
            bool result = cardService.VerifyCVV(inputCVV);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidPhoneNumber_Valid10DigitNumber_ReturnsTrue()
        {
            // Arrange
            string validPhoneNumber = "1234567890";

            // Act
           // cardService.ValidPhoneNumber = IsValidPhoneNumber;
            bool result = cardService.IsValidPhoneNumber(validPhoneNumber);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsValidPhoneNumber_ValidNumberWithSpaces_ReturnsFalse()
        {
            // Arrange
            string phoneNumberWithSpaces = "555 123 4567";

            // Act
            bool result = cardService.IsValidPhoneNumber(phoneNumberWithSpaces);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidPhoneNumber_ValidNumberWithDashes_ReturnsFalse()
        {
            // Arrange
            string phoneNumberWithDashes = "555-987-6543";

            // Act
            bool result = cardService.IsValidPhoneNumber(phoneNumberWithDashes);

            // Assert
            Assert.IsFalse(result);
        }


        [Test]
        public void IsValidEmail_ValidGmailAddress_ReturnsTrue()
        {
            // Arrange
            string validEmail = "example@gmail.com";

            // Act
            bool result = cardService.IsValidEmail(validEmail);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsValidEmail_ValidGmailAddressWithNumbersAndSymbols_ReturnsTrue()
        {
            // Arrange
            string validEmail = "john.doe+1234@gmail.com";

            // Act
            bool result = cardService.IsValidEmail(validEmail);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsValidEmail_InvalidEmailAddress_ReturnsFalse()
        {
            // Arrange
            string invalidEmail = "notvalid@gmail";

            // Act
            bool result = cardService.IsValidEmail(invalidEmail);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidEmail_EmailWithDifferentDomain_ReturnsFalse()
        {
            // Arrange
            string nonGmailEmail = "example@yahoo.com";

            // Act
            bool result = cardService.IsValidEmail(nonGmailEmail);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidEmail_EmailWithSpaces_ReturnsFalse()
        {
            // Arrange
            string emailWithSpaces = "john doe@gmail.com";

            // Act
            bool result = cardService.IsValidEmail(emailWithSpaces);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidCardLimit_ValidLimitWithinRange_ShouldReturnTrue()
        {
            // Arrange
            decimal validLimit = 250000;
            //var card = new Card(); // Initialize Card instance (assuming Card class exists).

            // Act
            bool result = cardService.IsValidCardLimit(validLimit);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsValidCardLimit_InvalidLimitBelowRange_ShouldReturnFalse()
        {
            // Arrange
            decimal invalidLimit = -1000;
            //var card = new Card(); // Initialize Card instance (assuming Card class exists).

            // Act
            bool result = cardService.IsValidCardLimit(invalidLimit);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidCardLimit_InvalidAboveUpperBoundaryLimit_ShouldReturnFalse()
        {
            // Arrange
            decimal invalidLimit = 500001;

            // Act
            bool result = cardService.IsValidCardLimit(invalidLimit);

            // Assert
            Assert.IsFalse(result);
        }
    }

}