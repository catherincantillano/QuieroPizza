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
            ListadeProductos = new List<Producto>();
           _Contexto = new Contexto();

        }
        public List<Producto> ObtenerProductos()
        {
            ListadeProductos = _Contexto.Productos.ToList();

            return ListadeProductos;
    }
   }
}
