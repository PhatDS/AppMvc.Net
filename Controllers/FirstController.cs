using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
// using ASPMVC.Services;
using System.IO;
using System;

using System.Linq;
using ASPMVC.Services;

namespace ASPMVC.Controllers
{

    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;
        private readonly ProductService _productService;
        public FirstController(ILogger<FirstController> logger, ProductService productService) 
        {
            _logger = logger;
            _productService = productService;
        } 
        public string Index()
        {
            _logger.LogInformation("Index Action");
            return "  Toi la Index cua FirstController";
        }
        public IActionResult Ball()
        {
            string a = @"C:\Users\Phat\Desktop\dotnet\ASPMVC\Files";
            string filePath = Path.Combine(a,"Ball.jpg");
            var bytes = System.IO.File.ReadAllBytes(filePath);
            return File(bytes,"image/jpg");
        }
        public IActionResult Iphoneprice()
        {
            return Json(
                new {
                    productName = "Iphone12",
                    price = 1000
                }
            );
        }
        public  IActionResult Privacy()
        {
            var url = Url.Action("Privacy","Home");
            _logger.LogInformation("chuyen huong den"+url);
            return LocalRedirect(url);
        }
        public  IActionResult Google()
        {
            var url = "https://google.com";
            _logger.LogInformation("chuyen huong den"+url);
            return Redirect(url);
        }

        public IActionResult Readme()
        {
            var content = @"
            Xin chao 
            1234 
            567";
            return Content(content,"text/plain");
        }
        public IActionResult Helloview(string username)
        {
            if( string.IsNullOrEmpty(username))
            {
                username = "Khach";

            }
            // View() -> Razor Engine, doc .cshtml (template)
            //view(template)  ---------- đường dẫn tuyệt đối tới .cshtml
            // view(template,model)----
            // return View("/MyView/xinchao1.cshtml",username);
            // return View("xinchao2",username);
            return View("xinchao3",username);
        }

        [TempData]
        public string StatusMessage {get;set;}

        public IActionResult ViewProduct(int? id)
        {
            var product = _productService.Where(p=>p.Id == id).FirstOrDefault();
            if (product == null)
            {
                // TempData["StatusMessage"] = "San Pham Khong Co";
                StatusMessage = "San Pham Ban Yeu Cau Khong co";
                return Redirect(Url.Action("Index","Home")); // chuyển hướng về trang Index
            }
            
            // return View(product);

            // this.ViewData["product"] = product;
            // ViewData["Title"] = product.Name;
            // return View("ViewProduct2");
            ViewBag.product = product;
            return View("ViewProduct3");
        }

    }

}