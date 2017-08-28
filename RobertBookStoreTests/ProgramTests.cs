using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
                buyBookProduct = new List<Product>
                {
                    new Product{ProductItem="哈利波特一",Quantity=1}
                }
            };

            target.ShoppingCartCalculation(CustomerShoppingCart);

            //assert
            var expected = 100;

            Assert.AreEqual(expected, CustomerShoppingCart.GrossPrice);
        }
    }
}