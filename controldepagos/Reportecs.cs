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
    public partial class Reportecs : Form
    {
        MySqlCon db = new MySqlCon();
        string u;
        public Reportecs(string usuario)
        {
            InitializeComponent();
            u = usuario;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Index index = new Index(u);
            index.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string query = "";
            if (cbxEscolaridad.Text == "Escolaridad" && cbxGrupo.Text == "Grupo" && cbxGrado.Text == "Grado")
            {
                query = string.Format("SELECT * FROM alumnos WHERE Nombre LIKE '%{0}%' OR Apellido_paterno LIKE '%{0}%' or Apellido_materno LIKE '%{0}%'", txtBuscar.Text);
            }
            else if (cbxEscolaridad.Text != "Escolaridad" && cbxGrado.Text == "Grado" && cbxGrupo.Text == "Grupo")
            {
                query = string.Format("SELECT * FROM alumnos WHERE (Nombre LIKE '%{0}%' OR Apellido_paterno LIKE '%{0}%' or Apellido_materno LIKE '%{0}%') AND Escolaridad='{1}'", txtBuscar.Text, cbxEscolaridad.Text);
            }
            else if (cbxEscolaridad.Text != "Escolaridad" && cbxGrado.Text != "Grado" && cbxGrupo.Text == "Grupo")
            {
                query = string.Format("SELECT * FROM alumnos WHERE (Nombre LIKE '%{0}%' OR Apellido_paterno LIKE '%{0}%' or Apellido_materno LIKE '%{0}%') AND Escolaridad='{1}' AND grado='{2}'", txtBuscar.Text, cbxEscolaridad.Text, cbxGrado.Text);
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
    }
}
