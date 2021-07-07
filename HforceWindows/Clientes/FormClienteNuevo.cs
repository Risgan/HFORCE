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
    public partial class FormClienteNuevo : Form
    {
        #region Constructores
        ClassCliente classCliente = new ClassCliente();
        #endregion

        #region Initializate
        public FormClienteNuevo()
        {
            InitializeComponent();
            LeerCiudades();
        }
        #endregion

        #region Guardar
        private void Guardar_click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TEmpresa.Text))
            {
                MessageBox.Show("Falta ingresar el nombre del cliente","Faltan Datos",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                TEmpresa.Focus();
            }
            else if (string.IsNullOrEmpty(TNit.Text))
            {
                MessageBox.Show("Falta ingresar el NIT del cliente", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TNit.Focus();
            }
            else if (string.IsNullOrEmpty(TDireccion.Text))
            {
                MessageBox.Show("Falta ingresar la dirección", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TDireccion.Focus();
            }
            else if (string.IsNullOrEmpty(TTelefono.Text))
            {
                MessageBox.Show("Falta ingresar el teléfono", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TTelefono.Focus();
            }
            else if (string.IsNullOrEmpty(CCiudad.Text))
            {
                MessageBox.Show("Falta ingresar la ciudad", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CCiudad.Focus();
            }
            else
            {
                if (!ComprobarNit()&&!ComprobarEmpresa())
                {
                    GuardarDatos();
                    LimpiarControles();
                }
                else
                {
                    string nit_ = "", empresa_ = "";
                    if (ComprobarNit())
                    {
                        empresa_= classCliente.TablaEmpresasSelectEmpresa(int.Parse(TNit.Text));
                        nit_ = TNit.Text;
                    }
                    else
                    {
                        nit_ = classCliente.TablaEmpresasSelectNit(TEmpresa.Text);
                        empresa_ = TEmpresa.Text;
                    }
                    MessageBox.Show("El cliente "+empresa_+" ya existe\nNIT "+nit_, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region Funciones
        private bool ComprobarNit()
        {
            
            if (classCliente.TablaEmpresasSelectCountNit(int.Parse(TNit.Text))<=0)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }

        private bool ComprobarEmpresa()
        {
            if (classCliente.TablaEmpresasSelectCountEmpresa(TEmpresa.Text) <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void GuardarDatos()
        {
            string tipo = "";
            if (RBJuridica.Checked)
            {
                tipo = "Jurídica";
            }
            else
            {
                tipo = "Natural";
            }            
            
            if (classCliente.TablaEmpresasInsert(TEmpresa.Text, tipo, int.Parse(TNit.Text), int.Parse(NDV.Value.ToString()), CCiudad.Text, TDireccion.Text, TTelefono.Text))
            {
                MessageBox.Show("Cliente ingresado con éxito", "Cliente Nuevo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Error al ingresar el cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LeerCiudades()
        {
            CCiudad.Items.Clear();

            System.IO.StreamReader sr = new System.IO.StreamReader(@"Recursos\Ciudades.txt");            

            while (sr.Peek() != -1)
            {               
                string s = sr.ReadLine();
                if (String.IsNullOrEmpty(s))
                {
                    continue;
                }
                this.CCiudad.Items.Add(s);
            }
            sr.Close();
        }

        private void LimpiarControles()
        {
            TEmpresa.Text = string.Empty;
            TNit.Text = string.Empty;
            TDireccion.Text = string.Empty;
            TTelefono.Text = string.Empty;
            CCiudad.Text = string.Empty;
            NDV.Value = 0;
        }
        #endregion

        private void CCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
