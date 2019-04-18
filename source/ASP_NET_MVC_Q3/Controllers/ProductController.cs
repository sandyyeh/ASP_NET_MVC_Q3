using ASP_NET_MVC_Q3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_NET_MVC_Q3.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult List()
        {
            List<Product> source = Product.Data; 
            return View(source);
        }

    }
}