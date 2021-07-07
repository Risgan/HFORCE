using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HforceNegocio
{
    public class ClassRemision
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
        /// Selecciona fila de la tabla Empresas seleccionando la empresa
        /// 0=ID_EMRPESA, 1=EMPRESA, 2=TIPO, 3=NIT, 4=DIGITOVR, 5=CIUDAD, 6=DIRECCION, 7=TELEFONO
        /// </summary>
        /// <returns></returns>
        public List<string>[] TablaEmpresasSelectAll(string Empresa)
        {
            string query = "SELECT * FROM 	Empresas WHERE `EMPRESA`='" + Empresa + "'" ;

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

        public int TablaEmpresasSelectIDEmpresa(string Empresa)
        {
            string query = "SELECT `ID_EMRPESA` FROM `Empresas` WHERE `EMPRESA`='" + Empresa + "'";

            List<string>[] list = new List<string>[1];
            list[0] = new List<string>();

            conexionBaseDatos.AbrirConexion();

            MySqlCommand cmd = new MySqlCommand(query, conexionBaseDatos.conexion);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            int i = 0;
            try
            {
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["ID_EMRPESA"].ToString());
                }

                foreach (var item in list[0])
                {
                    i = int.Parse(item);
                } 
                
            }
            catch (Exception)
            {
                i = 0;
            }
            
            
            dataReader.Close();

            conexionBaseDatos.CerrarConexion();

            return i;
        }

        #endregion

        #endregion



        #region Tabla Contacto Empresas

        #region Select

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
        /// Devuelve solo la fila del contacto seleccionado 
        ///0=ID_CONTACTO, 1=ID_EMPRESA, 2=NOMBRE, 3=CORREO, 4=DEPENDENCIA
        /// </summary>
        /// <param name="Nombre"></param>
        /// <returns></returns>
        public List<string>[] TablaContactoEmpresasSelectAll(string Nombre)
        {
            string query = "SELECT * FROM `ContactoEmpresas` WHERE NOMBRE='" + Nombre + "'";

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
        /// Devuelve ID dependencia seleccionando el contacto
        /// </summary>
        /// <param name="Nombre"></param>
        /// <returns></returns>
        public int TablaContactoEmpresasSelectIdDependencia(string Nombre)
        {
            string query = "SELECT `ID_DEPENDENCIA` FROM `ContactoEmpresas` WHERE `NOMBRE`='" + Nombre + "'";

            List<string>[] list = new List<string>[1];
            list[0] = new List<string>();

            conexionBaseDatos.AbrirConexion();

            MySqlCommand cmd = new MySqlCommand(query, conexionBaseDatos.conexion);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            int i = 0;
            try
            {
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["ID_DEPENDENCIA"].ToString());
                }

                foreach (var item in list[0])
                {
                    i = int.Parse(item);
                }

            }
            catch (Exception)
            {
                i = 0;
            }


            dataReader.Close();

            conexionBaseDatos.CerrarConexion();

            return i;
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

        /// <summary>
        /// Devuelve fila seleccionando id dependencia 
        /// 0=Dependencias
        /// </summary>
        /// <param name="IdDependencia"></param>
        /// <returns></returns>
        public List<string>[] TablaDependenciaSelectAll(int IdDependencia)
        {
            string query = "SELECT * FROM `Dependencia` WHERE `ID_DEPENDENCIA`='" + IdDependencia + "'";

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

        #endregion

        #endregion



        #region Tabla Remisión

        #region Select

        /// <summary>
        /// Obtiene el numero de la ultima remisión ingresada
        /// </summary>
        /// <returns></returns>
        public int TablaRemisionSelectNRemision()
        {
            string query = "SELECT `ID_REMISION` FROM `Remision` ORDER BY ID_REMISION DESC LIMIT 1";

            List<string>[] list = new List<string>[1];
            list[0] = new List<string>();

            conexionBaseDatos.AbrirConexion();

            MySqlCommand cmd = new MySqlCommand(query, conexionBaseDatos.conexion);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            int i = 0;
            try
            {
                while (dataReader.Read())
                {
                    list[0].Add(dataReader["ID_REMISION"].ToString());
                }

                foreach (var item in list[0])
                {
                    i = int.Parse(item);
                }

            }
            catch (Exception)
            {
                i = 0;
            }


            dataReader.Close();

            conexionBaseDatos.CerrarConexion();

            return i;
        }
        #endregion

        #endregion
    }
}
