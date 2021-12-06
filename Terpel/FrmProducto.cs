using BLL;
using ENTITY;
using System;
using System.Windows.Forms;

namespace Terpel
{
    public partial class FrmProducto : Form
    {
        
        ProductoServiceOracle service = new ProductoServiceOracle();
        public FrmProducto()
        {
            InitializeComponent();
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void FrmProducto_Load_1(object sender, EventArgs e)
        {

        }

        private void TxtPrimerNombre_TextChanged(object sender, EventArgs e)
        {

        }
        private void Mapear()
        {
            var respuesta = new ProductoServiceOracle.Respuesta();
            try
            {
                Producto producto = new Producto();
                producto.Id = TxtID.Text.Trim();
                producto.Nombre = TxtNombre.Text.Trim();

                producto.Cantidad = float.Parse(TxtCantidad.Text.Trim());
                producto.PrecioCompra = float.Parse(TxtPrecioCompra.Text.Trim());
                producto.PrecioVenta = float.Parse(TxtPrecioVenta.Text.Trim());
                producto.Descripcion = TxtDescripcion.Text.Trim();
                producto.CalcularGanancia();
                respuesta = service.Guardar(producto);
                MessageBox.Show(respuesta.Message, "Resultado de guardar", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);


            }
            catch (Exception)
            {

                throw;
            }
        }
        private void BtnRegistrar_Click(object sender, EventArgs e)
        {
            Mapear();
        }
    }
}
