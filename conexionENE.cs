using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENEform
{
    class conexionENE
    {
        private string cadenaConexion = "Data Source=DESKTOP-0GIDJ12; Initial Catalog=Sistema; Integrated Security=True";
        SqlConnection Conexion;
        public SqlConnection EstablecerConexion()
        {
            this.Conexion = new SqlConnection(this.cadenaConexion);
            return this.Conexion;
        }
        public bool comandoInUpDe(string strComando)
        {

            try
            {
                SqlCommand Comando = new SqlCommand();
                Comando.CommandText = strComando;
                Comando.Connection = this.EstablecerConexion();
                Conexion.Open();
                Comando.ExecuteNonQuery();
                Conexion.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
