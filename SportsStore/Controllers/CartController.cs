using System.Linq;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class CartController : Controller
    {
        private ApplicationDbContext _context;
        private Cart _cart;

        public CartController(ApplicationDbContext context, Cart cartSerivse)
        {
            _context = context;
            _cart = cartSerivse;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = _cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToActionResult AddToCart(int productId, string returnUrl)
        {
            Product product = _context.Products
                .FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                _cart.AddItem(product, 1);
            }

            return RedirectToAction("Index", new {returnUrl});
        }
        // public RedirectToActionResult RemoveFromCart(int productId, string re)
        private Cart GetCart()
        {
            // Cart cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            var raw = HttpContext.Session.GetString("Cart");
            var cart = raw == null ? new Cart(): JsonConvert.DeserializeObject<Cart>(raw);
            return cart;
        }

        private void SaveCart(Cart cart)
        {
            // HttpContext.Session.SetJson("Cart", cart);
            HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart));
        }
    }
}