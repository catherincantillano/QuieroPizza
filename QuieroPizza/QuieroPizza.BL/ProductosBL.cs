using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuieroPizza.BL
{
    public class ProductosBL
    {
        Contexto _Contexto;
        public List<Producto> ListadeProductos { get; set; }

        public ProductosBL()
        {
            _Contexto = new Contexto();

            ListadeProductos = new List<Producto>();
        
        }
        public List<Producto> ObtenerProductos()
        {
            ListadeProductos = _Contexto.Productos
            .Include("Categoria")
            .ToList();

            return ListadeProductos;
    }

        public void GuardarProducto(Producto producto)
        {
            if (producto.Id == 0)
            {
                _Contexto.Productos.Add(producto);
            }else

            {
                var productoExistente = _Contexto.Productos.Find(producto.Id);
                productoExistente.Descripcion = producto.Descripcion;
                productoExistente.Precio = producto.Precio;
            }

                _Contexto.SaveChanges();
        }
        public Producto ObtenerProducto(int Id)
        {
            var producto = _Contexto.Productos
                .Include("Categoria").FirstOrDefault(p => p.Id ==Id );

            return producto;
        }

        public void EliminarProducto(int Id)
        {
            var producto = _Contexto.Productos.Find(Id);
            _Contexto.Productos.Remove(producto);
            _Contexto.SaveChanges();
        }
        
    }
}
