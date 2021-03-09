using QuieroPizza.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuieroPiza.WebAdmin.Controllers
{
    public class OrdenDetalleController : Controller
    {
        OrdenesBL _ordenBL;
        ProductosBL _productosBL;
        public OrdenDetalleController()
        {
            _ordenBL = new OrdenesBL();
            _productosBL = new ProductosBL();
        }
        // GET: OrdenesDetalle
        public ActionResult Index(int id)
        {
            var orden = _ordenBL.ObtenerOrden(id);
            orden.ListadeOrdenDetalle = _ordenBL.ObtenerOrdenDetalle(id);

            return View(orden);
        }

        public ActionResult Crear(int id)
        {
            var nuevaOrdenDetalle = new OrdenDetalle();
            nuevaOrdenDetalle.Ordenid = id;

            var productos = _productosBL.ObtenerProductosActivos();
            ViewBag.ProductoId = new SelectList(productos, "Id", "Descripcion");

            return View(nuevaOrdenDetalle);

        }

        [HttpPost]
        public ActionResult Crear(OrdenDetalle ordenDetalle)
        {
            if (ModelState.IsValid)
            {
                if (ordenDetalle.Productoid == 0)
                {
                    ModelState.AddModelError("Productoid", "Seleccione un producto");

                    return View(ordenDetalle);
                }
                _ordenBL.GuardarOrdenDetalle(ordenDetalle);
                    return RedirectToAction("Index", new { id  = ordenDetalle.Ordenid} );
            }
               

            var productos = _productosBL.ObtenerProductosActivos();
            ViewBag.ProductoId = new SelectList(productos, "Id", "Descripcion");
            return View(ordenDetalle);
        }

        public ActionResult Eliminar(int id)
        {
            var ordenDetalle = _ordenBL.ObtenerOrdenDetallePorid(id);

            return View(ordenDetalle);
        }

        [HttpPost]
        public ActionResult Eliminar(OrdenDetalle ordenDetalle)
        {
            _ordenBL.EliminarOrdenDetalle(ordenDetalle.id);

            return RedirectToAction("Index", new { id = ordenDetalle.Ordenid });
        }
    }
}