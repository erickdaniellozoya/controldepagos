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
    public partial class Pagos : Form
    {
        utilities util = new utilities();
        MySqlCon db = new MySqlCon();
        string u;
        public Pagos(string usuario)
        {
            InitializeComponent();
            u = usuario;
            cbxEscolaridad.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxGrupo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxGrado.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void txtCantidadn_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Index index = new Index(u);
            index.Show();
            this.Hide();
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

        private void txtnomb_TextChanged(object sender, EventArgs e)
        {
            txtnomb.Text = util.iniciales(txtnomb.Text, txtnomb);
            DataTable dt = new DataTable();
            string query = "";
            if (cbxEscolaridad.Text == "Escolaridad" && cbxGrupo.Text == "Grupo" && cbxGrado.Text == "Grado")
            {
                query = string.Format("SELECT * FROM alumnos WHERE Nombre LIKE '%{0}%' OR Apellido_paterno LIKE '%{0}%' or Apellido_materno LIKE '%{0}%'", txtnomb.Text);
            }
            else if (cbxEscolaridad.Text != "Escolaridad" && cbxGrado.Text == "Grado" && cbxGrupo.Text == "Grupo")
            {
                query = string.Format("SELECT * FROM alumnos WHERE (Nombre LIKE '%{0}%' OR Apellido_paterno LIKE '%{0}%' or Apellido_materno LIKE '%{0}%') AND Escolaridad='{1}'", txtnomb.Text, cbxEscolaridad.Text);
            }
            else if (cbxEscolaridad.Text != "Escolaridad" && cbxGrado.Text != "Grado" && cbxGrupo.Text == "Grupo")
            {
                query = string.Format("SELECT * FROM alumnos WHERE (Nombre LIKE '%{0}%' OR Apellido_paterno LIKE '%{0}%' or Apellido_materno LIKE '%{0}%') AND Escolaridad='{1}' AND grado='{2}'", txtnomb.Text, cbxEscolaridad.Text, cbxGrado.Text);
            }
            else if (cbxEscolaridad.Text != "Escolaridad" && cbxGrado.Text != "Grado" && cbxGrupo.Text != "Grupo")
            {
                query = string.Format("SELECT * FROM alumnos WHERE (Nombre LIKE '%{0}%' OR Apellido_paterno LIKE '%{0}%' or Apellido_materno LIKE '%{0}%') AND Escolaridad='{1}' AND grado='{2}' AND grupo='{3}'", txtnomb.Text, cbxEscolaridad.Text, cbxGrado.Text, cbxGrupo.Text);
            }

            dt = db.fillTable(query);
            tabla.DataSource = dt;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if ((txtnomb.Text.Equals("Ingrese Nombre") /*|| cbxGrado.Text.Equals("Grado") || cbxGrupo.Text.Equals("Grupo") */|| txtCantidadl.Text.Equals("Ingresar Cantidad En Letra") || txtconcepto.Text.Equals("Ingresar Comentario") || txtCantidadn.Text.Equals("Ingresar Cantidad En Números") ))
            {
                MessageBox.Show("Favor de llenar todos los campos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            
                else
            {
                    DataTable dt = new DataTable();
                    dt = db.fillTable(string.Format("SELECT Matricula FROM alumnos WHERE concat(Nombre,' ',Apellido_paterno, ' ',Apellido_materno) LIKE '{0}'", txtnomb.Text));

                    tabla.DataSource = dt;

                    string query = string.Format("INSERT INTO pagos(Matricula, BuenoPor,CantidadLetra,Concepto,Fecha_Pago) VALUES('{0}','{1}','{2}','{3}',NOW())", tabla.Rows[0].Cells[0].Value.ToString(), txtCantidadn.Text, txtCantidadl.Text, txtconcepto.Text);
                    if (db.Execute(query) == "-1")
                    {

                        MessageBox.Show("El Pago ha sido registrado con exito");
                        Index i = new Index(u);
                        i.Show();
                        this.Hide();

                    }

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

        private void Pagos_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void txtnomb_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtCantidadl_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtconcepto_KeyPress(object sender, KeyPressEventArgs e)
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtCantidadl_TextChanged(object sender, EventArgs e)
        {
            txtCantidadl.Text = util.iniciales(txtCantidadl.Text, txtCantidadl);
        }

        private void txtconcepto_TextChanged(object sender, EventArgs e)
        {
           txtconcepto.Text = util.iniciales(txtconcepto.Text, txtconcepto);
        }

        private void txtnomb_Leave(object sender, EventArgs e)
        {
            txtnomb.Text = txtnomb.Text.Equals("") ? "Ingresar Nombre" : txtnomb.Text;
        }

        private void txtCantidadn_Leave(object sender, EventArgs e)
        {
            txtCantidadn.Text = txtCantidadn.Text.Equals("") ? "Ingresar Cantidad En Números" : txtCantidadn.Text;
       
        }

        private void txtCantidadl_Leave(object sender, EventArgs e)
        {
            txtCantidadl.Text = txtCantidadl.Text.Equals("") ? "Ingresar Cantidad En Letras" : txtCantidadl.Text;
        }

        private void txtconcepto_Leave(object sender, EventArgs e)
        {
            txtconcepto.Text = txtconcepto.Text.Equals("") ? "Ingresar Comentario" : txtconcepto.Text;
        }

        private void txtnomb_Enter(object sender, EventArgs e)
        {
            txtnomb.Text = txtnomb.Text.Equals("Ingresar Nombre") ? "" : txtnomb.Text;
        }

        private void txtCantidadl_Enter(object sender, EventArgs e)
        {
            txtCantidadl.Text = txtCantidadl.Text.Equals("Ingresar Cantidad En Letras") ? "" : txtCantidadl.Text;
        }

        private void txtconcepto_Enter(object sender, EventArgs e)
        {
            txtconcepto.Text = txtconcepto.Text.Equals("Ingresar Comentario") ? "" : txtconcepto.Text;
        }

        private void txtCantidadn_Enter(object sender, EventArgs e)
        {
            txtCantidadn.Text = txtCantidadn.Text.Equals("Ingresar Cantidad En Números") ? "" : txtCantidadn.Text;
          

        }

        private void Pagos_Load(object sender, EventArgs e)
        {
            db.CreateConnection();
        }
    }
    }
    

            