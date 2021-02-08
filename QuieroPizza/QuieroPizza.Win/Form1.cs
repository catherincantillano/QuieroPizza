using QuieroPizza.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuieroPizza.Win
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var productoBL = new ProductosBL();
            var listadeProductos = productoBL.ObtenerProductos();
            foreach (var productos in listadeProductos)
            {
                MessageBox.Show(productos.Descripcion);
            }
        }
    }
}
