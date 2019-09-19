using BL.Entregas;
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
    public partial class FormClientes : Form
    {
        ClientesBL _clientesBL;

        public FormClientes()
        {
            InitializeComponent();

            _clientesBL = new ClientesBL();
            listaClientesBindingSource.DataSource = _clientesBL.ObtenerClientes();
        }
        private void Eliminar(int id)
        {

            var resultado = _clientesBL.EliminarCliente(id);

            if (resultado == true)
            {
                listaClientesBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBotones(true);
            }
            else
            {
                MessageBox.Show("Ocurrio un error al eliminar el cliente");
            }



            //  throw new NotImplementedException();
        }




        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            //if (idTextBox1.Text != "")
            if (idTextBox.Text != "")
            {
                var resultado = MessageBox.Show("Desea eliminar este cliente?", "Eliminar", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    //var id = Convert.ToInt32(idTextBox1.Text);
                    var id = Convert.ToInt32(idTextBox.Text);
                    Eliminar(id);
                }
            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _clientesBL.AgregarCliente();
            listaClientesBindingSource.MoveLast();

            DeshabilitarHabilitarBotones(true);
            
        }

        private  void DeshabilitarHabilitarBotones (bool valor)
        {
            bindingNavigatorMoveFirstItem.Enabled = valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;


            bindingNavigatorAddNewItem.Enabled = valor;
            bindingNavigatorDeleteItem.Enabled = valor;
            Cancelar.Visible = !valor;


        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            _clientesBL.CancelarCambios();
            DeshabilitarHabilitarBotones(true);
         
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {

        }

        private void clientesBLBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listaClientesBindingSource.EndEdit();
            var cliente = (Cliente)listaClientesBindingSource.Current;

            var resultado = _clientesBL.GuardarCliente(cliente);

            if (resultado.Exitoso == true)
            {
                listaClientesBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBotones(true);
                MessageBox.Show("Cliente Guardado");
            }
            else
            {
                MessageBox.Show(resultado.Mensaje);
            }
        }

        private void idTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
