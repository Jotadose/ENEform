using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ENEform
{
    class conexion
    {
        public bool PruebaConectar()
        {

            try
            {
                SqlConnection Conexion = new SqlConnection("Data Source=DESKTOP-0GIDJ12; Initial Catalog=Sistema; Integrated Security=True"); ;
                SqlCommand Comando = new SqlCommand();
                Comando.CommandText = "Select * From Empleados";
                Comando.Connection = Conexion;
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


