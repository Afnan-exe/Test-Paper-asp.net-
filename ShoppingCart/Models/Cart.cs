namespace ShoppingCart.Models
{
    public class Cart
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public double Total
                {
                    get { return Quantity * Price; }
                }

        public string Image { get; set; }

        public Cart(Products product)
                {
           
                    ProductId = product.ProductId;
                    ProductName = product.Pname;
                    Price = product.Price;
                    Quantity = 1;
                    Image = product.Pimage;
        }


    }
}
