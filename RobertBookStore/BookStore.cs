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
            var SubTotal = 0m;         //每個區塊的總額
            var BookCout = 0;          //區塊中書籍量
            var LastBookName = "";     //上一本書名
            var SumTotlal = 0m;        //區塊總和
            var MAX_BookQuantity = 0;   //計算區塊數量

            List<Book> booklist = new List<Book>();

            MAX_BookQuantity = customerShoppingCart.buyBook.Max(x => x.Quantity);

            for (int i = 0; i < MAX_BookQuantity; i++)
            {
                //先將書籍依序讀出
                foreach (var ShoppingCartItem in customerShoppingCart.buyBook.OrderBy(x => x.Name))
                {
                    //將數量減1
                    ShoppingCartItem.Quantity = ShoppingCartItem.Quantity - 1;

                    //數量為0的移除 list
                    if (ShoppingCartItem.Quantity == 0)
                    {
                        customerShoppingCart.buyBook.Remove(ShoppingCartItem);
                    }

                    booklist.Add(ShoppingCartItem);
                }
            }

            List<decimal> payPriceList = new List<decimal>();

            //先將書籍依序讀出
            foreach (var discount_item in _discount)
            {
                List<decimal> payPriceSalePriceList = new List<decimal>();
                //先將書籍依序讀出
                foreach (var PayBook in booklist.Select((value, index) => new { index, value }))
                {
                    //判斷 書名是否一樣
                    if (PayBook.value.Name != LastBookName)
                    {
                        LastBookName = PayBook.value.Name;
                        BookCout++;
                    }

                    if (BookCout == discount_item.Key)
                    {
                        SubTotal += PayBook.value.SalePrice;

                        payPriceSalePriceList.Add(SubTotal * GetDiscount(BookCout));

                        SubTotal = 0;
                        BookCout = 0;
                    }
                    else
                    {
                        SubTotal += PayBook.value.SalePrice;
                    }

                    if (PayBook.index == booklist.Count - 1)
                    {
                        payPriceSalePriceList.Add(SubTotal);
                    }
                }

                payPriceList.Add(payPriceSalePriceList.Sum());
                
                SumTotlal = 0;
                SubTotal = 0;
                BookCout = 0;
            }

            customerShoppingCart.GrossPrice = payPriceList.Min();








            //var SubTotal = 0m;         //每個區塊的總額
            //var MAX_Transaction = 0;   //計算區塊數量
            //var BookCout = 0;          //區塊中書籍量
            //var LastBookName = "";     //上一本書名
            //var SumTotlal = 0m;        //區塊總和

            //MAX_Transaction = customerShoppingCart.buyBook.Max(x => x.Quantity);

            //for (int i = 0; i < MAX_Transaction; i++)
            //{
            //    BookCout = 0;
            //    LastBookName = "";
            //    SubTotal = 0m;

            //    //將購物車內物品依序讀取
            //    foreach (var ShoppingCartItem in customerShoppingCart.buyBook.OrderBy(x => x.Name))
            //    {
            //        //將價格依序累計
            //        SubTotal += ShoppingCartItem.SalePrice;

            //        //將數量減1
            //        ShoppingCartItem.Quantity = ShoppingCartItem.Quantity - 1;

            //        //數量為0的移除 list
            //        if (ShoppingCartItem.Quantity == 0)
            //        {
            //            customerShoppingCart.buyBook.Remove(ShoppingCartItem);
            //        }

            //        //判斷 書名是否一樣
            //        if (ShoppingCartItem.Name != LastBookName)
            //        {
            //            LastBookName = ShoppingCartItem.Name;
            //            BookCout++;
            //        }
            //    }

            //    SumTotlal += SubTotal * GetDiscount(BookCout);
            //}

            //customerShoppingCart.GrossPrice = SumTotlal;
        }

        private decimal GetDiscount(int bookCout)
        {
            return _discount[bookCout];
        }

        /// <summary>
        /// 折扣
        /// </summary>
        private Dictionary<int, decimal> _discount = new Dictionary<int, decimal>()
        {
            {0, 0},
            {1, 1},
            {2, 0.95m},
            {3, 0.9m},
            {4, 0.8m },
            {5, 0.75m },
        };
    }
}