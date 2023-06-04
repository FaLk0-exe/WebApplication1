using Microsoft.AspNetCore.Mvc;
using Pharm.DLL.Repositories;
using System.Text.Json;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CartController : Controller
    {
        public ActionResult Add([FromServices] ProductRep productRep, int id)
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
    }
}
