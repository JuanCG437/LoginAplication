using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Entidades;

namespace Datos
{
    public class Class1
    {
        SqlConnection connection = new SqlConnection("Server = PC\\EQUIPO ; Database = SISTEMA ; INTEGRATED SECURITY = true");

        public DataTable tblUsers(Entidades.Class1 obj)
        {
            SqlCommand cmd = new SqlCommand("SELECT USUARIO, PASSWORD FROM TBLPERSONA WHERE USUARIO = @user AND PASSWORD = @pass", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@user", obj.user);
            cmd.Parameters.AddWithValue("@pass", obj.pass);
            SqlDataAdapter data = new SqlDataAdapter(cmd);
            DataTable datatbl = new DataTable();
            data.Fill(datatbl);
            return datatbl;
        }
    }
}
