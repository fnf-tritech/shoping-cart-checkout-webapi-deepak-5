using ShoppingCartDiscount;
using ShoppingCartDiscount.Controllers;
using Xunit;

namespace ShoppingCartDiscount.Tests
{
    public class CheckoutServiceTests
    {
        [Fact]
        public void CalculateTotalAmount_SingleItemWithDiscount_ReturnsCorrectTotalAmount()
        {
            // Arrange
            var checkoutService = new CheckoutService();
            var products = "BBB"; // 3 items 'B' with discount
            var expectedTotalAmount = 75; // Discounted amount for 3 items 'B'

            // Act
            var actualTotalAmount = checkoutService.CalculateTotalAmount(products);

            // Assert
            Assert.Equal(expectedTotalAmount, actualTotalAmount);
        }

        [Fact]
        public void CalculateTotalAmount_MultipleItemsWithMixedDiscounts_ReturnsCorrectTotalAmount()
        {
            // Arrange
            var checkoutService = new CheckoutService();
            var products = "AAA"; //  3 items 'A' with discount
            var expectedTotalAmount =130 ; // Discounted amount for 3 items 'A'

            // Act
            var actualTotalAmount = checkoutService.CalculateTotalAmount(products);

            // Assert
            Assert.Equal(expectedTotalAmount, actualTotalAmount);
        }

        [Fact]
        public void CalculateTotalAmount_ItemsWithNoDiscount_ReturnsCorrectTotalAmount()
        {
            // Arrange
            var checkoutService = new CheckoutService();
            var products = "ABCD"; // No discounts applicable
            var expectedTotalAmount = 115; // Regular amount for all items

            // Act
            var actualTotalAmount = checkoutService.CalculateTotalAmount(products);

            // Assert
            Assert.Equal(expectedTotalAmount, actualTotalAmount);
        }

        [Fact]
        public void CalculateTotalAmount_MultipleItemsWithQuantityDiscount_ReturnsCorrectTotalAmount()
        {
            // Arrange
            var checkoutService = new CheckoutService();
            var products = "AAAAAA"; // 6 items 'A' with discount
            var expectedTotalAmount = 260; // Discounted amount for 6t items 'A'

            // Act
            var actualTotalAmount = checkoutService.CalculateTotalAmount(products);

            // Assert
            Assert.Equal(expectedTotalAmount, actualTotalAmount);
        }
    }
}
