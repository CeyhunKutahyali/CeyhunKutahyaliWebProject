using CeyhunKutahyaliWebProject.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CeyhunKutahyaliWebProject.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            Product product = new Product();
            return View(product.GetList_Product());
        }

        public ActionResult ProductEdit()
        {
            Product product = new Product();
            ProductDTO productDTO = new ProductDTO();
            productDTO.products = product.GetList_Product();
            return View(productDTO);
        }

        public ActionResult EditInformationProduct()
        {
            Product product = new Product();
            ProductDTO productDTO = new ProductDTO();
            productDTO.products = product.GetList_Product();
            return View(productDTO);
        }


        [HttpPost]
        public ActionResult Add(string productName, string productFeature, string productPicture)
        {
            Product product = new Product
            {
                ProductName = productName,
                ProductFeature = productFeature,
                ProductPicture = productPicture
            };

            if (product.ProductAdd())
            {
                return RedirectToAction("ProductEdit", "Product");
            }
            else
            {
                return RedirectToAction("ProductEdit", "Product");
            }
        }

        [HttpPost]
        public void DeleteProduct(int id)
        {
            Product product = new Product();
            product.id = id;
            product.Delete();
        }


        [HttpPost]
        public ActionResult ProductUpdate(int id, string productName, string productFeature, string productPicture)
        {
            Product product = new Product();

            product.id = id;
            product.ProductName = productName;
            product.ProductFeature = productFeature;
            product.ProductPicture = productPicture;
            product.UpdateProduct();
            //ViewBag.Message = "Güncelleme Başarılı";
            return RedirectToAction("ProductEdit", "Product");
        }


    }
}