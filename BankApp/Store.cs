using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp
{
    public class Store
    {
        public string Name { get; set; }
        public string Location { get; set; }
        private List<Product> products;

        public Store(string name, string location)
        {
            Name = name;
            Location = location;
            products = new List<Product>();

        }



        public void AddProduct(Product product)
        {
            if (product.Quantity <= 0)
            {
                throw new ArgumentException("Product quantity must be greater than zero.");
            }
            if (products.Any(p => p.SKU == product.SKU))
            {
                var existingProduct = products.First(p => p.SKU == product.SKU);
                if (existingProduct.Name != product.Name)
                {
                    throw new InvalidOperationException("A product with the same SKU but a different name already exists.");
                }
                existingProduct.Quantity += product.Quantity;
            }
            else
            {
                products.Add(product);
            }
        }


        public void RemoveProduct(Product product)
        {
            products.Remove(product);
        }


        public List<Product> GetProducts()
        {
            return products;
        }


        public Product GetProduct(string sku)
        {
            return products.First(p => p.SKU == sku);
        }


        public int GetTotalQuantity()
        {
            return products.Sum(p => p.Quantity);
        }

    }
}
