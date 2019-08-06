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
    public partial class FormLogin : Form
    {

        private bool _autenticado;
        SegridadBL _seguridad;


        public FormLogin()
        {
            InitializeComponent();

            _seguridad = new SegridadBL();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string usuario;
            string contraseña;

            usuario = textBox1.Text;
            contraseña = textBox2.Text;

            var resultado = _seguridad.Autorizar(usuario, contraseña);

            if (resultado == true)
            {
                this.Close();
            }
            else
            {
                if (usuario == "user" && contraseña == "456")
                {
                    _autenticado = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña invalida");

                }
            }
        
        
        }
        private void TextBox1_TextChanged(object sender, EventArgs e)

        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}





