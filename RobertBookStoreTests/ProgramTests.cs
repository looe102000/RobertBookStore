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
                buyBook = new List<Book>
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
        public void 兩本書時要有九五折()
        {
            //arrange
            var target = new BookStore();
            var CustomerShoppingCart = new ShoppingCart
            {
                buyBook = new List<Book>
                {
                    new Book{ Name = "哈利波特一" , Quantity=1 ,SalePrice= 100},
                    new Book{ Name = "哈利波特二" , Quantity=1 ,SalePrice= 100}
                }
            };

            target.ShoppingCartCalculation(CustomerShoppingCart);

            //assert
            var expected = 190;

            Assert.AreEqual(expected, CustomerShoppingCart.GrossPrice);
        }

        [TestMethod()]
        public void 三本書時要有九折()
        {
            //arrange
            var target = new BookStore();
            var CustomerShoppingCart = new ShoppingCart
            {
                buyBook = new List<Book>
                {
                    new Book{ Name = "哈利波特一" , Quantity=1 ,SalePrice= 100},
                    new Book{ Name = "哈利波特二" , Quantity=1 ,SalePrice= 100},
                    new Book{ Name = "哈利波特三" , Quantity=1 ,SalePrice= 100}
                }
            };

            target.ShoppingCartCalculation(CustomerShoppingCart);

            //assert
            var expected = 270;

            Assert.AreEqual(expected, CustomerShoppingCart.GrossPrice);
        }

        [TestMethod()]
        public void 四本書時要有八折()
        {
            //arrange
            var target = new BookStore();
            var CustomerShoppingCart = new ShoppingCart
            {
                buyBook = new List<Book>
                {
                    new Book{ Name = "哈利波特一" , Quantity=1 ,SalePrice= 100},
                    new Book{ Name = "哈利波特二" , Quantity=1 ,SalePrice= 100},
                    new Book{ Name = "哈利波特三" , Quantity=1 ,SalePrice= 100},
                    new Book{ Name = "哈利波特四" , Quantity=1 ,SalePrice= 100}
                }
            };

            target.ShoppingCartCalculation(CustomerShoppingCart);

            //assert
            var expected = 320;

            Assert.AreEqual(expected, CustomerShoppingCart.GrossPrice);
        }

        [TestMethod()]
        public void 五本書時要有七五折()
        {
            //arrange
            var target = new BookStore();
            var CustomerShoppingCart = new ShoppingCart
            {
                buyBook = new List<Book>
                {
                    new Book{ Name = "哈利波特一" , Quantity=2 ,SalePrice= 100},
                    new Book{ Name = "哈利波特二" , Quantity=2 ,SalePrice= 100},
                    new Book{ Name = "哈利波特三" , Quantity=2 ,SalePrice= 100},
                    new Book{ Name = "哈利波特四" , Quantity=2 ,SalePrice= 100},
                    new Book{ Name = "哈利波特五" , Quantity=2 ,SalePrice= 100}
                }
            };

            target.ShoppingCartCalculation(CustomerShoppingCart);

            //assert
            var expected = 750;

            Assert.AreEqual(expected, CustomerShoppingCart.GrossPrice);
        }

        [TestMethod()]
        public void 一二集各買了一本_第三集買了兩本()
        {
            //arrange
            var target = new BookStore();
            var CustomerShoppingCart = new ShoppingCart
            {
                buyBook = new List<Book>
                {
                    new Book{ Name = "哈利波特一" , Quantity=1 ,SalePrice= 100},
                    new Book{ Name = "哈利波特二" , Quantity=1 ,SalePrice= 100},
                    new Book{ Name = "哈利波特三" , Quantity=2 ,SalePrice= 100}
                }
            };

            target.ShoppingCartCalculation(CustomerShoppingCart);

            //assert
            var expected = 370;

            Assert.AreEqual(expected, CustomerShoppingCart.GrossPrice);
        }

        [TestMethod()]
        public void 第一集買了一本_第二三集各買了兩本()
        {
            //arrange
            var target = new BookStore();
            var CustomerShoppingCart = new ShoppingCart
            {
                buyBook = new List<Book>
                {
                    new Book{ Name = "哈利波特一" , Quantity=1 ,SalePrice= 100},
                    new Book{ Name = "哈利波特二" , Quantity=2 ,SalePrice= 100},
                    new Book{ Name = "哈利波特三" , Quantity=2 ,SalePrice= 100}
                }
            };

            target.ShoppingCartCalculation(CustomerShoppingCart);

            //assert
            var expected = 460;

            Assert.AreEqual(expected, CustomerShoppingCart.GrossPrice);
        }

        [TestMethod()]
        public void 第一二三集各買了兩本_四五共買一本_最便宜算法()
        {
            //arrange
            var target = new BookStore();
            var CustomerShoppingCart = new ShoppingCart
            {
                buyBook = new List<Book>
                {
                    new Book{ Name = "哈利波特一" , Quantity=2 ,SalePrice= 100},
                    new Book{ Name = "哈利波特二" , Quantity=2 ,SalePrice= 100},
                    new Book{ Name = "哈利波特三" , Quantity=2 ,SalePrice= 100},
                    new Book{ Name = "哈利波特四" , Quantity=1 ,SalePrice= 100},
                    new Book{ Name = "哈利波特五" , Quantity=1 ,SalePrice= 100},

                }
            };

            target.ShoppingCartCalculation(CustomerShoppingCart);

            //assert
            var expected = 640;

            Assert.AreEqual(expected, CustomerShoppingCart.GrossPrice);
        }
        [TestMethod()]
        public void 第一二三四集各買了兩本_五共買一本_最便宜算法()
        {
            //arrange
            var target = new BookStore();
            var CustomerShoppingCart = new ShoppingCart
            {
                buyBook = new List<Book>
                {
                    new Book{ Name = "哈利波特一" , Quantity=2 ,SalePrice= 100},
                    new Book{ Name = "哈利波特二" , Quantity=2 ,SalePrice= 100},
                    new Book{ Name = "哈利波特三" , Quantity=2 ,SalePrice= 100},
                    new Book{ Name = "哈利波特四" , Quantity=2 ,SalePrice= 100},
                    new Book{ Name = "哈利波特五" , Quantity=1 ,SalePrice= 100},

                }
            };

            target.ShoppingCartCalculation(CustomerShoppingCart);

            //assert
            var expected = 695;

            Assert.AreEqual(expected, CustomerShoppingCart.GrossPrice);
        }
        [TestMethod()]
        public void 第一二三集各買了四本_四五共買二本_最便宜算法()
        {
            //arrange
            var target = new BookStore();
            var CustomerShoppingCart = new ShoppingCart
            {
                buyBook = new List<Book>
                {
                    new Book{ Name = "哈利波特一" , Quantity=4 ,SalePrice= 100},
                    new Book{ Name = "哈利波特二" , Quantity=4 ,SalePrice= 100},
                    new Book{ Name = "哈利波特三" , Quantity=4 ,SalePrice= 100},
                    new Book{ Name = "哈利波特四" , Quantity=2 ,SalePrice= 100},
                    new Book{ Name = "哈利波特五" , Quantity=2 ,SalePrice= 100},

                }
            };

            target.ShoppingCartCalculation(CustomerShoppingCart);

            //assert
            var expected = 1280;

            Assert.AreEqual(expected, CustomerShoppingCart.GrossPrice);
        }
    }
}