using HforceNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HforceWindows.Despacho
{
    public partial class FormDespachoNuevo : Form
    {
        #region Constructores
        ClassRemision classRemision = new ClassRemision();
        ClassCliente classCliente = new ClassCliente();
        ClassContactoCliente classContactoCliente = new ClassContactoCliente();
        DatosHFSAS datosHFSAS = new DatosHFSAS();
        #endregion

        #region Variables
        List<String>[] listaTablaEmpresas;
        List<String>[] listaTablaContactoEmpresas;
        List<String>[] listaDatosEmpresas;       

        #endregion

        #region Initialize
        public FormDespachoNuevo()
        {
            InitializeComponent();
            LoadClientes();
            LeerCiudades();
        }

        public FormDespachoNuevo(int i)
        {
            InitializeComponent();
            LoadClientes();
            if (i!=999)
            {
                LoadDatosClientes(i);
            }
            LeerCiudades();
        }

        private void FormDespachoNuevo_Load(object sender, EventArgs e)
        {
            
        }

        #endregion

        #region Controles Formulario
        private void CEmpresas_SelectedIndexChanged(object sender, EventArgs e)
        {
            CContacto.Text = string.Empty;
            LoadDatosClientes(classCliente.TablaEmpresasSelectID(CEmpresas.Text));
            LoadContactoClientes();
        } 
        #endregion

        #region Funciones

        private void LoadClientes()
        {
            listaTablaEmpresas = classRemision.TablaEmpresasSelectAll();

            CEmpresas.Items.Clear();

            foreach (string y in listaTablaEmpresas[1])
            {
                CEmpresas.Items.Add(y);
            }
        }

        private void LoadContactoClientes()
        {
            int i = classCliente.TablaEmpresasSelectID(CEmpresas.Text);

            listaTablaContactoEmpresas = classContactoCliente.TablaContactoEmpresasSelectAll(i);

            CContacto.Items.Clear();

            foreach (string y in listaTablaContactoEmpresas[2])
            {
                CContacto.Items.Add(y);
            }

        }

        private void LoadDatosClientes(int x)
        {
            listaDatosEmpresas = classCliente.TablaEmpresasSelectAll(x);
                       
            
            //0 = ID_EMRPESA, 1 = EMPRESA, 2 = TIPO, 3 = NIT, 4 = DIGITOVR, 5 = CIUDAD, 6 = DIRECCION, 7 = TELEFONO
            
            foreach (string y in listaDatosEmpresas[1])
            {
                CEmpresas.Text=y;
            }
            foreach (string y in listaDatosEmpresas[3])
            {
                foreach (string w in listaDatosEmpresas[4])
                {
                    TNit.Text = y+"-"+w;
                }
            }
            foreach (string y in listaDatosEmpresas[5])
            {
                CCiudad.Text = y;
            }
            foreach (string y in listaDatosEmpresas[6])
            {
                TDireccion.Text = y;
            }
            foreach (string y in listaDatosEmpresas[7])
            {
                TTelefono.Text = y;
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




        #endregion

        #region Funcion Imprimir
        private void BImprimir_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(CEmpresas.Text)|| string.IsNullOrEmpty(TDireccion.Text)|| string.IsNullOrEmpty(TNit.Text)|| string.IsNullOrEmpty(CCiudad.Text)|| string.IsNullOrEmpty(TTelefono.Text))
            {
                MessageBox.Show("Faltan Datos");
            }
            else
            {
                printDialog1.ShowDialog();
                pageSetupDialog1.ShowDialog();
                printDocument1.PrintPage += GenerarDocumento;
                //printPreviewDialog1.ShowDialog();
                printDocument1.Print();
            }
            
        }

        private void GenerarDocumento(object sender, PrintPageEventArgs e)
        {
            float Ancho = 0, Alto = 0, Inter1 = 36;

            Font font = new Font("Calibri (Cuerpo)", 20, FontStyle.Bold, GraphicsUnit.Point);
            Brush brushes = Brushes.Black;

            RectangleF rectangle = new RectangleF();

            rectangle.Y = Alto += 30;
            rectangle.X = Ancho += 50;

            e.Graphics.DrawString("DE: "+datosHFSAS.RazonSocialMayucs(), font, brushes, rectangle);

            rectangle.Y = Alto += Inter1;

            e.Graphics.DrawString("NIT: "+datosHFSAS.Nit(), font, brushes, rectangle);
            
            rectangle.Y = Alto += Inter1;

            e.Graphics.DrawString("DIR: " + datosHFSAS.Direccion(), font, brushes, rectangle);

            rectangle.Y = Alto += Inter1;

            e.Graphics.DrawString("TEL: " + datosHFSAS.Telefono()+ " CIUDAD: " + datosHFSAS.CiudadMayusc(), font, brushes, rectangle);

            

            //--------------------------Cliente---------------------------------------------------//

            rectangle.Y = Alto += 100;
            rectangle.X = Ancho;

            e.Graphics.DrawString("EMPRESA: " + CEmpresas.Text, font, brushes, rectangle);

            rectangle.Y = Alto += Inter1;
            if (!string.IsNullOrEmpty(CContacto.Text))
            {
                e.Graphics.DrawString("PARA: " + CContacto.Text, font, brushes, rectangle);

                rectangle.Y = Alto += Inter1;
            }            

            e.Graphics.DrawString("NIT: " + TNit.Text, font, brushes, rectangle);

            rectangle.Y = Alto += Inter1;

            e.Graphics.DrawString("DIR: " + TDireccion.Text, font, brushes, rectangle);

            rectangle.Y = Alto += Inter1;

            e.Graphics.DrawString("TEL:" + TTelefono.Text+" CIUDAD: " + CCiudad.Text.ToUpper(), font, brushes, rectangle);

            
        }
       
        #endregion

    }
}
