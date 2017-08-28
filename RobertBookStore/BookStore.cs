using System.Collections.Generic;
using System.Linq;

namespace RobertBookStore
{
    public class BookStore
    {
        public BookStore()
        {
        }

        public void ShoppingCartCalculation(ShoppingCart customerShoppingCart)
        {
            var total = 0d;
            var MAX_Transaction = 0;
            var BookCout = 0;
            var LastBookName = "";
            var SumTotlal = 0d;

            MAX_Transaction = customerShoppingCart.buyBook.Max(x => x.Quantity);

            for(int i=0;i < MAX_Transaction; i++)
            {
                BookCout = 0;
                LastBookName = "";
                total = 0d;

                //將購物車內物品依序讀取
                foreach (var ShoppingCartItem in customerShoppingCart.buyBook.OrderBy(x => x.Name))
                {
                    total += ShoppingCartItem.SalePrice;
                    ShoppingCartItem.Quantity = ShoppingCartItem.Quantity - 1;
                   
                    if (ShoppingCartItem.Quantity == 0)
                    {
                        customerShoppingCart.buyBook.Remove(ShoppingCartItem);
                    }

                    if(ShoppingCartItem.Name != LastBookName)
                    {
                        LastBookName = ShoppingCartItem.Name;
                        BookCout++;
                    }
                   
                }

                if (BookCout == 2)
                {
                    total = total * 0.95d;
                }
                else if (BookCout == 3)
                {
                    total = total * 0.9d;
                }
                else if (BookCout == 4)
                {
                    total = total * 0.8d;
                }
                else if (BookCout >= 5)
                {
                    total = total * 0.75d;
                }

                SumTotlal += total;
            }
           
            customerShoppingCart.GrossPrice = SumTotlal;
        }
    }
}