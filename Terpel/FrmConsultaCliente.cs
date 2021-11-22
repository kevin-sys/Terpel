using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using ENTITY;

namespace Terpel
{
    public partial class FrmConsultaCliente : Form
    {
        ClienteServiceOracle service = new ClienteServiceOracle();

        public FrmConsultaCliente()
        {
            InitializeComponent();
           // DgvClientes.DataSource = null;
            LlenarTabla();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
           
        }
        private  void LlenarTabla()
        {
            DgvClientes.DataSource = null;
            DgvClientes.DataSource = service.ConsultarTodos();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LlenarTabla();
        }
    }
}
