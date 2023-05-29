using ShoppingCartDiscount.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCartDiscount.Controllers
{
    public class CheckoutService
    {
        private readonly List<Item> items;
        public CheckoutService()
        {
            items = new List<Item>
            {
                new Item { Products = 'A', Amount = 50, Discount_Amount = new Discount_Amount { Quantity = 3, Discount_AmountAmount = 130 } },
                new Item { Products = 'B', Amount = 30, Discount_Amount = new Discount_Amount { Quantity = 2, Discount_AmountAmount = 45 } },
                new Item { Products = 'C', Amount = 20 },
                new Item { Products = 'D', Amount = 15 }
            };
        }
        public decimal CalculateTotalAmount(string products)
        {
            var itemCounts = GetItemCounts(products);
            decimal totalAmount = 0;

            foreach (var item in itemCounts)
            {
                var selectedItem = items.FirstOrDefault(i => i.Products == item.Key);
                if (selectedItem != null)
                {
                    totalAmount += CalculateItemAmount(selectedItem, item.Value);
                }
            }
            return totalAmount;
        }
        private Dictionary<char, int> GetItemCounts(string products)
        {
            return products.GroupBy(p => p)
                           .ToDictionary(group => group.Key, group => group.Count());
        }
        private decimal CalculateItemAmount(Item item, int quantity)
        {
            if (item.Discount_Amount != null)
            {
                int discountQuantity = item.Discount_Amount.Quantity;
                int discountAmountQuantity = quantity / discountQuantity;
                int regularQuantity = quantity % discountQuantity;
                decimal discountAmount = discountAmountQuantity * item.Discount_Amount.Discount_AmountAmount;
                decimal regularAmount = regularQuantity * item.Amount;
                return discountAmount + regularAmount;
            }
            return quantity * item.Amount;
        }
    }
}