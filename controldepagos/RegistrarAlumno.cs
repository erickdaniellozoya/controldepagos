using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace controldepagos
{
    public partial class RegistrarAlumno : Form
    {
        MySqlCon db = new MySqlCon();
        utilities util = new utilities();
        string u;
        bool estadocel = false, estadotel = false, estadofecha = false;
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
                cbxGrado.Items.Add((i + 1).ToString());
            }
            cbxGrupo.Items.Add("A");
            cbxGrupo.Items.Add("B");
        }

        private void txtnombre_Enter(object sender, EventArgs e)
        {
            txtnombre.Text = txtnombre.Text.Equals("Nombre") ? "" : txtnombre.Text;
        }

        private void txtap_Enter(object sender, EventArgs e)
        {
            txtap.Text = txtap.Text.Equals("Apellido Paterno") ? "" : txtap.Text;
        }

        private void txtam_Enter(object sender, EventArgs e)
        {
            txtam.Text = txtam.Text.Equals("Apellido Materno") ? "" : txtam.Text;
        }

        private void txttel_Enter(object sender, EventArgs e)
        {
            txttel.Text = txttel.Text.Equals("Teléfono de Padre o Madre") ? "" : txttel.Text;
        }

        private void txtnp_Enter(object sender, EventArgs e)
        {
            txtnp.Text = txtnp.Text.Equals("Nombre Del Padre") ? "" : txtnp.Text;
        }

        private void txtdir_Enter(object sender, EventArgs e)
        {
            txtdir.Text = txtdir.Text.Equals("Dirección") ? "" : txtdir.Text;
        }

        private void txtnombre_Leave(object sender, EventArgs e)
        {
            txtnombre.Text = txtnombre.Text.Equals("") ? "Nombre" : txtnombre.Text;
        }

        private void txtap_Leave(object sender, EventArgs e)
        {
            txtap.Text = txtap.Text.Equals("") ? "Apellido Paterno" : txtap.Text;
        }

        private void txtam_Leave(object sender, EventArgs e)
        {
            txtam.Text = txtam.Text.Equals("") ? "Apellido Materno" : txtam.Text;
        }

        private void txttel_Leave(object sender, EventArgs e)
        {



            if (txttel.Text.Equals(""))
            {
                txttel.Text = "Teléfono de Padre o Madre";
                estadotel = false;
            }
            else
            {
                if(txttel.TextLength==7)
                {
                    string telefono = String.Format("{0: ###-##-##}", Convert.ToInt64(txttel.Text));
                    txttel.Text = telefono;
                    estadotel = true;
                }
                else if(!estadotel)
                {
                    MessageBox.Show("Favor de ingresar 7 dígitos");
                    txttel.Text = "Teléfono de Padre o Madre";
                
                }

            }
         }

        private void txtnp_Leave(object sender, EventArgs e)
        {
            txtnp.Text = txtnp.Text.Equals("") ? "Nombre del Padre" : txtnp.Text;




        }

        private void txtdir_Leave(object sender, EventArgs e)
        {
            txtdir.Text = txtdir.Text.Equals("") ? "Dirección" : txtdir.Text;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            if ((txtnombre.Text.Equals("Nombre") || txtap.Text.Equals("Apellido paterno") || cbxEscolaridad.Text.Equals("Seleccione la escolaridad") || cbxGrado.Text.Equals("Grado") || cbxGrupo.Text.Equals("Grupo") || txttel.Text.Equals("Teléfono de Padre o Madre") || txtcel.Text.Equals("Celular de Padre o Madre") || txtnp.Text.Equals("Nombre del Padre") || txtnm.Text.Equals("Nombre de la madre") || txtfecha.Text.Equals("Fec. Nac. 00/00/0000") || txtdir.Text.Equals("Dirección")))
            {
                MessageBox.Show("Favor de llenar todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {

                if (txtam.Text == "Apellido Materno") 
                {
                    txtam.Text = "";

                }  
                
                string query = string.Format("INSERT INTO pagos (Nombre, Apellido_paterno, Apellido_materno, Escolaridad, Grado, Grupo, Fec_Nacimiento, Telefono, Celular, Nombre_Padre, Nombre_Madre, Direccion) VALUES('{0}','{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}','{9}','{10}','{11}')", txtnombre.Text, txtap.Text, txtam.Text, cbxEscolaridad.Text, cbxGrado.Text, cbxGrupo.Text,txtfecha.Text, txttel.Text, txtcel.Text, txtnp.Text,txtnm.Text, txtdir.Text);
                if (db.Execute(query)== "-1")
                {
                    MessageBox.Show("El pago ha sido registrado con exito");
                    Index i = new Index(u);
                    i.Show();
                    this.Hide();

                }
                
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

      

        private void txtfecha_Leave(object sender, EventArgs e)
        {
        
            if (txtfecha.Text.Equals(""))
            {
                txtfecha.Text = "Fec. Nac. 00/00/0000";
                estadofecha = false;
            }
            else
            {
                if(txtfecha.TextLength == 8)
                {
                    string FECHA = String.Format("{0: ##/##/####}", Convert.ToInt32(txtfecha.Text));
                    txtfecha.Text = FECHA;
                    estadofecha = true;
                }
               else if(!estadofecha)
                {

                    MessageBox.Show("Favor de ingresar 8 dígitos ");
                    txtfecha.Text = "Fec. Nac. 00/00/0000";
               
                }
            }


        }

        private void txtcel_Leave(object sender, EventArgs e)
        {

            if (txtcel.Text.Equals(""))
            {
                txtcel.Text = "Celular de Padre o Madre";
                estadocel = false;
            }
            else
            {
                if(txtcel.TextLength == 10)
                {
                    string telefono1 = String.Format("{0: (###) ###-####}", Convert.ToInt64(txtcel.Text));
                    txtcel.Text = telefono1;
                    estadocel = true;
                }
               else if(!estadocel)
                {
                    MessageBox.Show("Favor de ingresar 10 dígitos");
                    txtcel.Text = "Celular de Padre o Madre";
               
                }
               


            }

        }
        private void txtnm_Leave(object sender, EventArgs e)
        {
            txtnm.Text = txtnm.Text.Equals("") ? "Nombre de la Madre" : txtnm.Text;
        }

        private void txtfecha_Enter(object sender, EventArgs e)
        {
            txtfecha.Text = txtfecha.Text.Equals("Fec. Nac. 00/00/0000") ? "" : txtfecha.Text;
        }

        private void txtcel_Enter(object sender, EventArgs e)
        {
            txtcel.Text = txtcel.Text.Equals("Celular de Padre o Madre") ? "" : txtcel.Text;
        }

        private void txtnm_Enter(object sender, EventArgs e)
        {
            txtnm.Text = txtnm.Text.Equals("Nombre De La Madre") ? "" : txtnm.Text;
        }

        private void txtnm_TextChanged(object sender, EventArgs e)
        {
            txtnm.Text = util.iniciales(txtnm.Text, txtnm);

        }

        private void txtdir_TextChanged(object sender, EventArgs e)
        {
            txtdir.Text = util.iniciales(txtdir.Text, txtdir);
        }

        private void txttel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsNumber(e.KeyChar))//Si es número
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

        private void txttel_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtnombre_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtap_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtam_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtnp_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtnm_KeyPress(object sender, KeyPressEventArgs e)
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

        private void RegistrarAlumno_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void txtcel_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Si no es número Y NO ES
            //la tecla borrar
            if (!Char.IsNumber(e.KeyChar) &&
                e.KeyChar != Convert.ToChar(Keys.Back))
            {
                e.Handled = true;
            }
        }

        private void txtfecha_KeyPress(object sender, KeyPressEventArgs e)
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
            }else //Si es otra tecla cancelamos
            {
                e.Handled = true;
            }

        }
    }
}