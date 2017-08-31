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
            var BookQuerytotal = 0;
            var bookIndex = 0;

            List<Book> booklist = GetBookList(customerShoppingCart);

            List<decimal> payPriceList = new List<decimal>();

            //先將書籍依序讀出
            foreach (var discount_item in _discount)
            {
                BookQuerytotal = booklist.Count();
                bookIndex = 0;

                List<decimal> payPriceSalePriceList = new List<decimal>();

                //先將書籍依序讀出
                foreach (var PayBook in booklist.Select((value, index) => new { index, value }))
                {
                    BookCout++;
                    for (int i = PayBook.index - 1; i > bookIndex; i--)
                    {
                        ////判斷 書名是否一樣
                        if (PayBook.value.Name == booklist[i].Name)
                        {
                            //LastBookName = PayBook.value.Name;
                            BookCout--;
                        }
                    }

                    SubTotal += PayBook.value.SalePrice;

                    if (BookQuerytotal >= discount_item.Key)
                    {
                        if (BookCout == discount_item.Key)
                        {
                            payPriceSalePriceList.Add(SubTotal * GetDiscount(BookCout));
                            BookQuerytotal = BookQuerytotal - BookCout;
                            bookIndex = PayBook.index;

                            SubTotal = 0;
                            BookCout = 0;
                        }
                    }
                    else
                    {
                        if (BookCout == (discount_item.Key - 1))
                        {
                            payPriceSalePriceList.Add(SubTotal * GetDiscount(BookCout));
                            BookQuerytotal = BookQuerytotal - BookCout;

                            bookIndex = PayBook.index;
                            SubTotal = 0;
                            BookCout = 0;
                        }
                    }

                    if (PayBook.index == booklist.Count - 1)
                    {
                        payPriceSalePriceList.Add(SubTotal);
                    }
                }

                payPriceList.Add(payPriceSalePriceList.Sum());

                SubTotal = 0;
                BookCout = 0;
            }

            customerShoppingCart.GrossPrice = payPriceList.Where(x => x > 0).Min();
        }

        /// <summary>
        /// 將書順序整理
        /// </summary>
        /// <param name="customerShoppingCart"></param>
        /// <returns></returns>
        private static List<Book> GetBookList(ShoppingCart customerShoppingCart)
        {
            var MAX_BookQuantity = customerShoppingCart.buyBook.Max(x => x.Quantity);
            List<Book> booklist = new List<Book>();
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

            return booklist;
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
            {1, 1},
            {2, 0.95m},
            {3, 0.9m},
            {4, 0.8m },
            {5, 0.75m },
        };
    }
}