using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HforceNegocio
{
    public class ClassCliente
    {
        #region Constructores
        ConexionBaseDatos conexionBaseDatos = new ConexionBaseDatos();
        #endregion


        #region Tabla Empresas

        #region Select

        /// <summary>
        /// Cuenta si existe empresa con el Nit
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public int TablaEmpresasSelectCountNit(int Nit)
        {
            string query = "SELECT Count(*) FROM `Empresas` WHERE `NIT`='"+Nit+"'";
            int Count = -1;

            conexionBaseDatos.AbrirConexion();

            MySqlCommand cmd = new MySqlCommand(query, conexionBaseDatos.conexion);

            Count = int.Parse(cmd.ExecuteScalar() + "");

            conexionBaseDatos.CerrarConexion();

            return Count;
        }
        
        /// <summary>
        /// Cuenta si existe empresa con el nombre
        /// </summary>
        /// <param name="Empresa"></param>
        /// <returns></returns>
        public int TablaEmpresasSelectCountEmpresa(string Empresa)
        {
            string query = "SELECT Count(*) FROM `Empresas` WHERE `EMPRESA`='" + Empresa + "'";
            int Count = -1;

            conexionBaseDatos.AbrirConexion();

            MySqlCommand cmd = new MySqlCommand(query, conexionBaseDatos.conexion);

            Count = int.Parse(cmd.ExecuteScalar() + "");

            conexionBaseDatos.CerrarConexion();

            return Count;
        }

        /// <summary>
        /// Trae el nombre de la empresa buscando por el NIT
        /// </summary>
        /// <param name="Nit"></param>
        /// <returns></returns>
        public string TablaEmpresasSelectEmpresa(int Nit)
        {
            string query = "SELECT `EMPRESA` FROM `Empresas` WHERE  `NIT`='" + Nit + "'";
            string dato="";

            conexionBaseDatos.AbrirConexion();
            
            MySqlCommand cmd = new MySqlCommand(query, conexionBaseDatos.conexion);
            
            MySqlDataReader dataReader = cmd.ExecuteReader();
            
            while (dataReader.Read())
            {
                dato = dataReader["EMPRESA"].ToString();
            }
            
            dataReader.Close();

            return dato;
        }

        /// <summary>
        /// Trae el NIT de la empresa buscando por el Nombre
        /// </summary>
        /// <param name="Empresa"></param>
        /// <returns></returns>
        public string TablaEmpresasSelectNit(string Empresa)
        {
            string query = "SELECT `NIT` FROM `Empresas` WHERE  `EMPRESA`='" + Empresa + "'";
            string dato = "";

            conexionBaseDatos.AbrirConexion();

            MySqlCommand cmd = new MySqlCommand(query, conexionBaseDatos.conexion);

            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                dato = dataReader["NIT"].ToString();
            }

            dataReader.Close();

            return dato;
        }

        /// <summary>
        /// Trae el ID de la empresa buscando por el Nombre
        /// </summary>
        /// <param name="Empresa"></param>
        /// <returns></returns>
        public int TablaEmpresasSelectID(string Empresa)
        {
            string query = "SELECT `ID_EMRPESA` FROM `Empresas` WHERE  `EMPRESA`='" + Empresa + "'";
            int dato = 999;

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

        /// <summary>
        /// Cuenta todas las empresas en la tabla Empresas
        /// </summary>
        /// <returns></returns>
        public int TablaEmpresasSelectCount()
        {
            string query = "SELECT Count(*) FROM `Empresas`";
            int Count = -1;

            conexionBaseDatos.AbrirConexion();

            MySqlCommand cmd = new MySqlCommand(query, conexionBaseDatos.conexion);

            Count = int.Parse(cmd.ExecuteScalar() + "");

            conexionBaseDatos.CerrarConexion();

            return Count;
        }

        /// <summary>
        /// Selecciona todos los datos de la tabla Empresas
        /// 0=ID_EMRPESA, 1=EMPRESA, 2=TIPO, 3=NIT, 4=DIGITOVR, 5=CIUDAD, 6=DIRECCION, 7=TELEFONO
        /// </summary>
        /// <returns></returns>
        public List<string>[] TablaEmpresasSelectAll()
        {
            string query = "SELECT * FROM `Empresas`";

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
        /// Selecciona todos los datos de la tabla Empresas
        /// 0=ID_EMRPESA, 1=EMPRESA, 2=TIPO, 3=NIT, 4=DIGITOVR, 5=CIUDAD, 6=DIRECCION, 7=TELEFONO
        /// </summary>
        /// <param name="IdEmpresa"></param>
        /// <returns></returns>
        public List<string>[] TablaEmpresasSelectAll(int IdEmpresa)
        {
            string query = "SELECT * FROM `Empresas` WHERE ID_EMRPESA='" + IdEmpresa+"'";

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

        #endregion

        #region Insert
        public bool TablaEmpresasInsert(string Empresa,string Tipo,int Nit,int Vr,string Ciudad,string Direccion,string Telefono)
        {
            int id = TablaEmpresasSelectCount() + 1;
            string query = "INSERT INTO `Empresas`(`ID_EMRPESA`, `EMPRESA`, `TIPO`, `NIT`, `DIGITOVR`, `CIUDAD`, `DIRECCION`, `TELEFONO`) " +
                "VALUES('"+id+"','"+ Empresa+"','"+ Tipo+"','" +Nit+"','" +Vr+"','" +Ciudad+"','" +Direccion+"','" +Telefono+"')";
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

        #endregion
    }
}
