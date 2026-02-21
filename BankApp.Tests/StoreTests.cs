using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp.Tests
{
    public class StoreTests
    {
        [Fact]
        public void AddProduct_WithPositiveQuantity_AddsProduct()
        {
            var store = new Store("TestStore", "TestLocation");
            var product = new Product { SKU = "SKU1", Name = "Apple", Quantity = 5 };

            store.AddProduct(product);

            var stored = store.GetProduct("SKU1");
            Assert.Equal("Apple", stored.Name);
            Assert.Equal(5, stored.Quantity);
            Assert.Equal(5, store.GetTotalQuantity());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-3)]
        public void AddProduct_WithNonPositiveQuantity_ThrowsArgumentException(int qty)
        {
            var store = new Store("TestStore", "TestLocation");
            var product = new Product { SKU = "SKU2", Name = "Orange", Quantity = qty };

            var ex = Assert.Throws<ArgumentException>(() => store.AddProduct(product));
            Assert.Contains("quantity", ex.Message, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void AddProduct_SameSkuSameName_IncreasesQuantity()
        {
            var store = new Store("TestStore", "TestLocation");
            var p1 = new Product { SKU = "SKU3", Name = "Banana", Quantity = 3 };
            var p2 = new Product { SKU = "SKU3", Name = "Banana", Quantity = 2 };

            store.AddProduct(p1);
            store.AddProduct(p2);

            var stored = store.GetProduct("SKU3");
            Assert.Equal(1, store.GetProducts().Count);
            Assert.Equal(5, stored.Quantity);
            Assert.Equal(5, store.GetTotalQuantity());
        }

        [Fact]
        public void AddProduct_SameSkuDifferentName_ThrowsInvalidOperationException()
        {
            var store = new Store("TestStore", "TestLocation");
            var p1 = new Product { SKU = "SKU4", Name = "Grapes", Quantity = 1 };
            var p2 = new Product { SKU = "SKU4", Name = "Green Grapes", Quantity = 1 };

            store.AddProduct(p1);
            Assert.Throws<InvalidOperationException>(() => store.AddProduct(p2));
        }


        [Fact]
        public void GetTotalQuantity_WithMultipleProducts_ReturnsSumIncludingMergedQuantities()
        {
            var store = new Store("SumStore", "Somewhere");
            store.AddProduct(new Product { SKU = "A1", Name = "ItemA", Quantity = 2 });
            store.AddProduct(new Product { SKU = "B1", Name = "ItemB", Quantity = 3 });
            // Adding same SKU again should merge quantity
            store.AddProduct(new Product { SKU = "A1", Name = "ItemA", Quantity = 1 });

            // Expected total = 2 + 3 + 1 (merged into A1) = 6
            Assert.Equal(6, store.GetTotalQuantity());
        }
    }
}
