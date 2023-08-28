using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QVision_Task.Models;
using QVision_Task.Repository;

namespace QVision_Task.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        IproductRepository prodRepo;

        public ProductController(IproductRepository _prodRepo)
        {
            this.prodRepo = _prodRepo;
        }

        public IActionResult AllProducts()
        {
            List<Product> products = prodRepo.GetAll();
            return View(products);
        }

        public IActionResult ProductDetails(int id)
        {
            Product product = prodRepo.GetById(id);
            return View(product);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (ModelState.IsValid == true)
            {
                try
                {
                    prodRepo.AddProduct(product);
                    prodRepo.Save();
                    return RedirectToAction("AllProducts");
                }
                catch (Exception ex) { ModelState.AddModelError("ExpirationDate", "Please Select Valid Expiration Date"); };
            }
            return View();
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            Product product = prodRepo.GetById(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            if (ModelState.IsValid == true) {

                try
                {
                    prodRepo.UpdateProduct(product, product.Id);

                    prodRepo.Save();
                    return RedirectToAction("AllProducts");
                }
                catch (Exception ex) { ModelState.AddModelError("ExpirationDate", "Please Select Valid Expiration Date"); };
            }
            return View(product);
        }
        

        public IActionResult DeleteProduct(int Id, bool Submit)
        {
            if (Submit == true)
            {
                prodRepo.DeleteProduct(Id);
                prodRepo.Save();
                return RedirectToAction("AllProducts");
            }
            return View("AllProducts");
        }
    }
}