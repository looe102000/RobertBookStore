using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobertBookStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            var CustomerShoppingCart = new List<ShoppingCart>
            {
                new ShoppingCart{ProductItem="哈利波特一",Quantity=1}
            };

            target.ShoppingCartCalculation(CustomerShoppingCart);

            //assert
            var expected = 100;

            Assert.AreEqual(expected, CustomerShoppingCart[0].Quantity);
        }
    }
}