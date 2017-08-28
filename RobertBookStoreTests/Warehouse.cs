namespace RobertBookStore.Tests
{
    /// <summary>
    /// 書籍
    /// </summary>
    public class Book
    {
        /// <summary>
        /// 書名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 價格
        /// </summary>
        public int SalePrice { get; set; }

        /// <summary>
        /// 庫存
        /// </summary>
        public int Stock { get; set; }
    }

    /// <summary>
    /// 購物車
    /// </summary>
    public class ShoppingCart
    {
        /// <summary>
        /// 產品項目
        /// </summary>
        public string ProductItem { get; set; }

        /// <summary>
        /// 產品數量
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// 總價
        /// </summary>
        public int GrossPrice { get; set; }
    }
}