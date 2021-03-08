using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuieroPizza.BL
{
    public class OrdenesBL
    {
        Contexto _contexto;
        public List<Orden> ListadeOrdenes { get; set; }

        public OrdenesBL()
        {
            _contexto = new Contexto();
            ListadeOrdenes = new List<Orden>();
        }
        public List<Orden> ObtenerOrdenes()
        {
            ListadeOrdenes = _contexto.Ordenes
                .Include("Cliente")
                .ToList();
            return ListadeOrdenes;
        }
        public List<OrdenDetalle> ObtenerOrdenDetalle( int ordenId)
        {
            var listadeOrdenesDetalle = _contexto.OrdenDetalle
                .Include("Producto")
                .Where(o => o.Ordenid == ordenId).ToList();

            return listadeOrdenesDetalle;
        }

        public Orden ObtenerOrden(int id)
        {
            var orden = _contexto.Ordenes
                .Include ("Cliente").FirstOrDefault(p => p.id == id);
            return orden;
        }
        public void GuardarOrden(Orden orden)
        {
            if (orden.id == 0)
            {
                _contexto.Ordenes.Add(orden);
            }
            else
            {
                var ordenExistente = _contexto.Ordenes.Find(orden.id);
                ordenExistente.Clienteid = orden.Clienteid;
                ordenExistente.Activo = orden.Activo;
            }

            _contexto.SaveChanges();

            }

        public void GuardarOrdenDetalle(OrdenDetalle ordenDetalle)
        {
            var producto = _contexto.Productos.Find(ordenDetalle.Productoid);

            ordenDetalle.Precio = producto.Precio;
            ordenDetalle.Total = ordenDetalle.Cantidad * ordenDetalle.Precio;

            _contexto.OrdenDetalle.Add(ordenDetalle);

            var orden = _contexto.Ordenes.Find(ordenDetalle.Ordenid);
            orden.Total = orden.Total + ordenDetalle.Total;

            _contexto.SaveChanges();
        }

        public OrdenDetalle  ObtenerOrdenDetallePorid(int id)
        {
            var ordenDetalle = _contexto.OrdenDetalle
                  .Include("Producto").FirstOrDefault(p => p.id == id);

            return ordenDetalle;
        }

        public void EliminarOrdenDetalle(int id)
        {
            var ordenDetalle = _contexto.OrdenDetalle.Find(id);
            _contexto.OrdenDetalle.Remove(ordenDetalle);

            var orden = _contexto.Ordenes.Find(ordenDetalle.Ordenid);
            orden.Total = orden.Total - ordenDetalle.Total;

            _contexto.SaveChanges();
        }

       
    }
}
