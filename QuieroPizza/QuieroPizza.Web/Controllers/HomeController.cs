using QuieroPizza.BL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuieroPizza.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var productoBL = new ProductosBL();

            var listadeProductos = productoBL.ObtenerProductos();

            ViewBag.adminWebsiteUrl = 
                ConfigurationManager.AppSettings["adminWebsiteUrl"];


            return View(listadeProductos);
        }
    }
}