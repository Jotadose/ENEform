using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ENEform
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-0GIDJ12; Initial Catalog=ENE; Integrated Security=True");
        private void btnTest_Click(object sender, EventArgs e)
        {
            SqlCommand Comando = new SqlCommand();
            Comando.CommandText = $"Insert into EmpleadosN (id, Nombre) Values (1, '{txtTest.Text}')";
            Comando.Connection = conn;
            conn.Open();
            Comando.ExecuteNonQuery();
            conn.Close();
            
        }
    }
}
