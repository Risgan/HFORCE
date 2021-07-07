using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HforceNegocio
{
    public class ClassContactoCliente
    {
        #region Constructores
        ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();
        #endregion

        #region Tabla Empresas

        #region Select

        /// <summary>
        /// Selecciona toda la tabla Empresas 
        /// 0=ID_EMRPESA, 1=EMPRESA, 2=TIPO, 3=NIT, 4=DIGITOVR, 5=CIUDAD, 6=DIRECCION, 7=TELEFONO
        /// </summary>
        /// <returns></returns>
        public List<string>[] TablaEmpresasSelectAll()
        {
            string query = "SELECT * FROM 	Empresas";

            List<string>[] list = new List<string>[8];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();
            list[4] = new List<string>();
            list[5] = new List<string>();
            list[6] = new List<string>();
            list[7] = new List<string>();


            conexionBaseDatos.AbrirConexion();

            MySqlCommand cmd = new MySqlCommand(query, conexionBaseDatos.conexion);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                list[0].Add(dataReader["ID_EMRPESA"].ToString());
                list[1].Add(dataReader["EMPRESA"].ToString());
                list[2].Add(dataReader["TIPO"].ToString());
                list[3].Add(dataReader["NIT"].ToString());
                list[4].Add(dataReader["DIGITOVR"].ToString());
                list[5].Add(dataReader["CIUDAD"].ToString());
                list[6].Add(dataReader["DIRECCION"].ToString());
                list[7].Add(dataReader["TELEFONO"].ToString());
            }
            dataReader.Close();

            conexionBaseDatos.CerrarConexion();

            return list;
        }

        
        /// <summary>
        /// Devuelve todos los contactos de la empresa seleccionada 
        /// 0=ID_CONTACTO, 1=ID_EMPRESA, 2=NOMBRE, 3=CORREO, 4=DEPENDENCIA
        /// </summary>
        /// <param name="IdEmpresa"></param>
        /// <returns></returns>
        public List<string>[] TablaContactoEmpresasSelectAll(int IdEmpresa)
        {
            string query = "SELECT * FROM 	ContactoEmpresas WHERE ID_EMPRESA='" + IdEmpresa + "'";

            List<string>[] list = new List<string>[5];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            list[3] = new List<string>();
            list[4] = new List<string>();


            conexionBaseDatos.AbrirConexion();

            MySqlCommand cmd = new MySqlCommand(query, conexionBaseDatos.conexion);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                list[0].Add(dataReader["ID_CONTACTO"].ToString());
                list[1].Add(dataReader["ID_EMPRESA"].ToString());
                list[2].Add(dataReader["NOMBRE"].ToString());
                list[3].Add(dataReader["CORREO"].ToString());
                list[4].Add(dataReader["ID_DEPENDENCIA"].ToString());
            }
            dataReader.Close();

            conexionBaseDatos.CerrarConexion();

            return list;
        }

      
        /// <summary>
        /// Selecciona el ID empresa con el nombre de la empresa
        /// </summary>
        /// <param name="Empresa"></param>
        /// <returns></returns>
        public int TablaEmpresasSelectIdEmpresa(string Empresa)
        {
            string query = "SELECT `ID_EMRPESA` FROM `Empresas` WHERE  `EMPRESA`='" + Empresa + "'";
            int dato = 0;

            conexionBaseDatos.AbrirConexion();

            MySqlCommand cmd = new MySqlCommand(query, conexionBaseDatos.conexion);

            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                dato = int.Parse(dataReader["ID_EMRPESA"].ToString());
            }

            dataReader.Close();

            return dato;
        }
        #endregion

        #endregion

        #region Tabla Dependencias

        #region Select

        /// <summary>
        /// Devuelve datos de la tabla Dependencias. 
        /// 0=Dependencias
        /// </summary>
        /// <param name="IdDependencia"></param>
        /// <returns></returns>
        public List<string>[] TablaDependenciaSelectAll()
        {
            string query = "SELECT * FROM `Dependencia`";

            List<string>[] list = new List<string>[1];
            list[0] = new List<string>();


            conexionBaseDatos.AbrirConexion();

            MySqlCommand cmd = new MySqlCommand(query, conexionBaseDatos.conexion);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                list[0].Add(dataReader["DEPENDENCIA"].ToString());
            }
            dataReader.Close();

            conexionBaseDatos.CerrarConexion();

            return list;
        }

        public int TablaTablaDependenciaSelectId(string Dependencia)
        {
            string query = "SELECT `ID_DEPENDENCIA`, `DEPENDENCIA` FROM `Dependencia` WHERE  `DEPENDENCIA`='" + Dependencia + "'";
            int dato = 0;

            conexionBaseDatos.AbrirConexion();

            MySqlCommand cmd = new MySqlCommand(query, conexionBaseDatos.conexion);

            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                dato = int.Parse(dataReader["ID_DEPENDENCIA"].ToString());
            }

            dataReader.Close();

            return dato;
        }
        #endregion

        #endregion

        #region Tabla Contacto Cliente

        #region Insert
        /// <summary>
        /// Insetar Contacto Cliente 
        /// </summary>        
        /// <param name="IdEmpresa"></param>
        /// <param name="Nombre"></param>
        /// <param name="Correo"></param>
        /// <param name="IdDependencia"></param>
        /// <returns></returns>
        public bool TablaContactoEmpresasInsert(String Empresa, string Nombre, string Correo, String Dependencia)
        {
            int IdContacto = TablaContactoEmpresasSelectCount() + 1;
            int IdEmpresa = TablaEmpresasSelectIdEmpresa(Empresa);
            int IdDependencia = TablaTablaDependenciaSelectId(Dependencia);

            string query = "INSERT INTO `ContactoEmpresas`(`ID_CONTACTO`, `ID_EMPRESA`, `NOMBRE`, `CORREO`, `ID_DEPENDENCIA`) VALUES " +
                "('" + IdContacto + "','" + IdEmpresa + "','" + Nombre + "','" + Correo + "','" + IdDependencia + "')";
            try
            {
                conexionBaseDatos.AbrirConexion();

                MySqlCommand cmd = new MySqlCommand(query, conexionBaseDatos.conexion);

                cmd.ExecuteNonQuery();
                conexionBaseDatos.CerrarConexion();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region Select
        /// <summary>
        /// Cuenta todas las filas en la tabla contacto cliente
        /// </summary>
        /// <returns></returns>
        public int TablaContactoEmpresasSelectCount()
        {
            string query = "SELECT Count(*) FROM `ContactoEmpresas`";
            int Count = -1;

            conexionBaseDatos.AbrirConexion();

            MySqlCommand cmd = new MySqlCommand(query, conexionBaseDatos.conexion);

            Count = int.Parse(cmd.ExecuteScalar() + "");

            conexionBaseDatos.CerrarConexion();

            return Count;
        }
        #endregion

        #endregion
    }
}
