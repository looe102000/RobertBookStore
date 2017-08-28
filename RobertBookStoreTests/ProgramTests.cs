using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;

namespace RobertBookStore.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void 單一一本書時單價100()
        {
            //arrange
            var target = new BookStore();
            var CustomerShoppingCart = new ShoppingCart
            {
                buyBookProduct = new List<Book>
                {
                    new Book{ Name = "哈利波特一" , Quantity=1 ,SalePrice= 100} 
                }
            };

            target.ShoppingCartCalculation(CustomerShoppingCart);

            //assert
            var expected = 100;

            Assert.AreEqual(expected, CustomerShoppingCart.GrossPrice);
        }

        [TestMethod()]
        public void 兩本書時要要折扣()
        {
            //arrange
            var target = new BookStore();
            var CustomerShoppingCart = new ShoppingCart
            {
                buyBookProduct = new List<Book>
                {
                    new Book{ Name = "哈利波特一" , Quantity=1 ,SalePrice= 100},
                    new Book{ Name = "哈利波特一" , Quantity=1 ,SalePrice= 100}
                }
            };

            target.ShoppingCartCalculation(CustomerShoppingCart);

            //assert
            var expected = 190;

            Assert.AreEqual(expected, CustomerShoppingCart.GrossPrice);
        }
    }
}