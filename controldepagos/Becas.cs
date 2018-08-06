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
    public partial class Becas : Form
    {
        utilities util = new utilities();
        MySqlCon db = new MySqlCon();
        string u;
        public Becas(string usuario)
        {
            InitializeComponent();
            cbxEscolaridad.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxGrupo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxGrado.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxescolaridad1.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxGrupo1.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxGrado1.DropDownStyle = ComboBoxStyle.DropDownList;

            u = usuario;
        }

        private void button5_Click(object sender, EventArgs e)
        {
           Index index = new Index(u);
            index.Visible = true;
            Visible = false;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            txtno.Text = util.iniciales(txtno.Text, txtno);

            DataTable dt = new DataTable();
            string query = "";
            if (cbxEscolaridad.Text == "Escolaridad" && cbxGrupo.Text == "Grupo" && cbxGrado.Text == "Grado")
            {
                query = string.Format("SELECT * FROM alumnos WHERE Nombre LIKE '%{0}%' OR Apellido_paterno LIKE '%{0}%' or Apellido_materno LIKE '%{0}%'", txtno.Text);
            }
            else if (cbxEscolaridad.Text != "Escolaridad" && cbxGrado.Text == "Grado" && cbxGrupo.Text == "Grupo")
            {
                query = string.Format("SELECT * FROM alumnos WHERE (Nombre LIKE '%{0}%' OR Apellido_paterno LIKE '%{0}%' or Apellido_materno LIKE '%{0}%') AND Escolaridad='{1}'", txtno.Text, cbxEscolaridad.Text);
            }
            else if (cbxEscolaridad.Text != "Escolaridad" && cbxGrado.Text != "Grado" && cbxGrupo.Text == "Grupo")
            {
                query = string.Format("SELECT * FROM alumnos WHERE (Nombre LIKE '%{0}%' OR Apellido_paterno LIKE '%{0}%' or Apellido_materno LIKE '%{0}%') AND Escolaridad='{1}' AND grado='{2}'", txtno.Text, cbxEscolaridad.Text, cbxGrado.Text);
            }
            else if (cbxEscolaridad.Text != "Escolaridad" && cbxGrado.Text != "Grado" && cbxGrupo.Text != "Grupo")
            {
                query = string.Format("SELECT * FROM alumnos WHERE (Nombre LIKE '%{0}%' OR Apellido_paterno LIKE '%{0}%' or Apellido_materno LIKE '%{0}%') AND Escolaridad='{1}' AND grado='{2}' AND grupo='{3}'", txtno.Text, cbxEscolaridad.Text, cbxGrado.Text, cbxGrupo.Text);
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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtinscri.Text != "Ingresar Descuento")
                {
                    txtresto2.Text = (Convert.ToDecimal(txtdesc.Text) - (Convert.ToDecimal(txtdesc.Text) * (Convert.ToDecimal(txtinscri.Text) / 100))).ToString();

                }
            }
            catch (Exception)
            {

            }

        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            if ((txtno.Text.Equals("Ingresar Nombre") || cbxGrado.Text.Equals("Grado") || cbxEscolaridad.Text.Equals("Escolaridad") || cbxGrupo.Text.Equals("Grupo") || txtCantidadn.Text.Equals("Ingresar Cantidad") || txttotal.Text.Equals("0") || txtresto.Text.Equals("0")))
            {
                MessageBox.Show("Favor de llenar todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                DataTable dt = new DataTable();
                dt = db.fillTable(string.Format("SELECT Matricula FROM alumnos WHERE concat(Nombre,' ',Apellido_paterno, ' ',Apellido_materno) LIKE '{0}'", txtno.Text));
              
                tabla.DataSource = dt;

                string query = string.Format("INSERT INTO becas(Matricula, BuenoPor,Fecha_Pago) VALUES('{0}','{1}',NOW())", tabla.Rows[0].Cells[0].Value.ToString(), txtCantidadn.Text);
                if (db.Execute(query) == "-1")
                {
                  
                    MessageBox.Show("El Pago ha sido registrado con exito");
                    Index i = new Index(u);
                    i.Show();
                    this.Hide();

                }

            }
        }

        private void btnreg_Click(object sender, EventArgs e)
        {

            if ((txtnom.Text.Equals("Ingresar Nombre") /*|| cbxGrado1.Text.Equals("Grado") || cbxescolaridad1.Text.Equals("Escolaridad") || cbxGrupo1.Text.Equals("Grupo")*/ || txtinscri.Text.Equals("Ingresar Cantidad") || txtdesc.Text.Equals("0") || txtresto2.Text.Equals("0")))
            {
                MessageBox.Show("Favor de llenar todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                DataTable dt = new DataTable();
                dt = db.fillTable(string.Format("SELECT Matricula FROM alumnos WHERE concat(Nombre,' ',Apellido_paterno, ' ',Apellido_materno) LIKE '{0}'", txtnom.Text));

                tabla.DataSource = dt;

                string query = string.Format("INSERT INTO descuento(Matricula, BuenoPor,Fecha_Pago) VALUES('{0}','{1}',NOW())", tabla.Rows[0].Cells[0].Value.ToString(), txtinscri.Text);
                if (db.Execute(query) == "-1")
                {

                    MessageBox.Show("El Pago ha sido registrado con exito");
                    Index i = new Index(u);
                    i.Show();
                    this.Hide();

                }
            }
        }
        private void txtnom_TextChanged(object sender, EventArgs e)
        {
            txtnom.Text = util.iniciales(txtnom.Text, txtnom);
            DataTable dt = new DataTable();
            string query = "";
            if (cbxescolaridad1.Text == "Escolaridad" && cbxGrupo1.Text == "Grupo" && cbxGrado1.Text == "Grado")
            {
                query = string.Format("SELECT * FROM alumnos WHERE Nombre LIKE '%{0}%' OR Apellido_paterno LIKE '%{0}%' or Apellido_materno LIKE '%{0}%'", txtnom.Text);
            }
            else if (cbxescolaridad1.Text != "Escolaridad" && cbxGrado1.Text == "Grado" && cbxGrupo1.Text == "Grupo")
            {
                query = string.Format("SELECT * FROM alumnos WHERE (Nombre LIKE '%{0}%' OR Apellido_paterno LIKE '%{0}%' or Apellido_materno LIKE '%{0}%') AND Escolaridad='{1}'", txtnom.Text, cbxescolaridad1.Text);
            }
            else if (cbxescolaridad1.Text != "Escolaridad" && cbxGrado1.Text != "Grado" && cbxGrupo1.Text == "Grupo")
            {
                query = string.Format("SELECT * FROM alumnos WHERE (Nombre LIKE '%{0}%' OR Apellido_paterno LIKE '%{0}%' or Apellido_materno LIKE '%{0}%') AND Escolaridad='{1}' AND grado='{2}'", txtnom.Text, cbxescolaridad1.Text, cbxGrado1.Text);
            }
            else if (cbxescolaridad1.Text != "Escolaridad" && cbxGrado1.Text != "Grado" && cbxGrupo1.Text != "Grupo")
            {
                query = string.Format("SELECT * FROM alumnos WHERE (Nombre LIKE '%{0}%' OR Apellido_paterno LIKE '%{0}%' or Apellido_materno LIKE '%{0}%') AND Escolaridad='{1}' AND grado='{2}' AND grupo='{3}'", txtnom.Text, cbxescolaridad1.Text, cbxGrado1.Text, cbxGrupo1.Text);
            }

            dt = db.fillTable(query);
            
        }

        private void cbxescolaridad1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxescolaridad1.SelectedIndex == 1)
            {
                cbxGrado1.Items.Clear();
                for (int i = 1; i <= 6; i++) cbxGrado1.Items.Add(i.ToString());

            }
            else
            {

                cbxGrado1.Items.Clear();
                for (int i = 1; i <= 3; i++) cbxGrado1.Items.Add(i.ToString());

            }
        }

        private void txtCantidadn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))//Si es número
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

        private void txtinscri_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))//Si es número
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

        private void txttotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))//Si es número
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

        private void txtdesc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))//Si es número
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

       

        private void txtinscri_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtdesc.Text != "0")
                {
                    txtresto2.Text = (Convert.ToDecimal(txtdesc.Text) - (Convert.ToDecimal(txtdesc.Text) * (Convert.ToDecimal(txtinscri.Text) / 100))).ToString();
                }
            }
            catch(Exception)
            {

            }
        }

        private void txtno_Leave(object sender, EventArgs e)
        {
            txtno.Text = txtno.Text.Equals("") ? "Ingresar Nombre" : txtno.Text;
        }

        private void txtCantidadn_Leave(object sender, EventArgs e)
        {
            txtCantidadn.Text = txtCantidadn.Text.Equals("") ? "Ingresar Cantidad" : txtCantidadn.Text;
        }

        private void txttotal_Leave(object sender, EventArgs e)
        {
            txttotal.Text = txttotal.Text.Equals("") ? "0" : txttotal.Text;
        }

        private void txtresto_Leave(object sender, EventArgs e)
        {
            txtresto.Text = txtresto.Text.Equals("") ? "0" : txtresto.Text;
        }

        private void txtresto2_Leave(object sender, EventArgs e)
        {
            txtresto2.Text = txtresto2.Text.Equals("") ? "0" : txtresto2.Text;
        }

        private void txtdesc_Leave(object sender, EventArgs e)
        {
            txtdesc.Text = txtdesc.Text.Equals("") ? "0" : txtdesc.Text;
        }

        private void txtinscri_Leave(object sender, EventArgs e)
        {
            txtinscri.Text = txtinscri.Text.Equals("") ? "Ingresar Descuento" : txtinscri.Text;
        }

        private void txtnom_Leave(object sender, EventArgs e)
        {
            txtnom.Text = txtnom.Text.Equals("") ? "Ingresar Nombre" : txtnom.Text;
        }

        private void Becas_Load(object sender, EventArgs e)
        {
            db.CreateConnection();
        }

        private void Becas_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void txtno_Enter(object sender, EventArgs e)
        {
            txtno.Text = txtno.Text.Equals("Ingresar Nombre") ? "" : txtno.Text;
        }

        private void txtCantidadn_Enter(object sender, EventArgs e)
        {
            txtCantidadn.Text = txtCantidadn.Text.Equals("Ingresar Cantidad") ? "" : txtCantidadn.Text;
        }

        private void txttotal_Enter(object sender, EventArgs e)
        {
            txttotal.Text = txttotal.Text.Equals("0") ? "" : txttotal.Text;
        }

        private void txtresto_Enter(object sender, EventArgs e)
        {
            txtresto.Text = txtresto.Text.Equals("0") ? "" : txtresto.Text;
        }

        private void txtno_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtnom_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtresto2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))//Si es número
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

        private void txtinscri_Enter(object sender, EventArgs e)
        {
            txtinscri.Text = txtinscri.Text.Equals("Ingresar Descuento") ? "" : txtinscri.Text;
        }

        private void txtdesc_Enter(object sender, EventArgs e)
        {
            txtdesc.Text = txtdesc.Text.Equals("0") ? "" : txtdesc.Text;
        }

        private void txtresto2_Enter(object sender, EventArgs e)
        {
            txtresto2.Text = txtresto2.Text.Equals("0") ? "" : txtresto2.Text;
        }

        private void txtnom_Enter(object sender, EventArgs e)
        {
            txtnom.Text = txtnom.Text.Equals("Ingresar Nombre") ? "" : txtnom.Text;
        }

        private void txttotal_TextChanged(object sender, EventArgs e)
        {
           try
            {
                txtresto.Text = (Convert.ToDecimal(txttotal.Text)- (Convert.ToDecimal(txtCantidadn.Text))).ToString();
            }
            catch(Exception)
            {

            }
            
        }

        private void txtCantidadn_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtresto.Text = (Convert.ToDecimal(txttotal.Text) - (Convert.ToDecimal(txtCantidadn.Text))).ToString();
            }
            catch (Exception)
            {

            }
        }
    }
}
