using HforceNegocio;
using HforceWindows.Clientes;
using HforceWindows.Despacho;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HforceWindows.Remisiones
{
    public partial class FormRemisionNuevo : Form
    {
        #region Constructores
        ClassRemision classRemision = new ClassRemision();
        ClassCliente classCliente = new ClassCliente();
        #endregion

        #region Variables
        List<String>[] listaTablaEmpresas;
        List<String>[] listaTablaContactoEmpresas;
        List<String>[] listaDatosTablaContactoEmpresas;
        List<String>[] listaDatosTablaEmpresas;
        List<String>[] listaTablaDependencias;
        List<String>[] listaDatosDependencias;
        
        #endregion

        #region Initializate
        public FormRemisionNuevo()
        {
            InitializeComponent();
        }

        private void FormRemisionNuevo_Load(object sender, EventArgs e)
        {
            LoadNumRemision();
            LoadClientes();
            LoadDependencias();
            LoadNumRemision();
            CEmpresas.Focus();
        } 
        #endregion

        #region Combobox Empresas
        private void CEmpresas_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarDatosContacto();
            LoadContactoEmpresas();
        }
        #endregion

        #region Combobox Contacto Empresa
        private void CDirigido_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDatosContactoEmpresas();
        }
        #endregion

        #region Imagen Agregar Nueva Empresa
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            FormClienteNuevo formClienteNuevo = new FormClienteNuevo();
            formClienteNuevo.ShowDialog();
            LoadClientes();
        }
        #endregion

        #region Imagen Agregar Nuevo Contacto a Empresa
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FormContactoClienteNuevo formContactoClienteNuevo = new FormContactoClienteNuevo();
            formContactoClienteNuevo.ShowDialog();
            LoadContactoEmpresas();
        }

        #endregion

        #region Funciones
        private void LoadClientes()
        {
            listaTablaEmpresas=classRemision.TablaEmpresasSelectAll();

            CEmpresas.Items.Clear();

            foreach (string y in listaTablaEmpresas[1])
            {
                CEmpresas.Items.Add(y);
            }
        } 

        private void LoadContactoEmpresas()
        {
            int i = classRemision.TablaEmpresasSelectIDEmpresa(CEmpresas.Text);

            listaTablaContactoEmpresas =classRemision.TablaContactoEmpresasSelectAll(i);

            CDirigido.Items.Clear();

            foreach (string y in listaTablaContactoEmpresas[2])
            {
                CDirigido.Items.Add(y);
            }

           int x= listaTablaContactoEmpresas.Count();
            List<string>[] xd = new List<string>[5];
            xd = listaTablaContactoEmpresas;
                     


        }

        private void LoadDatosContactoEmpresas()
        {
            int i=classRemision.TablaContactoEmpresasSelectIdDependencia(CDirigido.Text);
            listaDatosTablaContactoEmpresas = classRemision.TablaContactoEmpresasSelectAll(CDirigido.Text);
            listaDatosTablaEmpresas = classRemision.TablaEmpresasSelectAll(CEmpresas.Text);
            listaDatosDependencias = classRemision.TablaDependenciaSelectAll(i);

            foreach (var item in listaDatosTablaContactoEmpresas[3])
            {
                TCorreo.Text = item.ToString();
            }

            foreach (var item in listaDatosTablaEmpresas[7])
            {
                TTelefono.Text = item.ToString();
            }

            foreach (var item in listaDatosDependencias[0])
            {
                CDepartamento.Text = item.ToString();
            }


        }

        private void LoadDependencias()
        {
            listaTablaDependencias = classRemision.TablaDependenciaSelectAll();

            CDepartamento.Items.Clear();

            foreach (var item in listaTablaDependencias[0])
            {
                CDepartamento.Items.Add(item.ToString());
            }
        }
        
        private void LoadNumRemision()
        {
            LNumRemision.Text = "N°" + (classRemision.TablaRemisionSelectNRemision()+1);
        }

        private void LimpiarDatosContacto()
        {
            CDirigido.Text = string.Empty;
            CDepartamento.Text =string.Empty;
            TCorreo.Text = string.Empty;
            TTelefono.Text = string.Empty;
        }

        #endregion

        #region Generador de despacho
        private void TBGeneradorEnvio_Click(object sender, EventArgs e)
        {
            FormDespachoNuevo formDespachoNuevo = new FormDespachoNuevo(classCliente.TablaEmpresasSelectID(CEmpresas.Text));            
            formDespachoNuevo.ShowDialog();

        }

        #endregion

        #region Guardar Datos
        private void GuardarClick(object sender, EventArgs e)
        {
            
        } 
        #endregion
    }
}
