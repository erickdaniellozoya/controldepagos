
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
        utilities ut = new utilities();
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
            txtMatricula.Text = tabla.Rows[0].Cells[0].Value.ToString();
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

            else //Si es otra tecla cancelamos
            {
                e.Handled = true;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)

        { 
           

                if (txtNombre.Text == "Nombre" || txtPaterno.Text == "Apellido paterno" || txtContra.Text=="Ingresar contraseña" || txtVerificar.Text=="Verificar contraseña" )
                {
                MessageBox.Show("Favor de llenar todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);


            }
                else if (txtMaterno.Text == "Apellido materno")
                {
                    txtMaterno.Text = "";
                }
                else {


                if (txtContra.Text != txtVerificar.Text)
                {
                    MessageBox.Show("Las contraseñas no coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }else
                    {

                    if (ut.contra(txtContra.Text))
                    {
                        string query = string.Format("INSERT INTO admins (nombre, apelldio_paterno, apellido_materno, contra) VALUES('{0}','{1}','{2}','{3}')", ut.encriptar(txtNombre.Text), ut.encriptar(txtPaterno.Text), ut.encriptar(txtMaterno.Text), ut.encriptar(txtContra.Text));
                        bd.Execute(query);
                        Index index = new Index(usuarios);
                        index.Show();
                        this.Hide();
                    }
                  else
                    {
                        MessageBox.Show("La contraseña tiene que incluir mayusculas, minusculas, digitos y signos por mayor seguridad");
                    }
                  
            }

        }
    }

        private void lblVolver_Click(object sender, EventArgs e)
        {
            Index index = new Index(usuarios);
            index.Show();
            this.Hide();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            txtNombre.Text = ut.iniciales(txtNombre.Text, txtNombre);
        }

        private void txtPaterno_TextChanged(object sender, EventArgs e)
        {
            txtPaterno.Text = ut.iniciales(txtPaterno.Text, txtPaterno);
        }

        private void txtMaterno_TextChanged(object sender, EventArgs e)
        {
            txtMaterno.Text = ut.iniciales(txtMaterno.Text, txtMaterno);
        }

        private void RegistrarAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}