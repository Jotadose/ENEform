using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;


namespace ENEform
{
    class EmpleadosConexion
    {
        conexionENE conexion;
        public EmpleadosConexion()
        {
            conexion = new conexionENE();
        }

        public bool Agregar()
        {
            return conexion.comandoInUpDe("INSERT INTO EmpleadosEne VALUES (1, 'Juan')"); 
        }
    }
}
