using System.Collections.Generic;
using System.Linq;

namespace RobertBookStore
{
    public class BookStore
    {
        //public List<Book> BookList { get; set; }

        public BookStore()
        {
            //不做庫存檢查
            //BookList = new List<Book>()
            //{
            //    new Book{ Name = "哈利波特一" , SalePrice=100 },
            //    new Book{ Name = "哈利波特二" , SalePrice=100 },
            //    new Book{ Name = "哈利波特三" , SalePrice=100 },
            //    new Book{ Name = "哈利波特四" , SalePrice=100 },
            //    new Book{ Name = "哈利波特五" , SalePrice=100 }
            //};

        }

        public void ShoppingCartCalculation(ShoppingCart customerShoppingCart)
        {
            var total = 0d;

            //將購物車內物品依序讀取
            foreach (var ShoppingCartItem in customerShoppingCart.buyBook.OrderBy(x=>x.Name))
            {
                total += ShoppingCartItem.Quantity * ShoppingCartItem.SalePrice;

                ////與庫存做比較
                //foreach(var bookItem in BookList)
                //{
                //    if(ShoppingCartItem.ProductItem == bookItem.Name)
                //    {
                //        total += ShoppingCartItem.Quantity * bookItem.SalePrice;
                //    }
                //}
            }

            if(customerShoppingCart.buyBook.Count == 2)
            {
                total = total * 0.95d;
            }
            else if(customerShoppingCart.buyBook.Count == 3)
            {
                total = total * 0.9d;
            }
            else if (customerShoppingCart.buyBook.Count == 4)
            {
                total = total * 0.8d;
            }
            else if (customerShoppingCart.buyBook.Count >= 5)
            {
                total = total * 0.75d;
            }

            customerShoppingCart.GrossPrice = total;
        }
    }
}