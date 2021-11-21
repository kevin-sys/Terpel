using BLL;
using ENTITY;
using System;
using System.Windows.Forms;

namespace Terpel
{
    public partial class FrmCliente : Form
    {
        Cliente cliente;
        ClienteServiceOracle serviceOracle = new ClienteServiceOracle();
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {

        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {

            GuardarOracle();
        }

        private void GuardarOracle()
        {
            var respueta = new ClienteServiceOracle.Respuesta();
            try
            {
                Cliente cliente = new Cliente();
                cliente.Cedula = TxtCedula.Text.Trim();
                cliente.Primernombre = TxtPrimerNombre.Text.Trim();
                cliente.Segundonombre = TxtSegundoNombre.Text.Trim();
                cliente.Primerapellido = TxtPrimerApellido.Text.Trim();
                cliente.Segundoapellido = TxtSegundoApellido.Text.Trim();
                cliente.Telefono = TxtTelefono.Text.Trim();
                cliente.Email = TxtEmail.Text.Trim();

                cliente.Direccion = Direccion.Text.Trim();
                cliente.Edad = int.Parse(Edad.Text.Trim());
                cliente.Ciudad = Ciudad.Text.Trim();
                cliente.Comuna = Comuna.Text.Trim();
                cliente.Barrio = Barrio.Text.Trim();
                cliente.Nacionalidad = Nacionalidad.Text.Trim();


                respueta = serviceOracle.Guardar(cliente);
                MessageBox.Show(respueta.Message, "Resultado de guardar", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            }
            catch (Exception)
            {

                throw;
            }
        }


      
        private Cliente MapearCliente()
        {
            cliente = new Cliente();
            cliente.Cedula = TxtCedula.Text.Trim();
            cliente.Primernombre = TxtPrimerNombre.Text.Trim();
            cliente.Segundonombre = TxtSegundoNombre.Text.Trim();
            cliente.Primerapellido = TxtPrimerApellido.Text.Trim();
            cliente.Segundoapellido = TxtSegundoApellido.Text.Trim();
            cliente.Telefono = TxtTelefono.Text.Trim();
            cliente.Email = TxtEmail.Text.Trim();
          
            return cliente;

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {

         
        }

        private void LimpiarCajas()
        {
            TxtCedula.Text = "";
            TxtPrimerNombre.Text = "";
            TxtSegundoNombre.Text = "";
            TxtSegundoApellido.Text = "";
            TxtPrimerApellido.Text = "";
            TxtTelefono.Text = "";
            TxtEmail.Text = "";
     
        }
        private void BtnModificar_Click(object sender, EventArgs e)
        {
           
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {

        

        }
    }
}
