using MVC_Assigment.Data;
using MVC_Assigment.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Assigment.Controllers
{
    public class ShoppingCartController : Controller
    {
        private MyDbContext db = new MyDbContext();
        private const string ShoppingCartSessionName = "SHOPPING_CART";
        // GET: ShoppingCart
        public ActionResult ShowCart()
        {
            return View(GetShoppingCart());
        }

        public ActionResult AddToCart(int productId, int quantity = 1)
        {
            var existProd = db.Products.FirstOrDefault(p => p.ProdId == productId);
            if (existProd == null)
            {
                return new HttpNotFoundResult();
            }
            var cart = GetShoppingCart();
            cart.Add(existProd, quantity);
            SetShoppingCart(cart);
            return RedirectToAction("ShowCart", "ShoppingCart");
        }

        public ActionResult UpdateCart(int productId, int quantity)
        {
            var existProd = db.Products.FirstOrDefault(p => p.ProdId == productId);
            if (existProd == null)
            {
                return new HttpNotFoundResult();
            }
            var cart = GetShoppingCart();
            cart.Update(productId, quantity);
            SetShoppingCart(cart);
            return RedirectToAction("ShowCart", "ShoppingCart");
        }
        public ActionResult RemoveCartItem(int productId)
        {
            Debug.WriteLine(productId);
            var cart = GetShoppingCart();
            cart.Remove(productId);
            SetShoppingCart(cart);
            return RedirectToAction("ShowCart", "ShoppingCart");
        }
        public ActionResult RemoveAll()
        {
            ClearShoppingCart();
            return RedirectToAction("ShowCart", "ShoppingCart");
        }

        private Cart GetShoppingCart()
        {
            Cart cart = null;
            if (Session[ShoppingCartSessionName] != null)
            {
                try
                {
                    cart = Session[ShoppingCartSessionName] as Cart;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            else
            {
                cart = new Cart();
            }
            return cart;
        }

        private void SetShoppingCart(Cart cart)
        {
            Session[ShoppingCartSessionName] = cart;
        }

        private void ClearShoppingCart()
        {
            Session[ShoppingCartSessionName] = null;
        }
    }
}