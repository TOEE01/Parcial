using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ParcialNumero1.DAO;
using ParcialNumero1.MODELO;

namespace ParcialNumero1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cargar();
        }

        void cargar() {
            dataGridView1.Rows.Clear();
            using (EMPLEADOEntities db = new EMPLEADOEntities()) {
                var lista = db.Tbl_empleado.ToList();
                foreach (var iteracion in lista) {
                    dataGridView1.Rows.Add(iteracion.Id_empleado, iteracion.Empl_nombre, iteracion.Empl_apellido, iteracion.Empl_DUI, iteracion.Empl_direccin, iteracion.Empl_email, iteracion.Empl_tel, iteracion.Empl_cargo);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String id = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            String Nombre = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            String Apellido = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            String Dui = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            String direccion = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            String telefono = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            String email = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            String cargo = dataGridView1.CurrentRow.Cells[7].Value.ToString();



            txtId.Text = id;
            txtNombre.Text = Nombre;
            txtApellido.Text = Apellido;
            txtDUI.Text = Dui;
            txtDireccion.Text = direccion;
            txtTel.Text = telefono;
            txtEmail.Text = email;
            txtCargo.Text = cargo;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CLsDListaUsu user = new CLsDListaUsu();
            user.delete(Convert.ToInt32(txtId.Text));


            cargar();
        }
    }
}
