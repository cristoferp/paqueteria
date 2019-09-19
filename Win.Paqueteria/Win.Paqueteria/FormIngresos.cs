using BL.Entregas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Win.Paqueteria
{
    public partial class FormIngresos : Form
    {
        IngresosBL _ingresos;
        CategoriasBL _categorias;
        TiposBL _tiposBL;
        //ClientesBL _clientesBL;
        
        
        

        public FormIngresos()
        {
            InitializeComponent();

            _ingresos = new IngresosBL();
            listaIngresosBindingSource.DataSource = _ingresos.ObtenerIngresos();

            _categorias = new CategoriasBL();
            listaCategoriasBindingSource.DataSource = _categorias.ObtenerCategorias();

            _tiposBL = new TiposBL();
            listaTiposBindingSource.DataSource = _tiposBL.ObtenerTipos();

           

           
        }

        private void listaIngresosBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            listaIngresosBindingSource.EndEdit();
            var ingreso = (Ingreso)listaIngresosBindingSource.Current;
            //var resultado = _ingresos.GuardarIngreso(ingreso);


            //if (resultado.Exitoso == true)

            { 
                if (fotoPictureBox.Image != null)
            {
                ingreso.Foto = Program.imageToByteArray(fotoPictureBox.Image);
            }
            else
            {
                ingreso.Foto = null;
            }

            var resultado = _ingresos.GuardarIngreso(ingreso);

            if (resultado.Exitoso == true)
           {
                listaIngresosBindingSource.ResetBindings(false);
                DeshabilitarHabilitarBotones(true);
                MessageBox.Show("Ingreso Guardado");
            }
            else
            {
                MessageBox.Show(resultado.Mensaje);

              }
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
            toolStripButtonCancelar.Visible = !valor;
            
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

            if (idTextBox1.Text != "")
            {
                var resultado = MessageBox.Show("Desea eliminar este registro?", "Eliminar", MessageBoxButtons.YesNo);
                if (resultado == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(idTextBox1.Text);
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



              throw new NotImplementedException();
        }

        private void toolStripButton1Cancelar_Click(object sender, EventArgs e)
        {
            _ingresos.CancelarCambios();
            DeshabilitarHabilitarBotones(true);
            Eliminar(0);
        }

        private void Agregar_Click(object sender, EventArgs e)
        {
            var ingreso = (Ingreso)listaIngresosBindingSource.Current;

            if  (ingreso != null)
            {
                openFileDialog1.FileName = "";
                openFileDialog1.ShowDialog();

                var archivo = openFileDialog1.FileName;

                if (archivo != "")

                {
                    var fileInfo = new FileInfo(archivo);
                    var fileStream = fileInfo.OpenRead();


                    fotoPictureBox.Image = Image.FromStream(fileStream);
                }

                else
                {
                    MessageBox.Show("Cree un registro antes de asignarle una imagen");
                }

            }
        }
    

        private void button2_Click(object sender, EventArgs e)
        {
            fotoPictureBox.Image = null;
        }

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void FormIngresos_Load(object sender, EventArgs e)
        {

        }

        private void fotoPictureBox_Click(object sender, EventArgs e)
        {

        }
    }

}
