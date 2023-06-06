using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Pharm.DAL.entity;
using Pharm.DLL.Interfaces;
using System.Text.Json;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class OrderController:Controller
    {
        public OrderController()
        {
            
        }


        public ActionResult Get([FromServices] IUserOrderRepository userOrderRepository)
        {
            var orders = userOrderRepository.GetAllUserOrders();
            return View(orders);
        }

        public ActionResult Details([FromServices] IProductRepository productRepository,[FromServices] IUserOrderRepository userOrderRepository, [FromServices] IOrderDetailsRepository orderDetailsRepository,int id)
        {
            var order = userOrderRepository.GetUserOrder(id);
            if (order is null)
                return NotFound();
            var items = orderDetailsRepository.GetAllOrderDetails().Where(s => s.UserOrderId == order.Id).ToList();
            return View(new OrderDetailsModel { UserOrder = order, Items = items, Products = productRepository.GetAllProducts() });
        }

        public ActionResult ChangeStatus([FromServices] IUserOrderRepository orderRepository,int customerOrderId,int id)
        {
            var order = orderRepository.GetUserOrder(customerOrderId);
            order.StatusId= id;
            orderRepository.UpdateUserOrder(order);
            return RedirectToAction(controllerName: "Order", actionName: "Details", routeValues: new { id = customerOrderId });
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult TryCreate([FromServices]IOrderDetailsRepository orderDetailsRepository, [FromServices] IUserOrderRepository userOrderRepository, UserOrder order)
        {
            var items = JsonSerializer.Deserialize<List<CartItem>>(HttpContext.Session.GetString("cart"));
            order.OrderDate = DateTime.Now.ToString();
            order.Price = items.Sum(x => x.Price * x.Count);
            order.UserId = 1;
            order.StatusId = 1;
            var id = userOrderRepository.CreateUserOrder(order);
            foreach (var item in items)
            {
                orderDetailsRepository.CreateOrderDetails(
                    new OrderDetail
                    {
                        UserOrderId = id,
                        ProductId = item.Id,
                        Quantity = item.Count,
                        ProductPrice = item.Price,
                        TotalPrice = item.Count * item.Price
                    });
            }
            return RedirectToAction(controllerName: "Order", actionName: "Complete", routeValues: new { id = id });
        }

        public ActionResult Complete(int id) 
        {
            return View(id);
        }
    }
}
