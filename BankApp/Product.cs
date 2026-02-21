namespace BankApp
{
    public class Product
    {
        public string SKU { get; set; } //Stock Keeping Unit
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Product(string sku, string name, decimal price, int quantity) : this()
        {
            SKU = sku;
            Name = name;
            Price = price;
            Quantity = quantity;
        }
        public Product()
        {

        }


    }
}