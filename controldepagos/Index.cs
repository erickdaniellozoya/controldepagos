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
    public partial class Index : Form
    {
        string u;
        public Index(string usuario)
        {
            InitializeComponent();
            u = usuario;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrarAdmin b2 = new RegistrarAdmin(u);
            b2.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          RegistrarAlumno b2 = new RegistrarAlumno(u);
            b2.Show();
            this.Hide();
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Pagos b2 = new Pagos();
            b2.Show();
            this.Hide();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Reportecs b2 = new Reportecs();
            b2.Show();
            this.Hide();
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            personal b2 = new personal();
            b2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            login b2 = new login();
            b2.Show();
            this.Hide();
        }

        private void Index_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = "Usuario: " + u;
            this.Text = this.Text + " - " + u;
        }

        private void lblUsuario_TextChanged(object sender, EventArgs e)
        {
            lblUsuario.Location = new Point(lblUsuario.Location.X - lblUsuario.Text.Length * 4, lblUsuario.Location.Y);
        }
    }
}
