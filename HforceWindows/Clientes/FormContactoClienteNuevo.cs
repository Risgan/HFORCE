using HforceNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HforceWindows.Clientes
{
    public partial class FormContactoClienteNuevo : Form
    {
        #region Constructores
        ClassContactoCliente classContactoCliente = new ClassContactoCliente();
        #endregion

        #region Variables
        List<String>[] listaTablaEmpresas;
        List<String>[] listaTablaDependencias;
        #endregion

        #region Initializate
        public FormContactoClienteNuevo()
        {
            InitializeComponent();
        }

        private void FormContactoClienteNuevo_Load(object sender, EventArgs e)
        {
            LoadClientes();
            LoadDependencias();
        }
        #endregion

        #region Botón Guardar
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CEmpresas.Text))
            {
                MessageBox.Show("Falta seleccionar la empresa", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CEmpresas.Focus();
            }
            else if (string.IsNullOrEmpty(TNombre.Text))
            {
                MessageBox.Show("Falta ingresar el nombre", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TNombre.Focus();
            }
            else if (string.IsNullOrEmpty(CDepartamento.Text))
            {
                MessageBox.Show("Falta seleccionar el departamento", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CDepartamento.Focus();
            }
            else
            {
                if (string.IsNullOrEmpty(TCorreo.Text))
                {
                    TCorreo.Text = "-";
                }
                if (Guardar())
                {  
                    MessageBox.Show("Contacto Creado", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BorrarContenido();
                }
                else
                {
                    MessageBox.Show("Error al guardar el contacto", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            
        } 
        #endregion

        #region Funciones
        private void LoadClientes()
        {
            listaTablaEmpresas = classContactoCliente.TablaEmpresasSelectAll();

            CEmpresas.Items.Clear();

            foreach (string y in listaTablaEmpresas[1])
            {
                CEmpresas.Items.Add(y);
            }
        }

        private void LoadDependencias()
        {
            listaTablaDependencias = classContactoCliente.TablaDependenciaSelectAll();

            CDepartamento.Items.Clear();

            foreach (var item in listaTablaDependencias[0])
            {
                CDepartamento.Items.Add(item.ToString());
            }
        } 

        private bool Guardar()
        {
            return classContactoCliente.TablaContactoEmpresasInsert(CEmpresas.Text, TNombre.Text, TCorreo.Text, CDepartamento.Text);           
        }

        private void BorrarContenido()
        {
            CEmpresas.Text = string.Empty;
            TNombre.Text = string.Empty;
            TCorreo.Text = string.Empty;
            CDepartamento.Text = string.Empty;
        }
        #endregion

       
    }
}
