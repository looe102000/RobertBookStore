using System.Collections.Generic;

namespace RobertBookStore
{
    public class BookStore
    {
        public List<Book> BookList { get; set; }

        public BookStore()
        {
            BookList = new List<Book>()
            {
                new Book{ Name = "哈利波特一" , SalePrice=100 , Stock=1000},
                new Book{ Name = "哈利波特二" , SalePrice=100 , Stock=1000},
                new Book{ Name = "哈利波特三" , SalePrice=100 , Stock=1000},
                new Book{ Name = "哈利波特四" , SalePrice=100 , Stock=1000},
                new Book{ Name = "哈利波特五" , SalePrice=100 , Stock=1000}
            };

        }

        public void ShoppingCartCalculation(ShoppingCart customerShoppingCart)
        {
            var total = 0;
            foreach (var ShoppingCartItem in customerShoppingCart.buyBookProduct)
            {
                foreach(var bookItem in BookList)
                {
                    if(ShoppingCartItem.ProductItem == bookItem.Name)
                    {
                        total += ShoppingCartItem.Quantity * bookItem.SalePrice;
                    }
                }
            }
            customerShoppingCart.GrossPrice = total;
        }
    }
}