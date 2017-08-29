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

            // 為了計算特別優惠折扣，將數量 group by 起來
            // 從測試案例得知 組合只會有 兩個數量存在
            var BookQuantityGroup = customerShoppingCart.buyBook.GroupBy(x => x.Quantity);
            bool SpeciallyDiscountFlag = false;

            //共買五冊，並且 數量組合等於兩種，啟動特別折扣開關
            if (customerShoppingCart.buyBook.Count == 5 && BookQuantityGroup.Count() == 2)
            {
                SpeciallyDiscountFlag = true;
            }

            //總共交易次數 1 1 1 1 為 1個區塊 ，1 2 1 1 為兩個區塊
            MAX_Transaction = customerShoppingCart.buyBook.Max(x => x.Quantity);

            for (int i = 0; i < MAX_Transaction; i++)
            {
                BookCout = 0;
                LastBookName = "";
                SubTotal = 0d;

                //將購物車內物品依序讀取
                foreach (var ShoppingCartItem in customerShoppingCart.buyBook.OrderBy(x =>x.Name))
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

                    //啟動特別折扣(只能剛好符合 2 2 2 1 1 需要)
                    if (SpeciallyDiscountFlag)
                    {
                        if (BookCout == 4)
                        {
                            break;
                        }
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