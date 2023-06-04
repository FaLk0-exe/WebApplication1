using Microsoft.AspNetCore.Mvc;
using Pharm.DAL.entity;
using Pharm.DLL.Interfaces;
using Pharm.DLL.Services;
using WebApplication1.VM;

namespace WebApplication1.Controllers
{

    public class ProductController:Controller   
    {
        public ActionResult Get([FromServices] IProductRepository productRepository)
        {
            return View(productRepository.GetAllProducts());
        }

        public ActionResult List([FromServices] IProductRepository productRepository)
        {
            return View(productRepository.GetAllProducts());
        }

        public ActionResult Create(int id)
        {
            return View();
        }

        public ActionResult CreateProduct([FromServices] ProductService productService, ProductVM model)
        {
            try
            {
                productService.CreateProduct(model.CreateProduct());
                return Redirect("Get");
            }
            catch (ArgumentException ex)
            {
                ViewData["Exception"] = ex.Message;
                return View("Create");
            }
        }

        public ActionResult Toggle([FromServices] IProductRepository productRepository,[FromServices] ProductService productService, int id)
        {
            var product = productRepository.GetProduct(id);
            if (product is null)
                return NotFound();
            product.IsActive = !product.IsActive;
            productService.EditProduct(product);
                return Redirect("/product/get");
        }

        public ActionResult Update([FromServices] IProductRepository productRepository, [FromServices] ProductService productService, int id)
        {
            try
            {
                var product = productRepository.GetProduct(id);
                if (product is null)
                {
                    return Redirect("/product/get");
                }
                return View(product);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "There was an error when the product was updated.";
                return View("Error");
            }
        }

        public ActionResult UpdateProduct([FromServices] ProductService productService, Product model)
        {
            try
            {
                productService.EditProduct(model);
                return Redirect("/product/get");
            }
            catch (Exception ex)
            {
                ViewData["Exception"] = ex.Message;
                return View("Error");
            }
        }
        
    }
}
