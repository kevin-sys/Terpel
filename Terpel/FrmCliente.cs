using BLL;
using ENTITY;
using System;
using System.Windows.Forms;

namespace Terpel
{
    public partial class FrmCliente : Form
    {
      
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


        }

        private void GuardarOracle()
        {
            var respuesta = new ClienteServiceOracle.Respuesta();
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


                respuesta = serviceOracle.Guardar(cliente);
                MessageBox.Show(respuesta.Message, "Resultado de guardar", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            }
            catch (Exception)
            {

                throw;
            }

            LimpiarCajas();
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
            Direccion.Text = "";
            Edad.Text = "";
            Ciudad.Text = "";
            Comuna.Text = "";
            Barrio.Text = "";
            Nacionalidad.Text = "";



        }
        private void BtnModificar_Click(object sender, EventArgs e)
        {

        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {



        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GuardarOracle();
        }

        private void BtnEliminar_Click_1(object sender, EventArgs e)
        {
            var respuesta = MessageBox.Show("ESTA SEGURO DE ELIMINAR EL REGISTRO", "MENSAJE DE ELIMINACIÓN", MessageBoxButtons.YesNo);
            if (respuesta == DialogResult.Yes)
            {
                ClienteServiceOracle clienteService = new ClienteServiceOracle();
                string identificacion = TxtCedula.Text;
                string mensaje = clienteService.Eliminar(identificacion);
                MessageBox.Show(mensaje);

            }
        }

        private void BtnBuscar_Click_1(object sender, EventArgs e)
        {
            ClienteServiceOracle clienteService = new ClienteServiceOracle();
            string identificacion = TxtCedula.Text;
            if (identificacion != "")
            {
                Cliente cliente = clienteService.BuscarID(identificacion);

                if (cliente != null)
                {
                    TxtCedula.Text = cliente.Cedula;
                    TxtPrimerNombre.Text = cliente.Primernombre;
                    TxtSegundoNombre.Text = cliente.Segundonombre;
                    TxtPrimerApellido.Text = cliente.Primerapellido;
                    TxtSegundoApellido.Text = cliente.Segundoapellido;
                    TxtTelefono.Text = cliente.Telefono;
                    TxtEmail.Text = cliente.Email;
                    Direccion.Text = cliente.Direccion;

                    Edad.Text = cliente.Edad.ToString();
                    Ciudad.Text = cliente.Ciudad;
                    Comuna.Text = cliente.Comuna;
                    Barrio.Text = cliente.Barrio;
                    Nacionalidad.Text = cliente.Nacionalidad;


                }
                else
                {
                    MessageBox.Show($"EL CLIENTE CON LA IDENTIFICACIÓN:  {identificacion} NO SE ENCUENTRA EN NUESTRA BASE DE DATOS");

                }

            }
            else
            {
                MessageBox.Show("DIGITE LA CEDULA");
            }
        }
    }
}
