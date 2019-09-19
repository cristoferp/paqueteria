using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.Paqueteria
{
    public partial class FormMenu : Form
    {
        private object formLogin;
        private object fomLogin;

        public FormMenu()
        {
            InitializeComponent();
        }
        private void loginTsStripMenuItem_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            var formLogin = new FormLogin();
            formLogin.ShowDialog();
           
        }

        private void paquetesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ingresoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formlogin = new FormLogin();
            formlogin.ShowDialog();

        }

        private void ingresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formingresos = new FormIngresos();
            formingresos.MdiParent = this;
            formingresos.Show();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            Login();
        }

        private void entregasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formEntregas = new FormEntregas();
            formEntregas.MdiParent = this;
            formEntregas.Show();
        }

         private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var formClientes = new FormClientes();
            formClientes.MdiParent = this;
            formClientes.Show();
      
        }

        private void facturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formFactura = new FormFactura();
            formFactura.MdiParent = this;
            formFactura.Show();
        }

        private void ingresosToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        

        private void reporteDeFacturasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formReporteFacturas = new FormReporteFacturas();
            formReporteFacturas.MdiParent = this;
            formReporteFacturas.Show();
        }

        private void reporteDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formReporteClientes = new FormReporteClientes();
            formReporteClientes.MdiParent = this;
            formReporteClientes.Show();
        }

        private void reporteDeIngresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var formReporteIngresos = new FormReporteIngresos();
            formReporteIngresos.MdiParent = this;
            formReporteIngresos.Show();
        }
    }
}
 