using Microsoft.AspNetCore.Mvc;
using Pharm.DAL.entity;
using Pharm.DLL.Interfaces;
using Pharm.DLL.Services;
using WebApplication1.VM;

namespace WebApplication1.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Get([FromServices] IUserRepository userRepository)
        {
            return View(userRepository.GetAllUsers());
        }

    }
}
