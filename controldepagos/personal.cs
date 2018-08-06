using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace controldepagos
{
    public partial class personal : Form
    {
        utilities util = new utilities();
        MySqlCon db = new MySqlCon();
        string u;
        public personal(string usuario)
        {
            InitializeComponent();
            u = usuario;
        }

        private void personal_Load(object sender, EventArgs e)
        {
            db.CreateConnection();
            string query = string.Format("SELECT * FROM alumnos");
            DataTable dt = new DataTable();
            dt = db.fillTable(query);
            tabla.DataSource = dt;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Index index = new Index(u);
            index.Show();
            this.Hide();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            txtBuscar.Text = util.iniciales(txtBuscar.Text, txtBuscar);
            DataTable dt = new DataTable();
            string query = "";
            if (cbxEscolaridad.Text == "Escolaridad" && cbxGrupo.Text == "Grupo" && cbxGrado.Text == "Grado")
            {
                query = string.Format("SELECT * FROM alumnos WHERE Nombre LIKE '%{0}%' OR Apellido_paterno LIKE '%{0}%' or Apellido_materno LIKE '%{0}%'", txtBuscar.Text);
            }else if (cbxEscolaridad.Text != "Escolaridad" && cbxGrado.Text == "Grado" && cbxGrupo.Text == "Grupo")
            {
                query = string.Format("SELECT * FROM alumnos WHERE (Nombre LIKE '%{0}%' OR Apellido_paterno LIKE '%{0}%' or Apellido_materno LIKE '%{0}%') AND Escolaridad='{1}'", txtBuscar.Text,cbxEscolaridad.Text);
            }
            else if (cbxEscolaridad.Text != "Escolaridad" && cbxGrado.Text != "Grado" && cbxGrupo.Text == "Grupo")
            {
                query = string.Format("SELECT * FROM alumnos WHERE (Nombre LIKE '%{0}%' OR Apellido_paterno LIKE '%{0}%' or Apellido_materno LIKE '%{0}%') AND Escolaridad='{1}' AND grado='{2}'", txtBuscar.Text, cbxEscolaridad.Text,cbxGrado.Text);
            }
            else if (cbxEscolaridad.Text != "Escolaridad" && cbxGrado.Text != "Grado" && cbxGrupo.Text != "Grupo")
            {
                query = string.Format("SELECT * FROM alumnos WHERE (Nombre LIKE '%{0}%' OR Apellido_paterno LIKE '%{0}%' or Apellido_materno LIKE '%{0}%') AND Escolaridad='{1}' AND grado='{2}' AND grupo='{3}'", txtBuscar.Text, cbxEscolaridad.Text, cbxGrado.Text, cbxGrupo.Text);
            }

            dt = db.fillTable(query);
            tabla.DataSource = dt;
        }

        private void cbxEscolaridad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxEscolaridad.SelectedIndex == 1)
            {
                cbxGrado.Items.Clear();
                for (int i = 1; i <= 6; i++) cbxGrado.Items.Add(i.ToString());

            }
            else
            {

                cbxGrado.Items.Clear();
                for (int i = 1; i <= 3; i++) cbxGrado.Items.Add(i.ToString());

            }


        }

        private void cbxGrado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbxGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            RegistrarAlumno b2 = new RegistrarAlumno(u);
            b2.Show();
            this.Hide();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsSeparator(e.KeyChar))
            {
                e.Handled = false;
            }
              else if (e.KeyChar == (char)Keys.Back)//si es tecla borrar
            {
                e.Handled = false;
            }
            else if (Char.IsPunctuation(e.KeyChar))//Si es número
            {
                e.Handled = false;
            }
            else //Si es otra tecla cancelamos
            {
                e.Handled = true;
            }

        }

        private void personal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void txtBuscar_Leave(object sender, EventArgs e)
        {
            txtBuscar.Text = txtBuscar.Text.Equals("") ? "Ingresar Nombre" : txtBuscar.Text;
        }

        private void txtBuscar_Enter(object sender, EventArgs e)
        {
            txtBuscar.Text = txtBuscar.Text.Equals("Ingresar Nombre") ? "" : txtBuscar.Text;
        }
    }
    }

