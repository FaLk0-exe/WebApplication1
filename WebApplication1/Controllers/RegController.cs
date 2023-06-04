using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Pharm.DAL.entity;
using Pharm.DLL.Interfaces;
using Pharm.DLL.Services;
using System.Security.Claims;
using WebApplication1.VM;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Get([FromServices] IUserRepository userRepository)
        {
            return View(userRepository.GetAllUsers());
        }

        public ActionResult Admin()
        {
            var claims =
                    new List<Claim>()
                    {
                        new Claim("Admin","Admin"),
                        new Claim(ClaimTypes.Role,"Admin")
                    };
            var adminClaimsIdentity = new ClaimsIdentity(claims, "AdminIdentity");
            var adminClaimsPrincipal = new ClaimsPrincipal(adminClaimsIdentity);
            HttpContext.SignInAsync(adminClaimsPrincipal);
            return RedirectToAction(controllerName: "Product", actionName: "Get");
        }


    }
}
