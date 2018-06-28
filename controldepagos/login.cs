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
    public partial class login : Form
    {
        MySqlCon bd = new MySqlCon();
        public login()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = string.Format("SELECT id FROM admins WHERE id={0} AND contra=MD5('{1}')", txtMatricula.Text, txtContra.Text);
            if (bd.Execute(query)!="-1")
            {
                query = string.Format("SELECT CONCAT(nombre,' ',apelldio_paterno,' ',apellido_materno) FROM admins WHERE id={0}", txtMatricula.Text);
                DataTable dt = new DataTable();
            
                tabla.DataSource = dt;
                Index b2 = new Index(tabla.Rows[0].Cells[0].Value.ToString());
                b2.Show();
                this.Hide();
            }else
            {
                MessageBox.Show("Los datos son incorrectos","Error",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void txtMatricula_Leave(object sender, EventArgs e)
        {
            txtMatricula.Text = txtMatricula.Text == "" ? "Ingresar matricula" : txtMatricula.Text;
        }

        private void txtContra_Leave(object sender, EventArgs e)
        {
            if (txtContra.Text == "")
            {
                txtContra.Text = "Ingresar contraseña";
                txtContra.UseSystemPasswordChar = false;
            }
        }

        private void txtMatricula_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                Control ctl;
                ctl = ((Control)sender).Parent;
                ctl.SelectNextControl(ActiveControl, true, true, true, true);
            }
            
            if (Char.IsDigit(e.KeyChar))
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
            else
            {
                e.Handled = true;
            }
        }

        private void login_Load(object sender, EventArgs e)
        {
            
            bd.CreateConnection();
        }

        private void txtContra_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtContra.UseSystemPasswordChar = true;
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                button3_Click(sender, e);
            }
        }

        private void txtContra_Enter(object sender, EventArgs e)
        {
            txtContra.Text = txtContra.Text == "Ingresar contraseña" ? "" : txtContra.Text;
            txtContra.UseSystemPasswordChar = true;
        }

        private void txtMatricula_Enter(object sender, EventArgs e)
        {
            txtMatricula.Text = txtMatricula.Text == "Ingresar matricula" ? "" : txtMatricula.Text;
        }

        private void login_Click(object sender, EventArgs e)
        {
            
        }
    }
}
