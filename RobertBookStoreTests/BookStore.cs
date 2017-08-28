using System;
using System.Collections.Generic;

namespace RobertBookStore.Tests
{
    internal class BookStore
    {
        public BookStore()
        {
            List<Book> bookList = new List<Book>()
            {
                new Book{ Name = "哈利波特一" , SalePrice=100 , Stock=1000},
                new Book{ Name = "哈利波特二" , SalePrice=100 , Stock=1000},
                new Book{ Name = "哈利波特三" , SalePrice=100 , Stock=1000},
                new Book{ Name = "哈利波特四" , SalePrice=100 , Stock=1000},
                new Book{ Name = "哈利波特五" , SalePrice=100 , Stock=1000}
            };
            
        }

        internal void ShoppingCartCalculation(List<ShoppingCart> customerShoppingCart)
        {
            throw new NotImplementedException();
        }
    }
}