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
            var SubTotal = 0d;         //每個區塊的總額
            var MAX_Transaction = 0;   //計算區塊數量
            var BookCout = 0;          //區塊中書籍量
            var LastBookName = "";     //上一本書名
            var SumTotlal = 0d;        //區塊總和





            MAX_Transaction = customerShoppingCart.buyBook.Max(x => x.Quantity);

            for (int i = 0; i < MAX_Transaction; i++)
            {
                BookCout = 0;
                LastBookName = "";
                SubTotal = 0d;

                //將購物車內物品依序讀取
                foreach (var ShoppingCartItem in customerShoppingCart.buyBook)
                {
                    //將價格依序累計
                    SubTotal += ShoppingCartItem.SalePrice;

                    //將數量減1
                    ShoppingCartItem.Quantity = ShoppingCartItem.Quantity - 1;

                    //數量為0的移除 list 
                    if (ShoppingCartItem.Quantity == 0)
                    {
                        customerShoppingCart.buyBook.Remove(ShoppingCartItem);
                    }

                    //判斷 書名是否一樣
                    if (ShoppingCartItem.Name != LastBookName)
                    {
                        LastBookName = ShoppingCartItem.Name;
                        BookCout++;
                    }

                }

                //折扣
                if (BookCout == 2)
                {
                    SubTotal = SubTotal * 0.95d;
                }
                else if (BookCout == 3)
                {
                    SubTotal = SubTotal * 0.9d;
                }
                else if (BookCout == 4)
                {
                    SubTotal = SubTotal * 0.8d;
                }
                else if (BookCout >= 5)
                {
                    SubTotal = SubTotal * 0.75d;
                }

                SumTotlal += SubTotal;
            }

            customerShoppingCart.GrossPrice = SumTotlal;
        }
    }
}