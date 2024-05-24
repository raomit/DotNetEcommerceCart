using EcommCart.Models;
using EcommCart.Models.CustomModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EcommCart.Controllers
{
    public class ProductController : Controller
    {
        private static readonly MitRaoEntities1 _Db;

        static ProductController(){
            _Db = new MitRaoEntities1();
        }

        public ActionResult GetGuestCart()
        {
            return View();
        }

        public ActionResult GetPagedProducts(PagedProductsParams ProductParams)
        {
            if (ProductParams.search.value == null)
            {
                List<Product> products = _Db.Products.OrderBy(product => product.product_id).Skip(ProductParams.start).Take(ProductParams.length).ToList();
                var PagedProducts = JsonConvert.SerializeObject(new
                {
                    draw = ProductParams.draw,
                    recordsTotal = _Db.Products.Count(),
                    recordsFiltered = _Db.Products.Count(),
                    data = products
                }, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    DateFormatString = "yyyy-mm-dd"
                });

                return Content(PagedProducts, "application/json");
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
        }
    }
}