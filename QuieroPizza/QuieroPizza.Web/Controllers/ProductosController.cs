

using QuieroPizza.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuieroPizza.Web.Controllers
{
    public class ProductosController : Controller
    {
      //Get: Productos
        public ActionResult Index()
        {
            var productoBL = new ProductosBL();

           var listadeProductos = productoBL.ObtenerProductos();

           return View(listadeProductos);

       }
    }
}