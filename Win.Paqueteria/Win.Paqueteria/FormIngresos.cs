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
    public partial class FormIngresos : Form
    {
        IngresosBL _ingresos;

        public FormIngresos()
        {
            InitializeComponent();

            _ingresos = new IngresosBL();
            listaIngresosBindingSource.DataSource = _ingresos.ObtenerIngresos();
        }

        private void listaIngresosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listaIngresosBindingSource.EndEdit();
            var ingreso = (IngresosBL.Ingreso)listaIngresosBindingSource.Current;

            var resultado = _ingresos.GuardarIngreso(ingreso);

            if (resultado.Exitoso == true)
            {
                listaIngresosBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBotones(true);
            }
            else
            {
                MessageBox.Show(resultado.Mensaje);

            }
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            _ingresos.AgregarIngreso();
            listaIngresosBindingSource.MoveLast();

            DeshabilitarHabilitarBotones(false);
        }

        private void DeshabilitarHabilitarBotones(bool valor)

        {
            bindingNavigatorMoveFirstItem.Enabled = valor;
            bindingNavigatorMoveLastItem.Enabled = valor;
            bindingNavigatorMovePreviousItem.Enabled = valor;
            bindingNavigatorMoveNextItem.Enabled = valor;
            bindingNavigatorPositionItem.Enabled = valor;

            bindingNavigatorAddNewItem.Enabled = valor;
            bindingNavigatorDeleteItem.Enabled = valor;
            toolStripButton1Cancelar.Visible = !valor;
            //throw new NotImplementedException();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

            if (idTextBox.Text != "")
            {
                var resultado = MessageBox.Show("Desea eliminar este registro?", "Eliminar", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(idTextBox.Text);
                    Eliminar(id);
                }
                   
            }
        }

        private void Eliminar(int id)
        {
          
            var resultado = _ingresos.EliminarIngreso(id);

            if (resultado == true)
            {
                listaIngresosBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBotones(true);
            }
            else
            {
                MessageBox.Show("Ocurrio un error al eliminar el ingreso");
            }



            //  throw new NotImplementedException();
        }

        private void toolStripButton1Cancelar_Click(object sender, EventArgs e)
        {
            DeshabilitarHabilitarBotones(true);
            Eliminar(0);
        }

        private void FormIngresos_Load(object sender, EventArgs e)
        {

        }
    }

}
