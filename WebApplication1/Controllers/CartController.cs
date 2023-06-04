using Microsoft.AspNetCore.Mvc;
using Pharm.DAL.entity;
using Pharm.DLL.Interfaces;
using Pharm.DLL.Repositories;
using System.Text.Json;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CartController : Controller
    {
        public ActionResult Add([FromServices] IProductRepository productRep, int id)
        {
            List<CartItem> items;
            var product = productRep.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            if (HttpContext.Session.GetString("cart") == null)
                items = new List<CartItem>();
            else
            {
                items = JsonSerializer.Deserialize<List<CartItem>>(HttpContext.Session.GetString("cart"));
            }
            var item = items.FirstOrDefault(s => s.Id == product.Id);
            if(item==null)
            {
                items.Add(new CartItem()
                {
                    Id=product.Id,
                    Price=product.Price,
                    Count=1,
                    Title = product.Pname
                });
            }
            else
            {
                item.Count++;
            }
            HttpContext.Session.SetInt32("count", items.Count());
            HttpContext.Session.SetString("cart", JsonSerializer.Serialize(items));
            return Redirect("/product/get");
        }

        public ActionResult Get()
        {
            List<CartItem> items;
            if (HttpContext.Session.GetString("cart") == null)
                items = new List<CartItem>();
            else
            {
                items = JsonSerializer.Deserialize<List<CartItem>>(HttpContext.Session.GetString("cart"));
            }
            return View(items);
        }

        public ActionResult Increase(int id)
        {
            List<CartItem> cartProducts;
            var cartRaw = HttpContext.Session.GetString("cart");
            cartProducts = JsonSerializer.Deserialize<List<CartItem>>(cartRaw);
            var existedItem = cartProducts.FirstOrDefault(s => s.Id == id);
            existedItem.Count++;
            HttpContext.Session.SetString("cart", JsonSerializer.Serialize(cartProducts));
            HttpContext.Session.SetInt32("count", cartProducts.Count());
            return RedirectToAction(controllerName: "cart", actionName: "get");
        }

        public ActionResult Decrease(int id)
        {
            List<CartItem> cartProducts;
            var cartRaw = HttpContext.Session.GetString("cart");
            cartProducts = JsonSerializer.Deserialize<List<CartItem>>(cartRaw);
            var existedItem = cartProducts.FirstOrDefault(s => s.Id == id);
            if (existedItem.Count != 1)
            {
                existedItem.Count--;
            }
            HttpContext.Session.SetString("cart", JsonSerializer.Serialize(cartProducts));
            HttpContext.Session.SetInt32("count", cartProducts.Count());
            return RedirectToAction(controllerName: "cart", actionName: "get");
        }

        public ActionResult Remove(int id)
        {
            List<CartItem> cartProducts;
            var cartRaw = HttpContext.Session.GetString("cart");
            cartProducts = JsonSerializer.Deserialize<List<CartItem>>(cartRaw);
            var existedItem = cartProducts.FirstOrDefault(s => s.Id == id);
            cartProducts.Remove(existedItem);
            HttpContext.Session.SetString("cart", JsonSerializer.Serialize(cartProducts));
            HttpContext.Session.SetInt32("count", cartProducts.Count());
            return RedirectToAction(controllerName: "cart", actionName: "get");
        }
    }
}
