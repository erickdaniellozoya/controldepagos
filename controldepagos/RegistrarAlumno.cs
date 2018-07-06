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
    public partial class RegistrarAlumno : Form
    {
        MySqlCon db = new MySqlCon();
        utilities util = new utilities();
        string u;
        public RegistrarAlumno(string usuario)
        {
            InitializeComponent();
            u = usuario;
        }

        private void RegistrarAlumno_Load(object sender, EventArgs e)
        {
            db.CreateConnection();
            cbxGrado.Enabled = false;
            cbxGrupo.Enabled = false;
            cbxEscolaridad.Text = "Seleccione la escolaridad";
            string query = "SELECT MAX(matricula) FROM alumnos";
            DataTable dt = new DataTable();
            dt = db.fillTable(query);
            dgv.DataSource = dt;
            txtMatricula.Text = dgv.Rows.Count > 0 ? (Convert.ToInt32(dgv.Rows[0].Cells[0].Value.ToString()) + 1).ToString() : "1";
        }

        private void cbxEscolaridad_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxGrado.Enabled = true;
            cbxGrupo.Enabled = true;
            cbxGrado.Items.Clear();
            cbxGrupo.Items.Clear();
            int grados = cbxEscolaridad.SelectedItem.ToString().Equals("Kinder") || cbxEscolaridad.SelectedItem.ToString().Equals("Secundaria") ? 3 : 6;
            for (int i = 0; i < grados; i++)
            {
                cbxGrado.Items.Add((i+1).ToString());
            }
            cbxGrupo.Items.Add("A");
            cbxGrupo.Items.Add("B"); 
        }

        private void txtnombre_Enter(object sender, EventArgs e)
        {
            txtnombre.Text = txtnombre.Text.Equals("Ingresar Nombre") ? "" : txtnombre.Text;
        }

        private void txtap_Enter(object sender, EventArgs e)
        {
            txtap.Text = txtap.Text.Equals("Ingresar Apellido Paterno") ? "" : txtap.Text;
        }

        private void txtam_Enter(object sender, EventArgs e)
        {
            txtam.Text = txtam.Text.Equals("Ingresar Apellido Materno") ? "" : txtam.Text;
        }

        private void txttel_Enter(object sender, EventArgs e)
        {
            txttel.Text = txttel.Text.Equals("Ingresar Numero De Padres") ? "" : txttel.Text;
        }

        private void txtnp_Enter(object sender, EventArgs e)
        {
            txtnp.Text = txtnp.Text.Equals("Ingresar Nombre De Padres") ? "" : txtnp.Text;
        }

        private void txtdir_Enter(object sender, EventArgs e)
        {
            txtdir.Text = txtdir.Text.Equals("Ingresar Dirección") ? "" : txtdir.Text;
        }

        private void txtnombre_Leave(object sender, EventArgs e)
        {
            txtnombre.Text = txtnombre.Text.Equals("") ? "Ingresar Nombre" : txtnombre.Text;
        }

        private void txtap_Leave(object sender, EventArgs e)
        {
            txtap.Text = txtap.Text.Equals("") ? "Ingresar Apellido Paterno" : txtap.Text;
        }

        private void txtam_Leave(object sender, EventArgs e)
        {
            txtam.Text = txtam.Text.Equals("") ? "Ingresar Apellido Materno" : txtam.Text;
        }

        private void txttel_Leave(object sender, EventArgs e)
        {
            txttel.Text = txttel.Text.Equals("") ? "Ingresar Numero De Padres" : txttel.Text;
        }

        private void txtnp_Leave(object sender, EventArgs e)
        {
            txtnp.Text = txtnp.Text.Equals("") ? "Ingresar Nombre De Padres" : txtnp.Text;
        }

        private void txtdir_Leave(object sender, EventArgs e)
        {
            txtdir.Text = txtdir.Text.Equals("") ? "Ingresar Dirección" : txtdir.Text;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if ((txtnombre.Text.Equals("Ingresar nombre") || txtap.Text.Equals("Ingresar apellido paterno") || cbxEscolaridad.Text.Equals("Seleccione la escolaridad") || cbxGrado.Text.Equals("") || cbxGrupo.Text.Equals("") || txttel.Text.Equals("Ingresar numero de padres") || txtnp.Text.Equals("Ingresar nombre de padres") || txtdir.Text.Equals("Ingresar dirección")))
            {
                MessageBox.Show("Favor de llenar todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string query = string.Format("INSERT INTO alumnos (Nombre, Apellido_paterno, Apellido_materno, Escolaridad, Grado, Grupo, Numero_padres, Nombre_padres, Direccion) VALUES('{0}','{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}')",txtnombre.Text, txtap.Text, txtam.Text, cbxEscolaridad.Text, cbxGrado.Text, cbxGrupo.Text, txttel.Text, txtnp.Text, txtdir.Text);
                db.Execute(query);
            }
        }

        private void txtnombre_TextChanged(object sender, EventArgs e)
        {
            txtnombre.Text = util.iniciales(txtnombre.Text, txtnombre);
            
        }

        private void txtap_TextChanged(object sender, EventArgs e)
        {
            txtap.Text = util.iniciales(txtap.Text, txtap);
        }

        private void txtam_TextChanged(object sender, EventArgs e)
        {
            txtam.Text = util.iniciales(txtam.Text, txtam);
        }

        private void txtnp_TextChanged(object sender, EventArgs e)
        {
            txtnp.Text = util.iniciales(txtnp.Text, txtnp);
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            Index i = new Index(u);
            i.Show();
            this.Hide();
        }
    }
}
