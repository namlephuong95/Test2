using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;

namespace MVC_Assigment.Models
{
    public class Cart
    {
        public Dictionary<int, CartItem> Items { get; set; }
        public double TotalPrice => Items.Values.Sum(items=>items.TotalItemPrice);
        public int TotalQuantity => Items.Count();

        public Cart()
        {
            Items = new Dictionary<int, CartItem>();
        }

        public void Add(Product product, int quantity = 1)
        {
            var exitsKey = Items.ContainsKey(product.ProdId);
            if (exitsKey)
            {
                Items[product.ProdId].Quantity += quantity;
            }
            else
            {
                var cartItem = new CartItem()
                {
                    ProductId = product.ProdId,
                    ProductCode = product.ProdCode,
                    ProductName = product.ProdName,
                    ProductPrice = product.ProdPrice,
                    ProductDescription = product.ProdDescription,
                    ProductThumbnail = product.ProdThumbnail,
                    Quantity = quantity
                };
                Items.Add(product.ProdId, cartItem);
            }
        }
        public void Update(int id, int quantity)
        {
            var exitsKey = Items.ContainsKey(id);
            if (exitsKey)
            {
                Items[id].Quantity = quantity;
            }
        }
        public void Remove(int id)
        {
            if (Items.ContainsKey(id))
            {
                Items.Remove(id);
            }
        }
        public void Clear()
        {
            Items.Clear();
        }

    }

    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public string ProductThumbnail { get; set; }
        public double TotalItemPrice => ProductPrice * Quantity;
        public int Quantity { get; set; }
    }
}