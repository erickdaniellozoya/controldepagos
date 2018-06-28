
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
    public partial class RegistrarAdmin : Form
    {
        MySqlCon bd = new MySqlCon();
        bool toggle = false;
        string usuarios;
        public RegistrarAdmin(string u)
        {
            InitializeComponent();
            usuarios = u;
        }

        private void txtMatricula_Enter(object sender, EventArgs e)
        {
            txtMatricula.Text = txtMatricula.Text == "Ingresar matricula" ? "" : txtMatricula.Text;
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            txtNombre.Text = txtNombre.Text == "Nombre" ? "" : txtNombre.Text;
        }

        private void txtContra_Enter(object sender, EventArgs e)
        {
            txtContra.Text = txtContra.Text == "Ingresar contraseña" ? "" : txtContra.Text;
            txtContra.UseSystemPasswordChar = true;
        }

        private void txtVerificar_Enter(object sender, EventArgs e)
        {
            txtVerificar.Text = txtVerificar.Text == "Verificar contraseña" ? "" : txtVerificar.Text;
            txtVerificar.UseSystemPasswordChar = true;
        }

        private void RegistrarAdmin_Load(object sender, EventArgs e)
        {
            bd.CreateConnection();
            string query = "SELECT MAX(id)+1 FROM admins";
            DataTable dt = new DataTable();
            dt = bd.fillTable(query);
            tabla.DataSource = dt;
           // txtMatricula.Text = tabla.Rows[0].Cells[0].Value.ToString();
        }

        private void txtNombre_Leave(object sender, EventArgs e)
        {
            txtNombre.Text = txtNombre.Text == "" ? "Nombre" : txtNombre.Text;
        }

        private void txtContra_Leave(object sender, EventArgs e)
        {
            txtContra.UseSystemPasswordChar = txtContra.Text == "" ? false : true;
            txtContra.Text = txtContra.Text == "" ? "Ingresar contraseña" : txtContra.Text;
        }

        private void txtVerificar_Leave(object sender, EventArgs e)
        {
            txtVerificar.UseSystemPasswordChar = txtVerificar.Text == "" ? false : true;
            txtVerificar.Text = txtVerificar.Text == "" ? "Verificar contraseña" : txtVerificar.Text;
        }

        private void txtPaterno_Enter(object sender, EventArgs e)
        {
            txtPaterno.Text = txtPaterno.Text == "Apellido paterno" ? "" : txtPaterno.Text;
        }

        private void txtPaterno_Leave(object sender, EventArgs e)
        {
            txtPaterno.Text = txtPaterno.Text == "" ? "Apellido paterno" : txtPaterno.Text;
        }

        private void txtMaterno_Enter(object sender, EventArgs e)
        {
            txtMaterno.Text = txtMaterno.Text == "Apellido materno" ? "" : txtMaterno.Text;
        }

        private void txtMaterno_Leave(object sender, EventArgs e)
        {
            txtMaterno.Text = txtMaterno.Text == "" ? "Apellido materno" : txtMaterno.Text;
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                Control ctl;
                ctl = ((Control)sender).Parent;
                ctl.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtContra.Text != txtVerificar.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (toggle)
                {
                    string query = string.Format("INSERT INTO admins (nombre, apelldio_paterno, apellido_materno, contra) VALUES('{0}','{1}','{2}',MD5('{3}'))", txtNombre.Text, txtPaterno.Text, txtMaterno.Text, txtContra.Text);
                    bd.Execute(query);
                    query = "SELECT MAX(id)+1 FROM admins";
                    DataTable dt = new DataTable();
                    dt = bd.fillTable(query);
                    tabla.DataSource = dt;
                    txtMatricula.Text = tabla.Rows[0].Cells[0].Value.ToString();
                    txtNombre.Text = "";
                    txtPaterno.Text = "";
                    txtMaterno.Text = "";
                    txtContra.Text = "";
                    txtVerificar.Text = "";
                    txtNombre_Leave(sender, e);
                    txtPaterno_Leave(sender, e);
                    txtMaterno_Leave(sender, e);
                    txtContra_Leave(sender, e);
                    txtVerificar_Leave(sender, e);
                }
                else
                {
                    string query = string.Format("INSERT INTO admins (nombre, apelldio_paterno, apellido_materno, contra) VALUES('{0}','{1}','{2}',MD5('{3}'))", txtNombre.Text, txtPaterno.Text, txtMaterno.Text, txtContra.Text);
                    bd.Execute(query);
                    Index index = new Index(usuarios);
                    index.Show();
                    this.Hide();
                }

            }
        }

        private void toogleOff_Click(object sender, EventArgs e)
        {
            toogleOff.Visible = false;
            toggleOn.Visible = true;
            toggle = true;
        }

        private void toggleOn_Click(object sender, EventArgs e)
        {
            toogleOff.Visible = true;
            toggleOn.Visible = false;
            toggle = false;
        }

        private void lblVolver_Click(object sender, EventArgs e)
        {
            Index index = new Index(usuarios);
            index.Show();
            this.Hide();
        }
    }
}